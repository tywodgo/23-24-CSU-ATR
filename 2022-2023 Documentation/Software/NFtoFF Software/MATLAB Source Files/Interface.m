%% Overhead
clc
clearvars

%% Objects
PL = Plotter;
FC = FunctionContainer;
SIMarr = repmat(SimHandler,1,0);
SIMstrarr = [];
SIMdataArr = cell(0,4);

SCANarr = repmat(ScanHandler,1,0);
SCANstrarr = [];
SCANdataArr = cell(0,4);

TSarr = repmat(TransformSweep,1,0);
TSdataArr = cell(0,6);

%% Introduction
errFlag = 0;
option = FC.intro(errFlag);

while option ~= 'x'
    
    switch option
        case 't'
            TS = TransformSweep;
            [dataType,r,freq,polyType,polyNum] = FC.transformInput();

            if dataType == 0
                [SIM,curlType] = FC.simInterface();
                TS.setALL(SIM,r,freq,curlType,dataType,polyType,polyNum);
            elseif dataType == 1
                [SCAN] = FC.scanInterface(freq);
                TS.setALL(SCAN,r,freq,1,dataType,polyType,polyNum);
            end
            TS.sweepTransform();
            TSarr(end+1) = TS;

            prompt = "Save Transform As: ";
            name = input(prompt,"s");
            clc
            
            TSdata = cell(1,6);
            TSdata{1} = name;
            TSdata{2} = dataType;
            TSdata{3} = TS.DATA.Z(1);
            TSdata{4} = r;
            TSdata{5} = freq;
            TSdata{6} = length(TS.DATA.Z);
            TSdataArr{end+1} = TSdata;

        case 'f'
            [dataType,freq] = FC.fieldInput();
            if dataType == 0
                SIM = SimHandler;
                SIM.setSimData();

                SIMarr(end+1) = SIM;

                prompt = "Save Field As: ";
                name = input(prompt,"s");
                clc
                
                SIMdata = cell(1,3);
                SIMdata{1} = name;
                SIMdata{2} = dataType;
                SIMdata{3} = SIM.Z(1);
                SIMdata{4} = length(SIM.Z);
                SIMdataArr{end+1} = SIMdata;
            elseif dataType == 1
                [SCAN,~] = FC.scanInterface(freq);

                SCANarr(end+1) = SCAN;

                prompt = "Save Field As: ";
                name = input(prompt,"s");
                clc
                
                SCANdata = cell(1,3);
                SCANdata{1} = name;
                SCANdata{2} = dataType;
                SCANdata{3} = SCAN.Z(1);
                SCANdata{4} = length(SCAN.Z);
                SCANdataArr{end+1} = SCANdata;
            end

        case 'p'
            clc
            if isempty(TSarr) && isempty(SIMarr) && isempty(SCANarr)
                errFlag = 1;
            else
                f = FC.fieldSelect();
    
                if      f == 1; arr = TSarr;    dataArr = TSdataArr;
                elseif  f == 2; arr = SIMarr;   dataArr = SIMdataArr;
                elseif  f == 3; arr = SCANarr;  dataArr = SCANdataArr;
                end
    
                FIELD = FC.loadData(arr,dataArr,f);
                FC.choosePlot(FIELD,f);
            end
        case 'h'
            FC.help();
        case 'x'
            clc
            exit
    end
    option = FC.intro(errFlag);
end