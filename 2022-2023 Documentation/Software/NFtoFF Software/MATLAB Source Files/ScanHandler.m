classdef ScanHandler < handle
    properties
        id;

        sParameter;
        sourcePower;
        ifBandwidth;
        averagePoints;

        horizontal;
        vertical;
        depth;
        azimuth;
        elevation;
        polarization;

        frequency; freq; freqInx;
        real;
        imaginary;

        X; Y; Z;
        xWidth; yWidth; maxWidth;
        cartesian; Xmesh; Ymesh;
        Xarray; Yarray;
        
        Ecomponent; E;

        factorLIN; factorLOG; 
    end
    methods
        function SCAN = setScanData(SCAN,freq,zNF)
            [file,path] = uigetfile({'*.txt'},...      % get file
                'Select a Data File', ...
                '..\Data');

            if isequal(file,0)
                fprintf("\n     Data File Selection Cancelled\n");
            else
                fprintf("\n     Data File Selected: %s\n\n",file);
            end
            fullFile = fullfile(path,file);

            SCAN.id = [];
            
            SCAN.sParameter = [];       
            SCAN.sourcePower = [];      
            SCAN.ifBandwidth = [];
            SCAN.averagePoints = [];    
            
            SCAN.horizontal = [];       % x-axis
            SCAN.vertical = [];         % y-axis
            SCAN.depth = [];            % z-axis
            SCAN.azimuth = [];
            SCAN.elevation = [];
            SCAN.polarization = [];
            
            SCAN.frequency = [];      
            SCAN.real = [];
            SCAN.imaginary = [];
            
            fileID = fopen(fullFile,'r');   % opening file (read only)
            count = 0;
            tline = fgetl(fileID);        % read file (one line at a time)
            while ischar(tline)             % while not at the end of the file
                if (rem(count, 4) == 0)
                    values = textscan(tline, "%d %s %f %f %d %f %f %f %f %f %f");
                    
                    SCAN.id = [SCAN.id, values{1}];
                    
                    SCAN.sParameter     = [SCAN.sParameter, values{2}];
                    SCAN.sourcePower    = [SCAN.sourcePower, values{3}];
                    SCAN.ifBandwidth    = [SCAN.ifBandwidth, values{4}];
                    SCAN.averagePoints  = [SCAN.averagePoints, values{5}];
                    
                    SCAN.horizontal     = [SCAN.horizontal, values{6}];
                    SCAN.vertical       = [SCAN.vertical, values{7}];
                    SCAN.depth          = [SCAN.depth, values{8}];
                    SCAN.azimuth        = [SCAN.azimuth, values{9}];
                    SCAN.elevation      = [SCAN.elevation, values{10}];
                    SCAN.polarization   = [SCAN.polarization, values{11}];
            
                elseif (rem(count, 4) == 1)
                    values = transpose(cell2mat(textscan(tline, "%f")));
                    SCAN.frequency = [SCAN.frequency; values];
                elseif (rem(count, 4) == 2)
                    values = transpose(cell2mat(textscan(tline, "%f")));
                    SCAN.real = [SCAN.real; values];
                elseif (rem(count, 4) == 3)
                    values = transpose(cell2mat(textscan(tline, "%f")));
                    SCAN.imaginary = [SCAN.imaginary; values];
                end
                tline = fgetl(fileID); % get next SCAN point
                count = count + 1;
            end
            fclose(fileID); % closing file

            %% Data Configuration
            SCAN.setScanFreq(freq);

            SCAN.xWidth = round(max(SCAN.horizontal) - min(SCAN.horizontal)) + 1;
            SCAN.yWidth = round(max(SCAN.vertical) - min(SCAN.vertical)) + 1;
            SCAN.maxWidth = max(SCAN.xWidth,SCAN.yWidth);

            SCAN.X = SCAN.horizontal .* 0.01;
            SCAN.Y = SCAN.vertical   .* 0.01;
            for n = 1:SCAN.xWidth
                m = mod(n,2);
                if m == 0
                    inx1 = SCAN.yWidth*(n-1) + 1;
                    inx2 = SCAN.yWidth + inx1 - 1;
                    SCAN.Y(1,inx1:inx2) = SCAN.Y(1,inx1:inx2).*-1;
                end
            end
            SCAN.Z = SCAN.depth(1,:) + zNF;

            SCAN.setCartesian();
        end

        function SCAN = setScanFreq(SCAN,freq)
            [~,freqIndex] = min(abs(SCAN.frequency(1,:) - freq));
            SCAN.freqInx = freqIndex;
            SCAN.freq = SCAN.frequency(1,freqIndex);
        end

        function SCAN = setCartesian(SCAN)
            for s = 1:SCAN.xWidth
                for t = 1:SCAN.yWidth
                    SCAN.cartesian(s,t,1) = SCAN.X(t + SCAN.xWidth*(s-1));
                    SCAN.cartesian(s,t,2) = SCAN.X(t + SCAN.yWidth*(s-1));
                end
            end
            SCAN.Xmesh = transpose(SCAN.cartesian(:,:,1));
            SCAN.Ymesh = SCAN.cartesian(:,:,2);
            SCAN.Xarray = SCAN.Xmesh(1,:);
            SCAN.Yarray = transpose(SCAN.Ymesh(:,1));
        end

        function SCAN = setEcomponent(SCAN)
            SCAN.Ecomponent = zeros(SCAN.xWidth,SCAN.yWidth);
            for x = 1:SCAN.xWidth
                for y = 1:SCAN.yWidth
                    SCAN.Ecomponent(x,y) = SCAN.real(y+SCAN.xWidth*(x-1),SCAN.freqInx) + ...
                    1i*SCAN.imaginary(y+SCAN.xWidth*(x-1),SCAN.freqInx);   
                end
            end
        end

        function SCAN = setE(SCAN,Ex,Ey,Ez)
            if Ex == 0
                Ex = zeros(SCAN.xWidth,SCAN.yWidth);
            end

            if Ey ==0
                Ey = zeros(SCAN.xWidth,SCAN.yWidth);
            end

            if Ez == 0
                Ez = zeros(SCAN.xWidth,SCAN.yWidth);
            end

            SCAN.E = zeros(SCAN.xWidth,SCAN.yWidth,3);
            SCAN.E(:,:,1) = Ex;
            SCAN.E(:,:,2) = Ey;
            SCAN.E(:,:,3) = Ez;

            SCAN.setFactor();
        end

        function SCAN = setFactor(SCAN)
            SCAN.factorLIN = zeros(SCAN.xWidth,SCAN.yWidth);
            SCAN.factorLOG  = zeros(SCAN.xWidth,SCAN.yWidth);

            for s = 1:SCAN.xWidth
                for t = 1:SCAN.yWidth
                    Epoint(1) = SCAN.E(s,t,1);
                    Epoint(2) = SCAN.E(s,t,2);
                    Epoint(3) = SCAN.E(s,t,3);

                    EmagSqr = Epoint(1)*conj(Epoint(1)) + ...
                    Epoint(2)*conj(Epoint(2)) + Epoint(3)*conj(Epoint(3));

                    r = SCAN.Z(1);
                    eps = 8.854187E-12;
                    mu0 = 4*pi*10^-7;

                    SCAN.factorLIN(s,t) = sqrt(eps/mu0)*4*pi*(r^2)*EmagSqr;
                    SCAN.factorLOG(s,t)  = 10*log10(norm(Epoint));
                end
            end
        end

    end
end