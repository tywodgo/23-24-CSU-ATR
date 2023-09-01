%% Array and patch
% Import data from xlsx
patchTmp = table2array(importfile('PhiCut_patch.xlsx'));
% arrayTmp = table2array(importfile('PhiCut_array.xlsx'));
% 
% % Extract angle and gain (dB)
% theta = flip(patchTmp(:,2) .* pi ./ 180);
% 
% patch = patchTmp(:,8) + abs(min(patchTmp(:,8)));
% 
% array = arrayTmp(:,8) + abs(min(arrayTmp(:,8)));
% 
% % Plotting both patch and array
% ticks = linspace(0,max(array),5);
% polarplot(theta+pi,array,theta+pi,patch.*2.25,'Linewidth',5);
% rticks(ticks)
% rticklabels({'\bf{-26.22}','\bf{-16.22}','\bf{-6.22}','\bf{3.78}','\bf{13.78}'})
% title('\phi-Cut Radiation Pattern at 9GHz (dB)','FontSize',20);
% legend('5-Element Array','Individual Patch Antenna','FontSize',30)

%% Array Alone
% arrayTmp = table2array(importfile('PhiCut_array.xlsx'));
% 
% % Extract angle and gain (dB)
% theta = flip(patchTmp(:,2) .* pi ./ 180);
% array = arrayTmp(:,8) + abs(min(arrayTmp(:,8)));
% 
% % Plotting both patch and array
% ticks = linspace(0,max(array),5);
% polarplot(theta+pi,array,'Linewidth',5);
% rticks(ticks)
% rticklabels({'\bf{-26.22}','\bf{-16.22}','\bf{-6.22}','\bf{3.78}','\bf{13.78}'})
% title('\phi-Cut Radiation Pattern at 9GHz (dB)','FontSize',20);

%% Patch Alone

patchTmp = table2array(importfile('PhiCut_patch.xlsx'));

% Extract angle and gain (dB)
theta = flip(patchTmp(:,2) .* pi ./ 180);
array = patchTmp(:,8) + abs(min(patchTmp(:,8)));

% Plotting both patch and array
ticks = linspace(0,max(array),5);
polarplot(theta+pi,array,'Linewidth',5);
rticks(ticks)
rticklabels({'\bf{-26.22}','\bf{-16.22}','\bf{-6.22}','\bf{3.78}','\bf{13.78}'})
title('\phi-Cut Radiation Pattern at 9GHz (dB)','FontSize',20);

