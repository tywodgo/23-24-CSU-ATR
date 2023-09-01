classdef FunctionContainer < handle
    methods
%--------------------------------------------------------------------------
        %% Computation Methods

        function rtr = cross(~,a,b)
            b = transpose(b);
            rtr = transpose(cross(a,b));
        end

        function rtr = dot(~,a,b)
            rtr = 0;
            for i=1:length(a)
                rtr = rtr + a(i)*b(i);
            end
            rtr = dot(a,b);
        end

        function rtr = getRP(FC,x,y,z0)
            rtr = FC.unit_vector(x,y,z0);
        end

        function rtr = getIH(FC,x,y,Q)
            rtr = FC.unit_vector(Q(1)-x,Q(2)-y,Q(3));
        end

        function rtr = unit_vector(~,x,y,z)
            mag = 1/sqrt(x^2+y^2+z^2);
            rtr = mag*[x,y,z];
        end
%--------------------------------------------------------------------------
        %% CLI Overhead

        function rtr = optionCheck(~)
            fprintf(" - Options - \n\n");
            fprintf("t: Transform\n");
            fprintf("f: Store Field\n")
            fprintf("p: Plot\n");
            fprintf("h: Help\n");
            fprintf("x: Exit\n\n");
            c = input('',"s");
            fprintf("\n");
            rtr = c;
        end

        function rtr = intro(FC,errFlag)
            FC.title();
            if errFlag == 1
                fprintf("ERR: General Error. Select 'h' for Help.\n\n")
            end
            option = FC.optionCheck();

            while option ~= 't' && option ~= 'f' && option ~= 'p' && ...
                option ~= 'h' && option ~= 'x'
                clc
                fprintf("ERR: Invalid Option\n\n");
                option = FC.optionCheck();
            end
            rtr = option;
        end
%--------------------------------------------------------------------------
        %% CLI Data Interpretation

        function [dataType,r,freq,polyType,polyNum] = transformInput(~)
            clc
            prompt = "Simulated Data or Measured Data (0=Simulated, 1=Measured): ";
            dataType = input(prompt);
            
            prompt = "Polynomial Fitted or Unfitted (0=Fitted,1=Unfitted): ";
            polyType = input(prompt);
            polyNum = 0;
            if polyType == 0
                prompt = "Polynomial Degree (preferably even numbered): ";
                polyNum = input(prompt);
            end

            prompt = "Far-field Distance (in meters): ";
            r = input(prompt);
            
            prompt = "Frequency (in Hz): ";
            freq = input(prompt);
        end

        function [SIM,curlType] = simInterface(~)
            fprintf("\n - Simulated Data - \n\n");
            prompt = "What Type of Curl (0=Exact, 1=Approximate): ";
            curlType = input(prompt);
        
            SIM = SimHandler;
            SIM.setSimData();
        end

        function [SCAN,zNF] = scanInterface(~,freq)
            fprintf("\n - Measured Data - \n\n");
            prompt = "What is the Near-field Offset (in meters): ";
            zNF = input(prompt);
            SCAN = ScanHandler;
        
            % Measured Object X-Component
            prompt = "X-Component File (0=Don't Have Data, 1=Select File): ";
            arr(1) = input(prompt);
            if arr(1) ~= 0
                xSCAN = ScanHandler;
                xSCAN.setScanData(freq,zNF);
                SCAN = xSCAN;
                xSCAN.setEcomponent();
            end
        
            % Measured Object Y-Component
            prompt = "Y-Component File (0=Don't Have Data, 1=Select File): ";
            arr(2) = input(prompt);
            if arr(2) ~= 0
                ySCAN = ScanHandler;
                ySCAN.setScanData(freq,zNF);
                SCAN = ySCAN;
                ySCAN.setEcomponent();
            end
        
            % Measured Object Z-Component
            prompt = "Z-Component File (0=Don't Have Data, 1=Select File): ";
            arr(3) = input(prompt);
            if arr(3) ~= 0
                zSCAN = ScanHandler;
                zSCAN.setScanData(freq,zNF);
                SCAN = zSCAN;
                zSCAN.setEcomponent();
            end
        
            switch true
                case arr(1) == 0 && arr(2) ==0 && arr(3) == 0
                    fprintf("\n No Fields Selected\n");
                case arr(1) == 0 && arr(2) ==0 && arr(3) == 1
                    SCAN.setE(0,0,zSCAN.Ecomponent);
                case arr(1) == 0 && arr(2) ==1 && arr(3) == 0
                    SCAN.setE(0,ySCAN.Ecomponent,0);
                case arr(1) == 0 && arr(2) ==1 && arr(3) == 1
                    SCAN.setE(0,ySCAN.Ecomponent,zSCAN.Ecomponent);
                case arr(1) == 1 && arr(2) ==0 && arr(3) == 0
                    SCAN.setE(xSCAN.Ecomponent,0,0);
                case arr(1) == 1 && arr(2) ==0 && arr(3) == 1
                    SCAN.setE(xSCAN.Ecomponent,0,zSCAN.Ecomponent);
                case arr(1) == 1 && arr(2) ==1 && arr(3) == 0
                    SCAN.setE(xSCAN.Ecomponent,ySCAN.Ecomponent,0);
                case arr(1) == 1 && arr(2) ==1 && arr(3) == 1
                    SCAN.setE(xSCAN.Ecomponent,ySCAN.Ecomponent,zSCAN.Ecomponent);
            end
        end


        function [dataType,freq] = fieldInput(~)
            clc
            prompt = "Simulated Data or Measured Data (0=Simulated, 1=Measured): ";
            dataType = input(prompt);
            
            if dataType == 1
                prompt = "Frequency (in Hz): ";
                freq = input(prompt);
            else
                freq = 0;
            end
        end
%--------------------------------------------------------------------------
        %% Plotter Overhead

        function TS = loadData(FC,arr,dataArr,f)
            clc
            num = length(dataArr);
            if num == 0
                fprintf("No Saved Data\n\n")
                 TS = NaN;
                return
            end
            
            fprintf(" - Load Data - \n\n")
            for i = 1:num
                
                str1 = strcat(dataArr{i}{1} + ": " + num2str(i));
                if dataArr{i}{2} == 0;  str2 = "Simulated";
                else;                   str2 = "Measured";
                end

                fprintf("%s\n",str1);
                fprintf("Data Type:         %s\n",str2);

                if f == 1
                    [zNF,prefix1] = FC.siPrefix(dataArr{i}{3});
                    [zFF,prefix2] = FC.siPrefix(dataArr{i}{4});
                    [freq,prefix3] = FC.siPrefix(dataArr{i}{5});
                    numPoints = dataArr{i}{6};

                    fprintf("Near-field Offset: %.4g %s%s\n", zNF,prefix1,"m");
                    fprintf("Far-field Offset:  %.4g %s%s\n", zFF,prefix2,"m");
                    fprintf("Frequency:         %.4g %s%s\n",freq,prefix3,"Hz");
                    fprintf("Number of Points:  %d\n\n",numPoints);
                else
                    [z,prefix] = FC.siPrefix(dataArr{i}{3});
                    numPoints = dataArr{i}{4};

                    fprintf("Field Offset:      %.4g %s%s\n", z,prefix,"m");
                    fprintf("Number of Points:  %d\n\n",numPoints);
                end
            end

            i = input('');
            fprintf("\n");
            TS = arr(i);
        end

        function [siNum,prefix] = siPrefix(~,num)
            prefixes = {'f', 'p', 'n', 'µ', 'm', 'c', '', 'k', 'M', 'G', 'T', 'P', 'E', 'Z', 'Y'};
            exponents = (-5:8)*3;
            exponents = [exponents(1:5) -2 exponents(6:end)];
            prefix_index = find(num >= 10.^(exponents), 1, 'last');
            if isempty(prefix_index)
                prefix_index = 1;
            end
            siNum = num/10^exponents(prefix_index);
            prefix = prefixes{prefix_index};
        end

        function FC = choosePlot(FC,FIELD,f)
            clc
            fprintf(" - Plotter -\n\n");
            fprintf("Heat Map:                  1\n");
            fprintf("Cartesian Sweep:           2\n");
            fprintf("Polar Sweep:               3\n\n");
            plotType = input('');

            switch plotType
                case 1; FC.setHeatMap(FIELD,f);
                case 2; FC.setCartSweep(FIELD,f);
                case 3; FC.setPolarSweep(FIELD,f);
                case 4
                case 5
            end
        end

        function FC = setHeatMap(FC,FIELD,f)
            PL = Plotter;
            PL.setPL();
            arr = zeros(2);

            clc
            fprintf(" - Heat Map -\n\n");
            fprintf("**Note - Heat maps only work for Original Fields**\n\n");
            if f == 1
                arr(1) = FIELD.dataType;
                Fdata = FIELD.DATA;
            elseif f == 2; arr(1) = 0; Fdata = FIELD;
            elseif f == 3; arr(1) = 1; Fdata = FIELD;
            end

            if arr(1) == 0
                prompt = "Electric or Megnetic Field (0=Electric,1=Magnetic):";
                EvH = input(prompt);
                if EvH == 0; F = Fdata.E;   Type = "Electric-field";
                else;        F = Fdata.H;   Type = "Magnetic-field";
                end
            else;            F = Fdata.E;   Type = "Electric-field";
            end

            prompt = "Select Dimension (0=2D, 1=3D): ";
            arr(2) = input(prompt);
            
            if arr(2) == 0
                Xarr = Fdata.Xarray;
                Yarr = Fdata.Yarray;
                Z = Fdata.Z(1);
                PL.heatmap2D(Xarr,Yarr,Z,F,Type,"Position");
            else
                Xmesh = Fdata.Xmesh;
                Ymesh = Fdata.Ymesh;
                Z = Fdata.Z(1);
                PL.heatmap3D(Xmesh,Ymesh,Z,F,Type,"Position");
            end
            clc
        end

        function FC = setCartSweep(FC,FIELD,f)
            PL = Plotter;
            PL.setPL;

            clc
            fprintf(" - Cartesian Sweep -\n\n");
            if f == 1
                prompt = "Original Field or Transformed Field (0=Original, 1=Transformed): ";
                OvT = input(prompt);
                prompt = "Logarithmic or Linear Scale: (0=Log, 1=Lin): ";
                LvL = input(prompt);
                midIndex = (FIELD.DATA.maxWidth-1)/2 + 1;
            else
                OvT = 0;
                prompt = "Logarithmic or Linear Scale: (0=Log, 1=Lin): ";
                LvL = input(prompt);
                midIndex = (FIELD.maxWidth-1)/2 + 1;
            end
            
            fprintf("\nSelect Plot:\n");
            fprintf("Theta:         1\n");
            fprintf("Phi:           2\n");
            fprintf("Theta & Phi:   3\n");
            fprintf("All:           4\n\n");
            p = input('');
            clc

            if OvT == 0
                if f == 1;  Fdata = FIELD.DATA;
                else;       Fdata = FIELD;
                end
                Xarr = Fdata.Xarray;
                Yarr = Fdata.Yarray;
                Z = Fdata.Z(1);
            elseif OvT == 1
                Xarr = FIELD.XFFarray;
                Yarr = FIELD.YFFarray;
                Z = TS.r;
            end

            if OvT == 0; Type = "Original Field";
            else; Type = "Transformed Field";
            end

            if LvL == 0; scaleType = "Logarithmic Factor";
            else; scaleType = "Linear Factor";
            end

            if LvL == 0 && OvT == 0
                Factor(1,:) = Fdata.factorLOG(midIndex,:);
                Factor(2,:) = Fdata.factorLOG(:,midIndex);
            elseif LvL == 0 && OvT == 1; Factor = FIELD.factorLOG;
            elseif LvL == 1 && OvT == 0
                Factor(1,:) = Fdata.factorLIN(midIndex,:);
                Factor(2,:) = Fdata.factorLIN(:,midIndex);
            elseif LvL == 1 && OvT == 1; Factor = FIELD.factorLIN;
            end

            switch p
                case 1; PL.cartThetaSweep(Xarr,Z,Factor(1,:),Type,scaleType,OvT,LvL);
                case 2; PL.cartPhiSweep(Yarr,Z,Factor(2,:),Type,scaleType,OvT,LvL);
                case 3; PL.cartSweep(Xarr,Yarr,Z,Factor,Type,scaleType,OvT,LvL);
                case 4; PL.cartALL(Xarr,Yarr,Z,Factor,Type,scaleType,OvT,LvL);
            end
        end

        function FC = setPolarSweep(FC,FIELD,f)
            PL = Plotter;
            PL.setPL;

            clc
            fprintf(" - Polar Sweep -\n\n");
            if f == 1
                prompt = "Original Field or Transformed Field (0=Original, 1=Transformed): ";
                OvT = input(prompt);
                prompt = "Logarithmic or Linear Scale: (0=Log, 1=Lin): ";
                LvL = input(prompt);
                midIndex = (FIELD.DATA.maxWidth-1)/2 + 1;
            else
                OvT = 0;
                prompt = "Logarithmic or Linear Scale: (0=Log, 1=Lin): ";
                LvL = input(prompt);
                midIndex = (FIELD.maxWidth-1)/2 + 1;
            end
            
            fprintf("\nSelect Plot:\n");
            fprintf("Theta:         1\n");
            fprintf("Phi:           2\n");
            fprintf("Theta & Phi:   3\n");
            fprintf("All:           4\n\n");
            p = input('');
            clc

            if OvT == 0
                if f == 1;  Fdata = FIELD.DATA;
                else;       Fdata = FIELD;
                end
                Xarr = Fdata.Xarray;
                Yarr = Fdata.Yarray;
                Z = Fdata.Z(1);
            elseif OvT == 1
                Xarr = FIELD.XFFarray;
                Yarr = FIELD.YFFarray;
                Z = FIELD.r;
                [zSI,prefix] = FC.siPrefix(FIELD.DATA.Z(1));
                zSI = num2str(zSI);
            end

            if OvT == 0; Type = "Original Field";
                subTit = '';
            else; Type = "Transformed Field";
                subTit = strcat(zSI,prefix,"m Near-field Offset: ");
            end

            if LvL == 0; scaleType = strcat(subTit,"Logarithmic Factor");
            else; scaleType = strcat(subTit,"Linear Factor");
            end

            if LvL == 0 && OvT == 0
                Factor(1,:) = Fdata.factorLOG(:,midIndex);
                Factor(2,:) = Fdata.factorLOG(midIndex,:);
            elseif LvL == 0 && OvT == 1; Factor = FIELD.factorLOG;
            elseif LvL == 1 && OvT == 0
                Factor(1,:) = Fdata.factorLIN(:,midIndex);
                Factor(2,:) = Fdata.factorLIN(midIndex,:);
            elseif LvL == 1 && OvT == 1; Factor = FIELD.factorLIN;
            end

            switch p
                case 1; PL.thetaSweep(Xarr,Z,Factor(1,:),Type,scaleType,OvT,LvL);
                case 2; PL.phiSweep(Yarr,Z,Factor(2,:),Type,scaleType,OvT,LvL);
                case 3; PL.polarSweep(Xarr,Yarr,Z,Factor,Type,scaleType,OvT,LvL);
                case 4; PL.polarALL(Xarr,Yarr,Z,Factor,Type,scaleType,OvT,LvL);
            end
        end
%--------------------------------------------------------------------------
        %% Other

        function rtr = fieldSelect(FC)
            fprintf(" - Select Field - \n\n")
            fprintf("Transform: t\n");
            fprintf("Simulated: s\n")
            fprintf("Measured:  m\n\n");
            f = input('','s');

            if f == 't';     rtr = 1; return
            elseif f == 's'; rtr = 2; return
            elseif f == 'm'; rtr = 3; return
            else
                clc
                fprintf("ERR: Invalid Option\n\n");
                rtr = FC.fieldSelect();
            end
        end

        function FC = help(FC)
            clc
            fprintf("- Help - \n\n");
            
            fid = fopen('Documentation\About NFtoFF.txt');

            tline = fgetl(fid);
            while ischar(tline)
                disp(tline);
                tline = fgetl(fid);
            end
            fprintf("\np: Program Design\n")
            fprintf("d: Providing Data\n");
            fprintf("t: Transforming\n");
            helpIn = input('','s');

            switch helpIn
                case 'p'
                    FC.helpProgramDesign();
                case 'd'
                    FC.helpData();
                case 't'
                    FC.helpTransform();
                otherwise
                    FC.help();
            end
        end

        function FC = helpData(FC)
            clc
            helpIn = 'a';
            while helpIn ~= 'x'
                fid = fopen('Documentation\Providing Data.txt');
                tline = fgetl(fid);
                while ischar(tline)
                    disp(tline);
                    tline = fgetl(fid);
                end
                fprintf("\nx: Exit\n\n")
                helpIn = input('','s');
            end
            clc
        end

        function FC = helpTransform(FC)
            clc
            helpIn = 'a';
            while helpIn ~= 'x'
                fid = fopen('Documentation\Transforming.txt');
                tline = fgetl(fid);
                while ischar(tline)
                    disp(tline);
                    tline = fgetl(fid);
                end
                fprintf("\nx: Exit\n\n")
                helpIn = input('','s');
            end
            clc
        end

        function FC = helpProgramDesign(FC)
            clc
            helpIn = 'a';
            while helpIn ~= 'x'
                fid = fopen('Documentation\Program Design.txt');
                tline = fgetl(fid);
                while ischar(tline)
                    disp(tline);
                    tline = fgetl(fid);
                end
                fprintf("\nx: Exit\n\n")
                helpIn = input('','s');
            end
            clc
        end

        function FC = title(FC)
            
            fid = fopen('Documentation\NFtoFF Logo.txt');
            tline = fgetl(fid);
            while ischar(tline)
                disp(tline);
                tline = fgetl(fid);
            end
            fprintf('\n');
        end

    end
end