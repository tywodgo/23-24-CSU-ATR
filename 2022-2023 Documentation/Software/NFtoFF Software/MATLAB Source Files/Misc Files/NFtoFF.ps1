clear
Set-Location $PSScriptRoot
matlab ".\MATLAB Source Files\Interface.m" -nosplash -sd ".\MATLAB Source Files" -r "closeNoPrompt(matlab.desktop.editor.getAll);desktop = com.mathworks.mde.desk.MLDesktop.getInstance;desktop.restoreLayout('Command Window Only');Interface"
