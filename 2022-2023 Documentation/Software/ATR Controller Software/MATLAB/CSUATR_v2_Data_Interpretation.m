%% CSUATR_v2 Program Data Interpretation
% This program takes will display a dataset wtth the following assumptions:
% All data points have the same S-Parameter
% Data points were obtained in a grid-pattern
% Data points were obtained in a zig-zag fashion (down, right, up, right..)
% The x-axis had the greater number of movements

close all

dataPath = "C:\Users\Jason\Documents\SeniorDesign\csuatr\Matlab Code\Data\"; % Complete path to your data
dataFile = "11_18_2020_Elevation_Azimuth.txt"; % Name of the data file
xAxis = 'Azimuth';
yAxis = 'Elevation';
xAxisWidth = 41;  % Given by how many data point that were taken for each pass of the x-axis 
frequencyIndex = 33;

fullpath = dataPath + dataFile;
data = ReadCSUATRData(fullpath);
PlotCartesian(data, 'Amplitude (V)', yAxis, xAxis, xAxisWidth, frequencyIndex)
PlotCartesian(data, 'Magnitude (dB)', yAxis, xAxis, xAxisWidth, frequencyIndex)
PlotCartesian(data, 'Real', yAxis, xAxis, xAxisWidth, frequencyIndex)
PlotCartesian(data, 'Imaginary', yAxis, xAxis, xAxisWidth, frequencyIndex)
%PlotAzimuthElevationSpherical(data, 'Amplitude', data.elevation, data.azimuth, 42, frequencyIndex)


%% Retrieve Data
function data = ReadCSUATRData(filename)
fprintf('Reading file: %s\n', filename)
data.id = [];

data.sParameter = []; %data.mode = [];
data.sourcePower = []; %data.power = [];
data.ifBandwidth = [];
data.averagePoints = []; %data.avgpoints = [];

data.horizontal = [];
data.vertical = [];
data.depth = [];
data.azimuth = [];
data.elevation = [];
data.polarization = [];

data.frequency = [[]];
data.real = [[]];
data.imaginary = [[]];

% read file
fileID = fopen(filename,'r'); % opening file
count = 0;
tline = fgetl(fileID); % get first data point
while ischar(tline)
    %fprintf("line: %d, value: %s\n", count, tline)
    if (rem(count, 4) == 0)
        values = textscan(tline, "%d %s %f %f %d %f %f %f %f %f %f");
        
        data.id = [data.id, values{1}];
        
        data.sParameter = [data.sParameter, values{2}];
        data.sourcePower = [data.sourcePower, values{3}];
        data.ifBandwidth = [data.ifBandwidth, values{4}];
        data.averagePoints = [data.averagePoints, values{5}];
        
        data.horizontal = [data.horizontal, values{6}];
        data.vertical = [data.vertical, values{7}];
        data.depth = [data.depth, values{8}];
        data.azimuth = [data.azimuth, values{9}];
        data.elevation = [data.elevation, values{10}];
        data.polarization = [data.polarization, values{11}];

    elseif (rem(count, 4) == 1)
        values = transpose(cell2mat(textscan(tline, "%f")));
        data.frequency = [data.frequency; values];
    elseif (rem(count, 4) == 2)
        values = transpose(cell2mat(textscan(tline, "%f")));
        data.real = [data.real; values];
    elseif (rem(count, 4) == 3)
        values = transpose(cell2mat(textscan(tline, "%f")));
        data.imaginary = [data.imaginary; values];
    end
    tline = fgetl(fileID); % get next data point
    count = count + 1;
end
fclose(fileID); % closing file
end

%% Plot Data
function PlotCartesian(data, zAxis, yAxis, xAxis, xAxisWidth, frequencyIndex)
%% compensate (removes excess that does not compose a grid pattern)
len = length(data.id) - rem(length(data.id), xAxisWidth);

%% compute x axis
x = [];
xLabel = 'None';
if (strcmp(xAxis, 'Polarization') == 1)
    xLabel = 'Polarization (degrees)';
    x = data.polarization(1:len);
elseif (strcmp(xAxis, 'Vertical') == 1)
    xLabel = 'Vertical (cm)';
    x = data.vertical(1:len);
elseif (strcmp(xAxis, 'Horizontal') == 1)
    xLabel = 'Horizontal (cm)';
    x = data.horizontal(1:len);
elseif (strcmp(xAxis, 'Depth') == 1)
    xLabel = 'Depth (cm)';
    x = data.depth(1:len);
elseif (strcmp(xAxis, 'Azimuth') == 1)
    xLabel = 'Azimuth (degrees)';
    x = data.azimuth(1:len);
elseif (strcmp(xAxis, 'Elevation') == 1)
    xLabel = 'Elevation (degrees)';
    x = data.elevation(1:len);
else
    return;
end
x = reshape(x, xAxisWidth, []);
x(:,2:2:end) = flipud(x(:,2:2:end));
X = transpose(x(:,1)); % get x values

%% compute y axis
y = [];
yLabel = ' ';
if (strcmp(yAxis, 'Polarization') == 1)
    yLabel = 'Polarization (degrees)';
    y = data.polarization(1:len);
elseif (strcmp(yAxis, 'Vertical') == 1)
    yLabel = 'Vertical (cm)';
    y = data.vertical(1:len);
elseif (strcmp(yAxis, 'Horizontal') == 1)
    yLabel = 'Horizontal (cm)';
    y = data.horizontal(1:len);
elseif (strcmp(yAxis, 'Depth') == 1)
    yLabel = 'Depth (cm)';
    y = data.depth(1:len);
elseif (strcmp(yAxis, 'Azimuth') == 1)
    yLabel = 'Azimuth (degrees)';
    y = data.azimuth(1:len);
elseif (strcmp(yAxis, 'Elevation') == 1)
    yLabel = 'Elevation (degrees)';
    y = data.elevation(1:len);
else
    return;
end
y = reshape(y, xAxisWidth, []);
y(:,2:2:end) = flipud(y(:,2:2:end));
Y = y(1,:); % get y values

%% compute z matrix
z = [];
if (strcmp(zAxis, 'Real') == 1)
    type = 'Real';
    z = transpose(data.real(1:len,frequencyIndex));
elseif (strcmp(zAxis, 'Imaginary') == 1)
    type = 'Imaginary';
    z = transpose(data.imaginary(1:len,frequencyIndex));
elseif (strcmp(zAxis, 'Magnitude (dB)') == 1)
    type = 'Magnitude';
    zr = transpose(data.real(1:len,frequencyIndex));
    zi = transpose(data.imaginary(1:len,frequencyIndex));
    z = 20*log10(sqrt(zr.*zr + zi.*zi));
elseif (strcmp(zAxis, 'Phase') == 1)
    type = 'Phase';
    zr = transpose(data.real(1:len,frequencyIndex));
    zi = transpose(data.imaginary(1:len,frequencyIndex));
    z = (180 / pi) * atan2(zi, zr);
elseif (strcmp(zAxis, 'Amplitude (V)') == 1)
    type = 'Amplitude';
    zr = transpose(data.real(1:len,frequencyIndex));
    zi = transpose(data.imaginary(1:len,frequencyIndex));
    z = sqrt(zr.*zr + zi.*zi);
else
    return;
end
z = reshape(z, [], xAxisWidth);
z(:,2:2:end) = flipud(z(:,2:2:end));
Z = z; % get z values

%% compute frequency
f = data.frequency(1, frequencyIndex); % get frequency
F = f / 1000000; % compute frequency in MHz

%% display data
figure()
surf(X, Y, Z)
% contour(X, Y, Z)
% mesh(X,Y,Z)

%% annotate plot
title(sprintf('Plot: %s   Index: %d   Frequency: %fMHz ', type, frequencyIndex, F))
xlabel(xLabel)
ylabel(yLabel)
zlabel(zAxis)
end

function PlotAzimuthElevationSpherical(data, dataType, elevation, azimuth, xAxisWidth, frequencyIndex)
%% compensate (removes excess that does not compose a grid pattern)
len = length(data.id) - rem(length(data.id), xAxisWidth);

%% compute x axis
x = data.azimuth(1:len);
x = reshape(x, xAxisWidth, []);
x(:,2:2:end) = flipud(x(:,2:2:end));
X = transpose(x(:,1)); % get x values

%% compute y axis
y = data.elevation(1:len);
y = reshape(y, xAxisWidth, []);
y(:,2:2:end) = flipud(y(:,2:2:end));
Y = y(1,:); % get y values

%% compute z matrix
z = [];
if (strcmp(dataType, 'Real') == 1)
    z = transpose(data.real(1:len,frequencyIndex));
elseif (strcmp(dataType, 'Imaginary') == 1)
    z = transpose(data.imaginary(1:len,frequencyIndex));
elseif (strcmp(dataType, 'Magnitude') == 1)
    zr = transpose(data.real(1:len,frequencyIndex));
    zi = transpose(data.imaginary(1:len,frequencyIndex));
    z = 20*log10(sqrt(zr.*zr + zi.*zi));
elseif (strcmp(dataType, 'Phase') == 1)
    zr = transpose(data.real(1:len,frequencyIndex));
    zi = transpose(data.imaginary(1:len,frequencyIndex));
    z = (180 / pi) * atan2(zi, zr);
elseif (strcmp(dataType, 'Amplitude') == 1)
    zr = transpose(data.real(1:len,frequencyIndex));
    zi = transpose(data.imaginary(1:len,frequencyIndex));
    z = sqrt(zr.*zr + zi.*zi);
else
    return;
end
z = reshape(z, [], xAxisWidth);
z(:,2:2:end) = flipud(z(:,2:2:end));
Z = z; % get z values

%% compute frequency
f = data.frequency(1, frequencyIndex); % get frequency
F = f / 1000000; % compute frequency in MHz

%% display data
X = deg2rad(x);
Y = linspace(-pi*0.5, pi*0.5, xAxisWidth); %deg2rad(y);
[X,Y,Z] = sph2cart(X,y,Z.');
% Z=R*sin(Phi);
% X=R*cos(Phi).*cos(Theta);
% Y=R*cos(Phi).*sin(Theta);

figure()
surf(X, Y, Z)
% contour(X, Y, Z)
% mesh(X,Y,Z)

%% annotate plot
title(sprintf('Plot: %s   Index: %d   Frequency: %fMHz ', dataType, frequencyIndex, F))
xlabel("Z")
ylabel("X")
zlabel("Y")
end





