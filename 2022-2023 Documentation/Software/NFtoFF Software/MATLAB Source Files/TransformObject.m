classdef TransformObject < handle
    properties
        Xmesh; Ymesh;
        xWidth; yWidth;

        RP; IH;
        E; H;
    
        EmagSqr;

        factorLIN; factorLOG;
    end
    methods

        function TO = setDATA(TO,DATA,dataType)
            TO.Xmesh = DATA.Xmesh;
            TO.Ymesh = DATA.Ymesh;
            TO.xWidth = DATA.xWidth;
            TO.yWidth = DATA.yWidth;
            TO.E = DATA.E;
            if dataType == 0
                TO.H = DATA.H;
            end
        end

        function TO = transform(TO,freq,xFF,yFF,zFF,zNF,curlType)
            %% Objects
            FC = FunctionContainer;

            %% Transform Variables
            zFF = zFF - zNF;                        % mesh offset FF point
            %zFF = sqrt(zFF^2 - xFF^2 - yFF^2);
            c0 = 299792458;                         % speed of light
            b0 = 2*pi*freq/c0;                      % β0 constant
            nh = [0 0 1];                           % normal vector
            extCof = exp(-1i*b0*zFF)/(4*pi*zFF);    % external coefficient
            omega = 2*pi*freq;                      % angular frequency
            mu0 = 4*pi*10^-7;                       % µ0 constant

            dx = abs(TO.Xmesh(1,1)-TO.Xmesh(1,2));
            dy = abs(TO.Ymesh(1,1)-TO.Ymesh(2,1));
            A  = dx*dy;                             % scan area

            Q = [xFF yFF zFF];                      % positional FF point
            EFF = [0 0 0];                          % E-field FF point

            %% Compute Directional Vectors
            TO.RP = zeros(TO.xWidth,TO.yWidth,3);
            TO.IH = zeros(TO.xWidth,TO.yWidth,3);
            for x = 1:TO.xWidth
                for y = 1:TO.yWidth
                    TO.RP(x,y,:) = FC.getRP(TO.Xmesh(x,y), ...              
                                             TO.Ymesh(x,y),zNF);
                    TO.IH(x,y,:) = FC.getIH(TO.Xmesh(x,y), ...
                                             TO.Ymesh(x,y),Q);
%                     TO.IH(x,y,:) = FC.getIH(0,0,Q);
                end
            end
            

            %% Compute Curl (Exact)
            % curl(E) = -j⍵*𝜇0*H
            % H = magnetic field
            if curlType == 0
                Ecurl = -1i.*omega.*mu0.*TO.H(:,:,:);
            end

           %% Compute Curl (Approximate)
            % curl(E) ≈ -jb0ih x E(r')
            if curlType == 1
                Ecurl = zeros(TO.xWidth,TO.yWidth,3);
                for x = 1:TO.xWidth
                    for y = 1:TO.yWidth
                        tVec1 = [TO.IH(x,y,1) TO.IH(x,y,2) TO.IH(x,y,3)];
                        tVec2 = [TO.E(x,y,1) TO.E(x,y,2) TO.E(x,y,3)];
                        Ecurl(x,y,:) = FC.cross(-1i.*b0.*tVec1,tVec2);
                    end
                end
            end

            %% Transform
            Eint = zeros(TO.xWidth,TO.yWidth,3);                           % internal transform vector mesh
            for x = 1:TO.xWidth
                for y = 1:TO.yWidth
                    intCof = FC.dot(TO.IH(x,y,:),TO.RP(x,y,:));            % ih . rp 
                    intCof = exp(1i*b0*intCof);                            % e^(j*b0*[ih . rp])
                    tVec = [Ecurl(x,y,1) Ecurl(x,y,2) Ecurl(x,y,3)];
                    ncc = FC.cross(nh,tVec);                               % n' x curl(E(r')) (normal cross curl)
                    
                    tVec = [TO.E(x,y,1) TO.E(x,y,2) TO.E(x,y,3)];
                    Eint(x,y,:) = FC.cross(nh,tVec);                       % n' x E(r')

                    tVec1 = [Eint(x,y,1) Eint(x,y,2) Eint(x,y,3)];
                    tVec2 = [TO.IH(x,y,1) TO.IH(x,y,2) TO.IH(x,y,3)];
                    Eint(x,y,:) = FC.cross(tVec1,tVec2);                   % [n' x E(r')] x ih
                    Eint(x,y,:) = 1i.*b0.*Eint(x,y,:);                     % j*b0*[n' x E(r')] x ih

                    tVec(1) = Eint(x,y,1);
                    tVec(2) = Eint(x,y,2);
                    tVec(3) = Eint(x,y,3);
                    tVec = transpose(tVec);

                    Eint(x,y,:) = plus(ncc,tVec);                          % n' x curl(E(r')) + j*b0*[n' x E(r')] x ih
                    Eint(x,y,:) = Eint(x,y,:) .* intCof;                   % {n' x curl(E(r')) + j*b0*[n' x E(r')] x ih}*e^(j*b0*[ih . rp])
                    Eint(x,y,:) = Eint(x,y,:) .* A;                        % {n' x curl(E(r')) + j*b0*[n' x E(r')] x ih}*e^(j*b0*[ih . rp]) * dS'
                end
            end

            for n = 1:TO.xWidth
                for m = 1:TO.yWidth
                    EFF(1) = Eint(n,m,1) + EFF(1);
                    EFF(2) = Eint(n,m,2) + EFF(2);
                    EFF(3) = Eint(n,m,3) + EFF(3);
%                     EFF = extCof .* EFF;
                end
            end
            EFF = extCof .* EFF;            % e^(-j*b0*r)/(4*pi*r) * Σ {n' x curl(E(r')) + j*b0*[n' x E(r')] x ih}*e^(j*b0*[ih . rp]) * dS'

            %% FF Factor
            % D = sqrt(eps/mu0)*4*pi*r^2*|E|^2/Pzr (not implemented with Pzr)
            eps = 8.854187E-12;
            mu0 = 4*pi*10^-7;
            TO.EmagSqr = EFF(1)*conj(EFF(1)) + EFF(2)*conj(EFF(2)) + EFF(3)*conj(EFF(3)); 
            TO.factorLIN = sqrt(eps/mu0)*4*pi*(zFF^2)*TO.EmagSqr*5;
            TO.factorLOG = 10*log10(TO.factorLIN);
            
        end

    end
end