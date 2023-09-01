%% 2022/2023 CSU Antenna Test Range Near-Field to Far-Field Planar Transform
%
% Near Field to Far Field Transformation
% Created by: Adam Hulse and Parker Segelhorst
% Last Modified: 10/11/2022
%
% NFFF transform works on taking freq. f and computes the far field at
% radius r. Data collected from scan will be parsed into the X, Y, and Z
% components.

%% Setting Up Conditions
% xBound and yBound are the limit from the scan from the origin (such as
% running a scan from horizontal -20cm to 20cm, set xLim to 20)
xLim = 20;
yLim = 20;
dataPath = "C:\Users\ajhgo\Desktop\ATR\DataFile\"; % Complete path to your data
dataFile = "Base_Hor_Vert.txt"; % Name of the data file
frequencyIndex = 96;    % [75,117] ~ [8GHz,12GHz]

xAxisWidth = xLim * 2 + 1;  % Given by how many data point that were taken for each pass of the x-axis 

fullpath = dataPath + dataFile;
data = ReadCSUATRData(fullpath);

%% Transform
f = data.frequency(1,frequencyIndex);            % Frequency from above
omega = 2*pi*f;     % Angluar frequency
r = 1000;           % Radius of far field -> 1km
c0 = 299792458;     % Speed of propgation
k0 = omega./c0;    % Phase coefficient (beta0)
nh = [0,0,1];       % Unit normal vector to suface S
coeff = exp(-i.*k0.*r) ./ (4.*pi*r);    % Coefficient in front of integral

X = -xLim:1:xLim;            % X cords of scan
Y = -yLim:1:yLim;            % Y cords of scan
Z = zeros(1,length(X)); % Z cords of scan (depth from reciever)

% Sets the E near field from data points into an NxN matrix of its real and
% imaginary parts
for m = 1:xAxisWidth
    for n = 1:xAxisWidth
        E_NF(m,n) = complex( data.real(n + (m-1).*xAxisWidth,frequencyIndex) + ...
            data.imaginary(n + (m-1).*xAxisWidth,frequencyIndex) );
    end
end



%% Scan Data File
function data = ReadCSUATRData(filename)
    %fprintf('Reading file: %s\n', filename)
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
%% Dot Product
%Calculates the dot product of two vectors a and b
function result = dotProduct(a,b)
    result = 0;
    for i=1:length(a)
        result = result + (i).*b(i);
    end
end

%% Cross Product
% Computes cross product of two vectors a and b
% a and b must be length 3
function [xCom,yCom,zCom] = crossProduct(a,b)
    xCom = a(2).*b(3) - a(3).*b(2);
    yCom = a(3).*b(1) - a(1).*b(3);
    zCom = a(1).*b(2) - a(2).*b(1);
end