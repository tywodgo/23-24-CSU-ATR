dataPath = "C:\Users\ajhgo\Desktop\ATR\DataFile\"; % Complete path to your data
dataFile = "Base_Hor_Vert.txt"; % Name of the data file
xAxis = 'Vertical';
yAxis = 'Horizontal';
xAxisWidth = 41;  % Given by how many data point that were taken for each pass of the x-axis 
frequencyIndex = 96;

fullpath = dataPath + dataFile;
data = ReadCSUATRData(fullpath);

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