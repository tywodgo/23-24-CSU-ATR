classdef TransformSweep < handle
    properties
        XFFarray;YFFarray;

        r;freq;

        curlType;dataType;

        factorLIN;factorLOG;
        thetaFactorLIN;thetaFactorLOG;
        phiFactorLIN;phiFactorLOG;
       
        DATA;TO;

        polyType;polyNum;
    end
    methods
        function TS = setALL(TS,DATA,r,freq,curlType,dataType,polyType,polyNum)
            TS.DATA = DATA;

            TS.TO = TransformObject;
            TS.TO.setDATA(TS.DATA,dataType);

            TS.r = r;
            TS.freq = freq;
            TS.curlType = curlType;
            TS.dataType = dataType;

            theta = atan2(TS.DATA.Xarray,TS.DATA.Z(1));
            TS.XFFarray = transpose(TS.r*sin(theta(:)));

            phi = atan2(TS.DATA.Yarray,TS.DATA.Z(1));
            TS.YFFarray = transpose(TS.r*sin(phi(:)));
            
            TS.polyType = polyType;
            TS.polyNum = polyNum;
        end

        function TS = thetaTransform(TS)
            TS.thetaFactorLIN = zeros(1,length(TS.XFFarray));
            TS.thetaFactorLOG = zeros(1,length(TS.XFFarray));
            for n = 1:length(TS.XFFarray)
                TS.TO.transform(TS.freq,TS.XFFarray(n),0, ...
                    TS.r,TS.DATA.Z(1),TS.curlType);
                TS.thetaFactorLIN(n) = TS.TO.factorLIN;
                TS.thetaFactorLOG(n) = TS.TO.factorLOG;
            end
        end

        function phiTransform(TS)
            TS.phiFactorLIN = zeros(1,length(TS.YFFarray));
            TS.phiFactorLOG = zeros(1,length(TS.YFFarray));
            for n = 1:length(TS.YFFarray)
                TS.TO.transform(TS.freq,0,TS.YFFarray(n),TS.r, ...
                TS.DATA.Z(1),TS.curlType);
                TS.phiFactorLIN(n) = TS.TO.factorLIN;
                TS.phiFactorLOG(n) = TS.TO.factorLOG;
            end
        end
        
        function TS = sweepTransform(TS)
            TS.thetaTransform();
            TS.phiTransform();

            TS.factorLIN = zeros(2,TS.DATA.maxWidth);
            TS.factorLOG = zeros(2,TS.DATA.maxWidth);

            TS.factorLIN(1,:) = TS.thetaFactorLIN;
            TS.factorLIN(2,:) = TS.phiFactorLIN;

            TS.factorLOG(1,:) = TS.thetaFactorLOG;
            TS.factorLOG(2,:) = TS.phiFactorLOG;

            TS.polyCheck();
        end

        function TS = polyCheck(TS)
            if TS.polyType == 0
                xPF = polyfit(TS.XFFarray,TS.thetaFactorLIN,TS.polyNum);
                xPV = polyval(xPF,TS.XFFarray);

                yPF = polyfit(TS.YFFarray,TS.phiFactorLIN,TS.polyNum);
                yPV = polyval(yPF,TS.YFFarray);

                TS.thetaFactorLIN = xPV;
                TS.phiFactorLIN = yPV;

                TS.thetaFactorLOG = 10.*log10(TS.thetaFactorLIN);
                TS.phiFactorLOG = 10.*log10(TS.phiFactorLIN);

                TS.factorLIN(1,:) = TS.thetaFactorLIN;
                TS.factorLIN(2,:) = TS.phiFactorLIN;
    
                TS.factorLOG(1,:) = TS.thetaFactorLOG;
                TS.factorLOG(2,:) = TS.phiFactorLOG;
            end
        end

    end
end