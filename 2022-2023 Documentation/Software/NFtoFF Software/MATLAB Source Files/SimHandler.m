classdef SimHandler < handle
    properties
        Data;
        X; Y; Z;
        xWidth; yWidth; maxWidth;
        cartesian; Xmesh; Ymesh;
        Xarray; Yarray;

        EXreal; EXimag;
        EYreal; EYimag;
        EZreal; EZimag;
        E;

        HXreal; HXimag;
        HYreal; HYimag;
        HZreal; HZimag;
        H;

        factorLIN; factorLOG; 
    end
    methods 
        function SIM = setSimData(SIM)
            [file,path] = uigetfile({'*.xlsx'},...      % get file
                'Select a Data File', ...
                '..\Data');

            if isequal(file,0)
                fprintf("\n     Data File Selection Cancelled\n");
            else
                fprintf("\n     Data File Selected: %s\n\n",file);
            end
            fullFile = fullfile(path,file);

            SIM.Data = table2array( ...                 % store file
                readtable(fullFile,...    
                'VariableNamingRule','preserve'));

            SIM.X = transpose(SIM.Data(:,1));           % interpret file
            SIM.Y = transpose(SIM.Data(:,2));
            SIM.Z = transpose(SIM.Data(:,3));

            SIM.EXreal = transpose(SIM.Data(:,4));
            SIM.EXimag = transpose(SIM.Data(:,5));

            SIM.EYreal = transpose(SIM.Data(:,6));
            SIM.EYimag = transpose(SIM.Data(:,7));

            SIM.EZreal = transpose(SIM.Data(:,8));
            SIM.EZimag = transpose(SIM.Data(:,9));

            SIM.HXreal = transpose(SIM.Data(:,10));
            SIM.HXimag = transpose(SIM.Data(:,11));

            SIM.HYreal = transpose(SIM.Data(:,12));
            SIM.HYimag = transpose(SIM.Data(:,13));

            SIM.HZreal = transpose(SIM.Data(:,14));
            SIM.HZimag = transpose(SIM.Data(:,15));

            SIM.setWidth();
            SIM.setE();
            SIM.setH();
            SIM.setCartesian();
            SIM.setFactor();
        end

        function SIM = setWidth(SIM)
            n = SIM.X(1); m = n; SIM.xWidth = 0;        % set X width
            while m == n
                SIM.xWidth = SIM.xWidth + 1;
                n = SIM.X(SIM.xWidth);
            end
            SIM.xWidth = SIM.xWidth - 1;

            n = SIM.Y(1); m = n; SIM.yWidth = 1;        % set Y width
            while 1                                     % do-while loop
                SIM.yWidth = SIM.yWidth + 1;
                n = SIM.Y(SIM.yWidth);
                if m == n, break, end
            end
            SIM.yWidth = SIM.yWidth - 1;

            SIM.maxWidth = max(SIM.xWidth,SIM.yWidth);  % max width
        end

        function SIM = setE(SIM)                      % matrix of E vectors
            SIM.E = zeros(SIM.xWidth,SIM.yWidth,3);
            for s = 1:SIM.xWidth
                for t = 1:SIM.yWidth
                    SIM.E(s,t,1) = SIM.EXreal(t + SIM.maxWidth*(s-1)) ...
                           + 1i * SIM.EXimag(t + SIM.maxWidth*(s-1));
                    SIM.E(s,t,2) = SIM.EYreal(t + SIM.maxWidth*(s-1)) ...
                           + 1i * SIM.EYimag(t + SIM.maxWidth*(s-1));
                    SIM.E(s,t,3) = SIM.EZreal(t + SIM.maxWidth*(s-1)) ...
                           + 1i * SIM.EZimag(t + SIM.maxWidth*(s-1));
                end
            end
        end

        function SIM = setH(SIM)                      % matrix of H vectors
            SIM.H = zeros(SIM.xWidth,SIM.yWidth,3);
            for s = 1:SIM.xWidth
                for t = 1:SIM.yWidth
                    SIM.H(s,t,1) = SIM.HXreal(t + SIM.maxWidth*(s-1)) ...
                           + 1i * SIM.HXimag(t + SIM.maxWidth*(s-1));
                    SIM.H(s,t,2) = SIM.HYreal(t + SIM.maxWidth*(s-1)) ...
                           + 1i * SIM.HYimag(t + SIM.maxWidth*(s-1));
                    SIM.H(s,t,3) = SIM.HZreal(t + SIM.maxWidth*(s-1)) ...
                           + 1i * SIM.HZimag(t + SIM.maxWidth*(s-1));
                end
            end
        end

        function SIM = setFactor(SIM)
            SIM.factorLIN = zeros(SIM.xWidth,SIM.yWidth);
            SIM.factorLOG  = zeros(SIM.xWidth,SIM.yWidth);

            for s = 1:SIM.xWidth
                for t = 1:SIM.yWidth
                    Epoint(1) = SIM.E(s,t,1);
                    Epoint(2) = SIM.E(s,t,2);
                    Epoint(3) = SIM.E(s,t,3);

                    EmagSqr = Epoint(1)*conj(Epoint(1)) + ...
                    Epoint(2)*conj(Epoint(2)) + Epoint(3)*conj(Epoint(3));

                    r = SIM.Z(1);
                    eps = 8.854187E-12;
                    mu0 = 4*pi*10^-7;

                    SIM.factorLIN(s,t) = sqrt(eps/mu0)*4*pi*(r^2)*EmagSqr;
%                     SIM.factorLIN(s,t) = (r^2)*EmagSqr;
                    SIM.factorLOG(s,t) = 10*log10(SIM.factorLIN(s,t));
                end
            end
        end

        function SIM = setCartesian(SIM)
            for s = 1:SIM.xWidth
                for t = 1:SIM.yWidth
                    SIM.cartesian(s,t,1) = SIM.X(t + SIM.xWidth*(s-1));
                    SIM.cartesian(s,t,2) = SIM.X(t + SIM.yWidth*(s-1));
                end
            end
            SIM.Xmesh = transpose(SIM.cartesian(:,:,1));
            SIM.Ymesh = SIM.cartesian(:,:,2);
            SIM.Xarray = SIM.Xmesh(1,:);
            SIM.Yarray = transpose(SIM.Ymesh(:,1));
        end
    end
end