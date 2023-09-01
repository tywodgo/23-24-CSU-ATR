%% CSUATR Program Data Interpretation

clear all
close all

dataPath = "C:\Users\Jason\Documents\SeniorDesign\csuatr\Matlab Code\Data\";
dataFile = "11_18_2020_Elevation_Azimuth.txt";

fullpath = dataPath + dataFile;
data = ReadCSUATRData(fullpath);

xAxis = 'Azimuth';
yAxis = 'Elevation';
xAxisWidth = 46;
PlotData(data, 'Amplitude', xAxis, yAxis, xAxisWidth, 1)
% PlotData(data, 'Amplitude', xAxis, yAxis, xAxisWidth, 4)
% PlotData(data, 'Amplitude', xAxis, yAxis, xAxisWidth, 7)
PlotData(data, 'Magnitude', xAxis, yAxis, xAxisWidth, 1)
% PlotData(data, 'Magnitude', xAxis, yAxis, xAxisWidth, 4)
% PlotData(data, 'Magnitude', xAxis, yAxis, xAxisWidth, 7)
% PlotData(data, 'Real', xAxis, yAxis, xAxisWidth, 1)
% PlotData(data, 'Real', xAxis, yAxis, xAxisWidth, 4)
% PlotData(data, 'Real', xAxis, yAxis, xAxisWidth, 7)
% PlotData(data, 'Imaginary', xAxis, yAxis, xAxisWidth, 1)
% PlotData(data, 'Imaginary', xAxis, yAxis, xAxisWidth, 4)
% PlotData(data, 'Imaginary', xAxis, yAxis, xAxisWidth, 7)


%% Retrieve Data
function data = ReadCSUATRData(filename)
fprintf('Reading file: %s\n', filename)
% type(filename)
% data structure
data.polarization = [];
data.vertical = [];
data.horizontal = [];
data.depth = [];
data.azimuth = [];
data.elevation = [];
data.power = [];
data.avgpoints = [];
data.mode = [];
data.frequency = [[]];
data.real = [[]];
data.imag = [[]];
data.mag = [[]];
data.phase = [[]];
% read file
fileID = fopen(filename,'r'); % opening file
count = 0;
tline = fgetl(fileID); % get first data point
while ischar(tline)
%     fprintf("line: %d, value: %s\n", count, tline)
    % interpret data here (start)
%     index = (count - rem(count, 6))/6 + 1; % not sure if this will be used
    if (rem(count, 6) == 0)
        values = textscan(tline, "%f %f %f %f %f %f %f %d %s");
        data.polarization = [data.polarization, values{1}];
        data.vertical = [data.vertical, values{2}];
        data.horizontal = [data.horizontal, values{3}];
        data.depth = [data.depth, values{4}];
        data.azimuth = [data.azimuth, values{5}];
        data.elevation = [data.elevation, values{6}];
        data.power = [data.power, values{7}];
        data.avgpoints = [data.avgpoints, values{8}];
        data.mode = [data.mode, values{9}];
    elseif (rem(count, 6) == 1)
        values = transpose(cell2mat(textscan(tline, "%f")));
        data.frequency = [data.frequency; values];
    elseif (rem(count, 6) == 2)
        values = transpose(cell2mat(textscan(tline, "%f")));
        data.real = [data.real; values];
    elseif (rem(count, 6) == 3)
        values = transpose(cell2mat(textscan(tline, "%f")));
        data.imag = [data.imag; values];
    elseif (rem(count, 6) == 4)
        values = transpose(cell2mat(textscan(tline, "%f")));
        data.mag = [data.mag; values];  
    elseif (rem(count, 6) == 5)
        values = transpose(cell2mat(textscan(tline, "%f")));
        data.phase = [data.phase; values];
    end
    % interpret data here (end)
    tline = fgetl(fileID); % get next data point
    count = count + 1;
end
fclose(fileID); % closing file
end


%% Plot Data
function PlotData(data, zAxis, xAxis, yAxis, xAxisWidth, frequencyIndex)
%% compensate
len = length(data.mode) - rem(length(data.mode), xAxisWidth);

%% compute x axis
x = [];
xLabel = ' ';
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
X = transpose(x(:,1));

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
Y = y(1,:);

%% compute z matrix
z = [];
if (strcmp(zAxis, 'Real') == 1)
    z = transpose(data.real(1:len,frequencyIndex));
elseif (strcmp(zAxis, 'Imaginary') == 1)
    z = transpose(data.imag(1:len,frequencyIndex));
elseif (strcmp(zAxis, 'Magnitude') == 1)
    z = transpose(data.mag(1:len,frequencyIndex));
elseif (strcmp(zAxis, 'Phase') == 1)
    z = transpose(data.phase(1:len,frequencyIndex));
elseif (strcmp(zAxis, 'Amplitude') == 1)
    zr = transpose(data.real(1:len,frequencyIndex));
    zi = transpose(data.imag(1:len,frequencyIndex));
    z = sqrt(zr.*zr + zi.*zi);
else
    return;
end
z = reshape(z, [], xAxisWidth);
z(:,2:2:end) = flipud(z(:,2:2:end));
Z = z;

%% compute frequency
f = data.frequency(1, frequencyIndex);
F = f / 1000000;

%% display data
X = deg2rad(x);
% Y = linspace(-pi*0.5, pi*0.8, 46); %deg2rad(y);
Y = linspace(-pi*0.5, pi*0.5, 46); %deg2rad(y);
[X,Y,Z] = sph2cart(X,Y,Z);
% Z=R*sin(Phi);
% X=R*cos(Phi).*cos(Theta);
% Y=R*cos(Phi).*sin(Theta);

figure()
surf(X, Y, Z, 'edgecolor','none')
% contour(X, Y, Z)
% mesh(X,Y,Z)

%% annotate plot
title(sprintf('Plot: %s   Index: %d   Frequency: %fMHz ', zAxis, frequencyIndex, F))
xlabel("Z")
ylabel("X")
zlabel("Y")
% xlabel(xLabel)
% ylabel(yLabel)
% zlabel(zAxis)
end







%% Obsolete
function PlotMagnitudeAzimuthElevation(data, frequencyIndex, width)
len = length(data.azimuth) - rem(length(data.azimuth), width); % compensate
% get x, y, and z data points
x = data.azimuth(1:len);
x = reshape(x, width, []);
% disp(x)
X = transpose(x(:,1));
% disp(X)
y = data.elevation(1:len);
y = reshape(y, width, []);
% disp(y)
Y = y(1,:);
% disp(Y)
z = transpose(data.mag(1:len,frequencyIndex));
Z = reshape(z, [], width);
% disp(Z)

% display data
figure()
% surface(X, Y, Z)
contour(X, Y, Z)
% contour3(X, Y, Z)
figure()
surf(X, Y, Z)
% surface(X, Y, Z)
% polarplot3d(Z)
end






