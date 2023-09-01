classdef Plotter < handle
    properties
        theta; thetaRho
        phi;   phiRho

        allFlag;
    end
    methods
%--------------------------------------------------------------------------
        %% Overhead

        function PL = setPL(PL)
            PL.allFlag = 0;
        end
%--------------------------------------------------------------------------
        %% Coordinate Converters

        function PL = setThetaSweep(PL,Xarray,Z,Sarray,LvL)
            midIndex = (length(Sarray)-1)/2 + 1;
            PL.theta = atan2(Xarray(:),Z);
            if LvL == 0                                                    % LOG
                if min(Sarray) < 0
                    maxRho = min(abs(max(Sarray)),abs(min(Sarray)));
                    Sarray = Sarray - min(Sarray) + maxRho;
                    PL.thetaRho = sqrt(Sarray.^2+Xarray.^2);
                    PL.thetaRho = PL.thetaRho - abs(max(PL.thetaRho)) - maxRho;
                else
                    maxRho = sqrt(Sarray(midIndex)^2 + Xarray(midIndex)^2);
                    PL.thetaRho = sqrt(Sarray.^2+Xarray.^2);
                    PL.thetaRho = PL.thetaRho - max(PL.thetaRho)  - maxRho;
                end
                if PL.thetaRho(1) > PL.thetaRho(midIndex)
                    maxRho = max(PL.thetaRho);
                    minRho = PL.thetaRho(midIndex);
                    PL.thetaRho = -1*PL.thetaRho;
                    PL.thetaRho = PL.thetaRho - abs(maxRho) - abs(minRho);
                end
            elseif LvL == 1                                                % LIN
                maxRho = min(abs(max(Sarray)),abs(min(Sarray)));
                Sarray = Sarray - min(Sarray) + maxRho;
                PL.thetaRho = sqrt(Sarray.^2+Xarray.^2);
                if PL.thetaRho(1) > PL.thetaRho(midIndex)

                    minRho = PL.thetaRho(midIndex);
                    PL.thetaRho = -1*PL.thetaRho;

                    difRho = abs(min(PL.thetaRho))+abs(minRho);
                    PL.thetaRho = PL.thetaRho + difRho;
                end
            end
        end

        function PL = setPhiSweep(PL,Yarray,Z,Sarray,LvL)
            midIndex = (length(Sarray)-1)/2 + 1;
            PL.phi = atan2(Yarray(:),Z);
            if LvL == 0                                                    % LOG
                if min(Sarray) < 0
                    maxRho = min(abs(max(Sarray)),abs(min(Sarray)));
                    Sarray = Sarray - min(Sarray) + maxRho;
                    PL.phiRho = sqrt(Sarray.^2+Yarray.^2);
                    PL.phiRho = PL.phiRho - abs(max(PL.phiRho)) - maxRho;
                else
                    maxRho = sqrt(Sarray(midIndex)^2 + Yarray(midIndex)^2);
                    PL.phiRho = sqrt(Sarray.^2+Yarray.^2);
                    PL.phiRho = PL.phiRho - max(PL.phiRho)  - maxRho;
                end
                if PL.phiRho(1) > PL.phiRho(midIndex)
                    maxRho = max(PL.phiRho);
                    minRho = PL.phiRho(midIndex);
                    PL.phiRho = -1*PL.phiRho;
                    PL.phiRho = PL.phiRho - abs(maxRho) - abs(minRho);
                end
            elseif LvL == 1                                                % LIN
                maxRho = min(abs(max(Sarray)),abs(min(Sarray)));
                Sarray = Sarray - min(Sarray) + maxRho;
                PL.phiRho = sqrt(Sarray.^2+Yarray.^2);
                if PL.phiRho(1) > PL.phiRho(midIndex)

                    minRho = PL.phiRho(midIndex);
                    PL.phiRho = -1*PL.phiRho;

                    difRho = abs(min(PL.phiRho))+abs(minRho);
                    PL.phiRho = PL.phiRho + difRho;
                end
            end
        end
%--------------------------------------------------------------------------
        %% Cartesian Factor Plotters

        function PL = cartThetaSweep(PL,Xarray,Z,Factor,Type,axisLabel,OvT,LvL)
            FC = FunctionContainer;

            if length(Factor(:,1)) > 2
                sweepIndex = (length(Factor(1,:))-1)/2 + 1;
                Sarray = Factor(:,sweepIndex);
                Sarray = transpose(Sarray);
            else
                Sarray = Factor;
            end
            PL.setThetaSweep(Xarray,Z,Sarray,LvL);
            PL.theta = rad2deg(PL.theta);
            PL.thetaRho = PL.setOvT(OvT,LvL,PL.thetaRho);

            [maxRho,maxIndex] = max(PL.thetaRho);
            minRho = min(PL.thetaRho);
            maxIndex = PL.theta(maxIndex);

            if PL.allFlag ~= 1; figure; end
            hold on
            plot(PL.theta,PL.thetaRho,'b');
            plot([0 maxIndex],[minRho maxRho],'--r');
            plot(maxIndex,maxRho,"^r",'MarkerFaceColor','b');
            plot(0,minRho,"squarer",'MarkerFaceColor','b');
            grid on

            rangeStr = num2str(abs(maxRho - minRho),'%.4g');
            rangeStr = strcat("Maximum Range: ",rangeStr,"x");
            maxStr = strcat("Maximum Value: ",num2str(maxRho,'%.4gx'));
            minStr = strcat ("Minimum Value: ",num2str(minRho,'%.4gx'));
            [zSI,prefix] = FC.siPrefix(Z);
            zSI = num2str(zSI);

            legend("Theta Sweep",rangeStr,maxStr,minStr,'Location','southoutside');
            titleStr = strcat(Type,": Theta Sweep at ",zSI,prefix,"m Offset");
            title(titleStr)
            xlabel('Theta (°)')
            ylabel(axisLabel)
            hold off
        end

        function PL = cartPhiSweep(PL,Yarray,Z,Factor,Type,axisLabel,OvT,LvL)
            FC = FunctionContainer;

            if length(Factor(:,1)) > 2
            sweepIndex = (length(Factor(:,1))-1)/2 + 1;
            Sarray = Factor(sweepIndex,:);
            else
                Sarray = Factor;
            end

            PL.setPhiSweep(Yarray,Z,Sarray,LvL);
            PL.phi = rad2deg(PL.phi);
            PL.phiRho = PL.setOvT(OvT,LvL,PL.phiRho);
            
            [maxRho,maxIndex] = max(PL.phiRho);
            minRho = min(PL.thetaRho);
            maxIndex = PL.phi(maxIndex);
            
            if PL.allFlag ~= 1; figure; end
            hold on
            plot(PL.phi,PL.phiRho,'color','#E319E0');
            plot([0 maxIndex],[minRho maxRho],'--','color','#14EADA');
            plot(maxIndex,maxRho,"^",'color','#14EADA','MarkerFaceColor','#E319E0');
            plot(0,minRho,"square",'color',"#14EADA",'MarkerFaceColor','#E319E0');
            grid on

            rangeStr = num2str(abs(maxRho - minRho),'%.4g');
            rangeStr = strcat("Maximum Range: ",rangeStr,"x");
            maxStr = strcat("Maximum Value: ",num2str(maxRho,'%.4gx'));
            minStr = strcat ("Minimum Value: ",num2str(minRho,'%.4gx'));
            [zSI,prefix] = FC.siPrefix(Z);
            zSI = num2str(zSI);

            legend("Theta Sweep",rangeStr,maxStr,minStr,'Location','southoutside');
            titleStr = strcat(Type,": Phi Sweep at ",zSI,prefix,"m Offset");
            title(titleStr)
            xlabel('Phi (°)')
            ylabel(axisLabel)
            hold off
        end

        function PL = cartSweep(PL,Xarray,Yarray,Z,Factor,Type,axisLabel,OvT,LvL)
            FC = FunctionContainer;

            if length(Factor(:,1)) > 2
                thetaSweepIndex = (length(Factor(1,:))-1)/2 + 1;
                phiSweepIndex = (length(Factor(1,:))-1)/2 + 1;
                thetaSarray = Factor(:,thetaSweepIndex);
                thetaSarray = transpose(thetaSarray);
                phiSarray = Factor(phiSweepIndex,:);
            else
                thetaSarray = Factor(1,:);
                phiSarray = Factor(2,:);
            end

            PL.setThetaSweep(Xarray,Z,thetaSarray,LvL);
            PL.setPhiSweep(Yarray,Z,phiSarray,LvL);
            PL.thetaRho = PL.setOvT(OvT,LvL,PL.thetaRho);
            PL.phiRho = PL.setOvT(OvT,LvL,PL.phiRho);
            PL.theta = rad2deg(PL.theta);
            PL.phi = rad2deg(PL.phi);

            [thetaMaxRho,thetaMaxIndex] = max(PL.thetaRho);
            thetaMaxIndex = PL.theta(thetaMaxIndex);
            thetaMinRho = min(PL.thetaRho);

            [phiMaxRho,phiMaxIndex] = max(PL.phiRho);
            phiMaxIndex = PL.phi(phiMaxIndex);
            phiMinRho = min(PL.phiRho);

            if PL.allFlag ~= 1; figure; end
            hold on
            plot(PL.theta,PL.thetaRho,'b');
            plot([0 thetaMaxIndex],[thetaMinRho thetaMaxRho],'--r');
            plot(thetaMaxIndex,thetaMaxRho,'^r','MarkerFaceColor','b')
            plot(0,thetaMinRho,'squarer','MarkerFaceColor','b');

            plot(PL.phi,PL.phiRho,'color','#E319E0');
            plot([0 phiMaxIndex],[phiMinRho phiMaxRho],'--','color','#14EADA');
            plot(phiMaxIndex,phiMaxRho,'^','color','#14EADA','MarkerFaceColor','#E319E0');
            plot(0,phiMinRho,'square','color','#14EADA','MarkerFaceColor','#E319E0');
            grid on

            thetaRangeStr = num2str(abs(thetaMaxRho - thetaMinRho),'%.4g');
            thetaRangeStr = strcat("Maximum Theta Sweep Range: ",thetaRangeStr,"x");
            thetaMaxStr = strcat ("Maximum Theta Sweep Value: ",num2str(thetaMaxRho,'%.4gx'));
            thetaMinStr = strcat ("Minimum Theta Sweep Value: ",num2str(thetaMinRho,'%.4gx'));

            phiRangeStr = num2str(abs(phiMaxRho - phiMinRho),'%.4g');
            phiRangeStr = strcat("Maximum Phi Sweep Range: ",phiRangeStr,"x");
            phiMaxStr = strcat ("Maximum Phi Sweep Value: ",num2str(phiMaxRho,'%.4gx'));
            phiMinStr = strcat ("Minimum Phi Sweep Value: ",num2str(phiMinRho,'%.4gx'));

            legend('Theta Sweep',thetaRangeStr,thetaMaxStr,thetaMinStr,...
                'Phi Sweep',phiRangeStr,phiMaxStr,phiMinStr, ...
                'Location','southoutside');
            [zSI,prefix] = FC.siPrefix(Z);
            zSI = num2str(zSI);

            titleStr = strcat(Type,": Cartesian Sweep at ",zSI,prefix,"m Offset");
            title(titleStr);
            xlabel("Theta/Phi (°)")
            ylabel(axisLabel)
            hold off
        end

        function PL = cartALL(PL,Xarray,Yarray,Z,Factor,Type,axisLabel,OvT,LvL)
            FC = FunctionContainer;
            figure
            layout = tiledlayout(2,2);
            [zSI,prefix] = FC.siPrefix(Z);
            zSI = num2str(zSI);
            titleStr = strcat(Type,": Cartesian Plots at ",zSI,prefix,"m Offset");
            title(layout,titleStr);
            layout.TileSpacing = 'tight';
            layout.Padding = 'tight';
            nexttile(layout);

            PL.allFlag = 1;

            if length(Factor(:,1)) == 2
                PL.cartThetaSweep(Xarray,Z,Factor(1,:),Type,axisLabel,OvT,LvL);
                nexttile(layout);
                PL.cartPhiSweep(Yarray,Z,Factor(2,:),Type,axisLabel,OvT,LvL);
                nexttile([1 2]);
                PL.cartSweep(Xarray,Yarray,Z,Factor,Type,axisLabel,OvT,LvL);
            else
                PL.cartThetaSweep(Xarray,Z,Factor,Type,axisLabel,OvT,LvL);
                nexttile(layout);
                PL.cartPhiSweep(Yarray,Z,Factor,Type,axisLabel,OvT,LvL);
                nexttile([1 2]);
                PL.cartSweep(Xarray,Yarray,Z,Factor,Type,axisLabel,OvT,LvL);
            end
            PL.allFlag = 0;
        end
%--------------------------------------------------------------------------
        %% Polar Factor Plotters

        function PL = thetaSweep(PL,Xarray,Z,Factor,Type,rhoLabel,OvT,LvL)
            FC = FunctionContainer;

            if length(Factor(:,1)) > 2
                sweepIndex = (length(Factor(1,:))-1)/2 + 1;
                Sarray = Factor(:,sweepIndex);
                Sarray = transpose(Sarray);
            else
                Sarray = Factor;
            end
            
            PL.setThetaSweep(Xarray,Z,Sarray,LvL);
            PL.theta = transpose(PL.theta);
            PL.thetaRho = PL.setOvT(OvT,LvL,PL.thetaRho);

            [maxRho,maxIndex] = max(PL.thetaRho);
            minRho = min(PL.thetaRho);
            maxIndex = PL.theta(maxIndex);

            if PL.allFlag ~= 1
                figure
            end

            maxRhoLine = linspace(minRho,maxRho,length(PL.theta));
            maxThetaLine = zeros(1,length(PL.theta));

            p1 = polarplot(PL.theta,PL.thetaRho,'b'); hold on
            p2 = polarplot(maxThetaLine,maxRhoLine,'--r');
            p3 = polarplot(maxIndex,maxRho,"^r",'MarkerFaceColor','b');
            p4 = polarplot(0,minRho,"squarer",'MarkerFaceColor','b');

            set(p1,'LineWidth',4);
            set(p2,'LineWidth',4);
            set(p3,'LineWidth',4);
            set(p4,'LineWidth',4);
            rlim([minRho maxRho]);
            set(gca,'ThetaZeroLocation','top');
            set(gca,'ThetaDir','clockwise');
            set(gca,'RGrid','on');
            set(gca,'FontSize',13)
            ax = gca;
            ax.ThetaLim = [-90 90];
            thetaticks([-90 -75 -60 -45 -30 -15 0 15 30 45 60 75 90])
            thetaticklabels({'-90°','-75°','-60°','-45°','-30°','-15°','0°','15°','30°','45°','60°','75°','90°'})

            rangeStr = num2str(abs(maxRho - minRho),'%.4g');
            rangeStr    = strcat("Maximum Range: ",rangeStr,"x");
            maxStr      = strcat("Maximum Value: ",num2str(maxRho,'%.4gx'));
            minStr      = strcat("Minimum Value: ",num2str(minRho,'%.4gx'));
            legend("Theta Sweep",rangeStr,maxStr,minStr,'Location','southoutside','FontSize',16);
            [zSI,prefix] = FC.siPrefix(Z);
            zSI = num2str(zSI);
            titleStr = strcat(Type,": Theta Sweep at ",zSI,prefix,"m Offset");
            minRho = ceil(minRho*50)/50;
            maxRho = floor(maxRho*50)/50;
            rhoRange = linspace(minRho,maxRho,5);
            Raxis = "%0.4gx";
            rtickformat(Raxis);
            rticks(rhoRange)
            t = title(titleStr,rhoLabel);
            t.FontSize = 18;
            hold off
        end

        function PL = phiSweep(PL,Yarray,Z,Factor,Type,rhoLabel,OvT,LvL)
            FC = FunctionContainer;

            if length(Factor(:,1)) > 2
                sweepIndex = (length(Factor(:,1))-1)/2 + 1;
                Sarray = Factor(sweepIndex,:);
                Sarray = transpose(Sarray);
            else
                Sarray = Factor;
            end
            
            PL.setPhiSweep(Yarray,Z,Sarray,LvL);
            PL.phiRho = PL.setOvT(OvT,LvL,PL.phiRho);

            [maxRho,maxIndex] = max(PL.phiRho);
            minRho = min(PL.phiRho);
            maxIndex = PL.phi(maxIndex);

            if PL.allFlag ~= 1
                figure
            end

            maxRhoLine = linspace(minRho,maxRho,length(PL.phi));
            maxPhiLine = zeros(1,length(PL.phi));

            p1 = polarplot(PL.phi,PL.phiRho,'color','#E319E0'); hold on
            p2 = polarplot(maxPhiLine,maxRhoLine,'--','color','#14EADA');
            p3 = polarplot(maxIndex,maxRho,"^",'color','#14EADA','MarkerFaceColor','#E319E0');
            p4 = polarplot(0,minRho,"square",'color','#14EADA','MarkerFaceColor','#E319E0');

            set(p1,'LineWidth',1.25);
            set(p2,'LineWidth',1.25);
            set(p3,'LineWidth',1.25);
            set(p4,'LineWidth',1.25);
            rlim([minRho maxRho]);
            set(gca,'ThetaZeroLocation','top');
            set(gca,'ThetaDir','clockwise');
            set(gca,'RGrid','on');
            set(gca,'FontSize',13)
            ax = gca;
            ax.ThetaLim = [-90 90];
            thetaticks([-90 -75 -60 -45 -30 -15 0 15 30 45 60 75 90])
            thetaticklabels({'-90°','-75°','-60°','-45°','-30°','-15°','0°','15°','30°','45°','60°','75°','90°'})
            
            rangeStr = num2str(abs(maxRho - minRho),'%.4g');
            rangeStr    = strcat("Maximum Range: ",rangeStr,"x");
            maxStr      = strcat("Maximum Value: ",num2str(maxRho,'%.4gx'));
            minStr      = strcat("Minimum Value: ",num2str(minRho,'%.4gx'));
            legend("Phi Sweep",rangeStr,maxStr,minStr,'Location','southoutside','FontSize',16);
            [zSI,prefix] = FC.siPrefix(Z);
            zSI = num2str(zSI);
            titleStr = strcat(Type,": Phi Sweep at ",zSI,prefix,"m Offset");
            minRho = ceil(minRho*50)/50;
            maxRho = floor(maxRho*50)/50;
            rhoRange = linspace(minRho,maxRho,5);
            Raxis = "%0.4gx";
            rtickformat(Raxis);
            rticks(rhoRange)
            t = title(titleStr,rhoLabel);
            t.FontSize = 18;
            hold off
        end

        function PL = polarSweep(PL,Xarray,Yarray,Z,Factor,Type,rhoLabel,OvT,LvL)
            FC = FunctionContainer;

            if length(Factor(:,1)) > 2
                thetaSweepIndex = (length(Factor(1,:))-1)/2 + 1;
                phiSweepIndex = (length(Factor(1,:))-1)/2 + 1;
                thetaSarray = Factor(:,thetaSweepIndex);
                thetaSarray = transpose(thetaSarray);
                phiSarray = Factor(phiSweepIndex,:);
            else
                thetaSarray = Factor(1,:);
                phiSarray = Factor(2,:);
            end
            
            PL.setThetaSweep(Xarray,Z,thetaSarray,LvL);
            PL.setPhiSweep(Yarray,Z,phiSarray,LvL);
            PL.thetaRho = PL.setOvT(OvT,LvL,PL.thetaRho);
            PL.phiRho = PL.setOvT(OvT,LvL,PL.phiRho);

            [thetaMaxRho,thetaMaxIndex] = max(PL.thetaRho(:));
            thetaMinRho = min(PL.thetaRho);
            thetaMaxIndex = PL.theta(thetaMaxIndex);

            [phiMaxRho,phiMaxIndex] = max(PL.phiRho(:));
            phiMinRho = min(PL.phiRho);
            phiMaxIndex = PL.phi(phiMaxIndex);

            if PL.allFlag ~= 1
                figure
            end

            thetaMaxRhoLine = linspace(thetaMinRho,thetaMaxRho,length(PL.theta));
            thetaMaxLine = zeros(1,length(PL.theta));
            phiMaxRhoLine = linspace(phiMinRho,phiMaxRho,length(PL.phi));
            phiMaxLine = zeros(1,length(PL.phi));
            
            p1 = polarplot(PL.theta,PL.thetaRho,'b'); hold on
            p2 = polarplot(thetaMaxLine,thetaMaxRhoLine,'--r');
            p3 = polarplot(thetaMaxIndex,thetaMaxRho,"^r",'MarkerFaceColor','b');
            p4 = polarplot(0,thetaMinRho,"squarer",'MarkerFaceColor','b');

            p5 = polarplot(PL.phi,PL.phiRho,'color','#E319E0');
            p6 = polarplot(phiMaxLine,phiMaxRhoLine,'--','color','#14EADA');
            p7 = polarplot(phiMaxIndex,phiMaxRho,"^",'color','#14EADA','MarkerFaceColor','#E319E0');
            p8 = polarplot(0,phiMinRho,"square",'color','#14EADA','MarkerFaceColor','#E319E0');

            set(p1,'LineWidth',1.25); set(p2,'LineWidth',1.25);
            set(p3,'LineWidth',1.25); set(p4,'LineWidth',1.25);
            set(p5,'LineWidth',1.25); set(p6,'LineWidth',1.25);
            set(p7,'LineWidth',1.25); set(p8,'LineWidth',1.25);
            minRho = min(thetaMinRho,phiMinRho);
            maxRho = max(thetaMaxRho,phiMaxRho);
            rlim([minRho maxRho]);
            set(gca,'ThetaZeroLocation','top');
            set(gca,'ThetaDir','clockwise');
            set(gca,'RGrid','on');
            set(gca,'FontSize',13)
            ax = gca;
            ax.ThetaLim = [-90 90];
            thetaticks([-90 -75 -60 -45 -30 -15 0 15 30 45 60 75 90])
            thetaticklabels({'-90°','-75°','-60°','-45°','-30°','-15°','0°','15°','30°','45°','60°','75°','90°'})

            thetaRangeStr = num2str(abs(thetaMaxRho - thetaMinRho),'%.4g');
            thetaRangeStr = strcat("Maximum Theta Sweep Range: ",thetaRangeStr,"x");
            thetaMaxStr = strcat ("Maximum Theta Sweep Value: ",num2str(thetaMaxRho,'%.4gx'));
            thetaMinStr = strcat ("Minimum Theta Sweep Value: ",num2str(thetaMinRho,'%.4gx'));

            phiRangeStr = num2str(abs(phiMaxRho - phiMinRho),'%.4g');
            phiRangeStr = strcat("Maximum Phi Sweep Range: ",phiRangeStr,"x");
            phiMaxStr = strcat ("Maximum Phi Sweep Value: ",num2str(phiMaxRho,'%.4gx'));
            phiMinStr = strcat ("Minimum Phi Sweep Value: ",num2str(phiMinRho,'%.4gx'));

            legend('Theta Sweep',thetaRangeStr,thetaMaxStr,thetaMinStr,...
                'Phi Sweep',phiRangeStr,phiMaxStr,phiMinStr, ...
                'Location','southoutside','FontSize',16);
            [zSI,prefix] = FC.siPrefix(Z);
            zSI = num2str(zSI);
            titleStr = strcat(Type,": Polar at ",zSI,prefix,"m Offset");
            minRho = ceil(minRho*50)/50;
            maxRho = floor(maxRho*50)/50;
            rhoRange = linspace(minRho,maxRho,5);
            Raxis = "%0.4gx";
            rtickformat(Raxis);
            rticks(rhoRange)
            t = title(titleStr,rhoLabel);
            t.FontSize = 18;
            hold off
        end

        function polarALL(PL,Xarray,Yarray,Z,Factor,Type,rhoLabel,OvT,LvL)
            FC = FunctionContainer;
            
            figure
            layout = tiledlayout(4,6);
            
            layout.TileSpacing = 'loose';
            layout.Padding = 'loose';
            nexttile(7,[2 2]);

            PL.allFlag = 1;

            if length(Factor(:,1)) ==2
                PL.thetaSweep(Xarray,Z,Factor(1,:),Type,rhoLabel,OvT,LvL);
                nexttile(11,[2 2]);
                PL.phiSweep(Yarray,Z,Factor(2,:),Type,rhoLabel,OvT,LvL);
                nexttile(15,[2 2]);
                PL.polarSweep(Xarray,Yarray,Z,Factor,Type,rhoLabel,OvT,LvL);
            else
                PL.thetaSweep(Xarray,Z,Factor,Type,rhoLabel,OvT,LvL);
                nexttile(11,[2 2]);
                PL.phiSweep(Yarray,Z,Factor,Type,rhoLabel,OvT,LvL);
                nexttile(15,[2 2]);
                PL.polarSweep(Xarray,Yarray,Z,Factor,Type,rhoLabel,OvT,LvL);
            end
            PL.allFlag = 0;
            [zSI,prefix] = FC.siPrefix(Z);
            zSI = num2str(zSI);
            titleStr = strcat(Type,": Polar at ",zSI,prefix,"m Offset");
            leg = legend('Location','south');
            leg.Layout.Tile = 9;
            leg.Layout.TileSpan = [1 2];
            title(leg,titleStr,'FontSize',22)
        end
%--------------------------------------------------------------------------
        %% Field Plotters

        function PL = heatmap2D(PL,Xarray,Yarray,Z,Field,Type,axisLabel)
            FC = FunctionContainer;
            [zSI,prefix] = FC.siPrefix(Z);
            zSI = num2str(zSI);
            figure
            xLabel = strcat('X-',axisLabel);
            yLabel = strcat('Y-',axisLabel);
            
            RX = strcat(Type," at Real X-Component");
            RY = strcat(Type," at Real Y-Component");
            RZ = strcat(Type," at Real Z-Component");
            IX = strcat(Type," at Imaginary X-Component");
            IY = strcat(Type," at Imaginary Y-Component");
            IZ = strcat(Type," at Imaginary Z-Component");
            realLabel = [RX,RY,RZ];
            imagLabel = [IX,IY,IZ];

            layout = tiledlayout(3,2);
            titleStr = strcat(Type,": 2D Heat Map at ",zSI," ",prefix,"m Offset");
            title(layout,titleStr);
            layout.TileSpacing = 'tight';
            layout.Padding = 'tight';
            nexttile(layout);

            for n = 1:3
                imagesc(Xarray,Yarray,real(Field(:,:,n)))
                pbaspect([1,1,0.01])
                view(3)
                title(realLabel(n))
                xlabel(xLabel)
                ylabel(yLabel)
                colorbar
                switch n
                    case 1
                        nexttile(3)
                    case 2
                        nexttile(5)
                    case 3
                        nexttile(2)
                end
            end
            for n = 1:3
                imagesc(Xarray,Yarray,imag(Field(:,:,n)))
                pbaspect([1,1,0.01])
                view(3)
                title(imagLabel(n))
                xlabel(xLabel)
                ylabel(yLabel)
                colorbar
                switch n
                    case 1
                        nexttile(4)
                    case 2
                        nexttile(6)
                    case 3
                end
            end
        end

        function PL = heatmap3D(PL,Xmesh,Ymesh,Z,Field,Type,axisLabel)
            FC = FunctionContainer;
            [zSI,prefix] = FC.siPrefix(Z);
            zSI = num2str(zSI);

            figure
            xLabel = strcat('X-',axisLabel);
            yLabel = strcat('Y-',axisLabel);
            
            RX = strcat(Type," at Real X-Component");
            RY = strcat(Type," at Real Y-Component");
            RZ = strcat(Type," at Real Z-Component");
            IX = strcat(Type," at Imaginary X-Component");
            IY = strcat(Type," at Imaginary Y-Component");
            IZ = strcat(Type," at Imaginary Z-Component");
            realLabel = [RX,RY,RZ];
            imagLabel = [IX,IY,IZ];

            layout = tiledlayout(3,2);
            titleStr = strcat(Type,": 3D Heat Map at ",zSI,prefix,"m Offset");
            title(layout,titleStr);
            layout.TileSpacing = 'tight';
            layout.Padding = 'tight';
            nexttile(layout);

            for n = 1:3
                surf(Xmesh,Ymesh,real(Field(:,:,n)))
                title(realLabel(n))
                xlabel(xLabel)
                ylabel(yLabel)
                colorbar
                switch n
                    case 1
                        nexttile(3)
                    case 2
                        nexttile(5)
                    case 3
                        nexttile(2)
                end
            end

            for n = 1:3
                surf(Xmesh,Ymesh,imag(Field(:,:,n)))
                title(imagLabel(n))
                xlabel(xLabel)
                ylabel(yLabel)
                colorbar
                switch n
                    case 1
                        nexttile(4)
                    case 2
                        nexttile(6)
                    case 3
                end
            end
        end
%--------------------------------------------------------------------------
%         %% Vector Field Plotters 
%         (used to test if transform vector fields are accurate)
% 
%         function PL = plotRP(PL,Xmesh,Ymesh,RP,Type)
% 
%             xMin = Xmesh(1,1);
%             xMax = Xmesh(1,end);
%             yMin = Ymesh(1,1);
%             yMax = Ymesh(end,1);
%             Type = strcat(Type,": r' (X,Y) Vector Field");
% 
%             %figure
%             quiver(Xmesh,Ymesh,RP(:,:,1),RP(:,:,2),2,'b');
%             pbaspect([1 1 0.01])
%             xlim([xMin xMax])
%             ylim([yMin yMax])
%             title(Type)
%             xlabel('X-Postion (m)')
%             ylabel('Y-Vertical Postion (m)')
%         end
% 
%         function PL = plotIH(PL,Xmesh,Ymesh,IH,Type)
% 
%             xMin = Xmesh(1,1);
%             xMax = Xmesh(1,end);
%             yMin = Ymesh(1,1);
%             yMax = Ymesh(end,1);
%             Type = strcat(Type,": ĩ (X,Y) Vector Field");
% 
%             %figure
%             quiver(Xmesh,Ymesh,IH(:,:,1),IH(:,:,2),2,'r');
%             pbaspect([1 1 0.01])
%             xlim([xMin xMax])
%             ylim([yMin yMax])
%             title(Type)
%             xlabel('X-Postion (m)')
%             ylabel('Y-Vertical Postion (m)')
%         end
% 
%         function rtrRho = setOvT(~,OvT,LvL,rho)
%             if      OvT == 0 && LvL == 0
%                 rtrRho = rho;
%                 return
%             elseif  OvT == 0 && LvL == 1
%                 rtrRho = rho;
%                 return
%             elseif  OvT == 1 && LvL == 0
%                 rtrRho = rho;
%                 return
%             elseif  OvT == 1 && LvL == 1
%                 S = 0.97407;
%                 O = 0.02;
%                 rtrRho = S.*rho + O;
%                 return
%             end
%             rtrRho = rho;
%         end

    end
end