h = 0.5E-3;     % Height - 0.5 mm
epR = 4;        % Relative Perm
c0 = 299792458; % Speed of propgation
f = 10E9;       % Freq. of operation - 10GHz

% Finds width
w = c0 / (2 * f) * sqrt(2 / (epR + 1));
wh = w / h;

% Finds relative effective perm
if (wh < 1)
    p = 0.04.*(1-wh).^2;
else
    p = 0;
end

a = (epR + 1) ./ 2;
b = (epR - 1) ./ 2;
c = 1 ./ sqrt(1 + 12 ./(wh)) + p;
epReff = a + b .* c;

% Finds length
clear a b c
a = 0.412 * h;
b = (epReff + 0.3) * (wh + 0.264);
c = (epReff - 0.258) * (wh + 0.8);
dL = a * b / c;

L = c0 / (2 * f * sqrt(epReff)) - 2 * dL;

% Finds ground plane data
Lg = 6 * h + L;
Wg = 6 * h + w;

% Prints out data
printWH(w,h,wh,L,Wg,Lg,epReff);

% Function to print out data
function printWH(w,h,wh,L,Wg,Lg,epReff)
    fprintf('Height of patch is: %g\n',h);
    fprintf('Width of patch is: %3.4g\n',w);
    fprintf('Width-to-height ratio is: %3.4g\n',wh);
    fprintf('Length of patch is: %3.4g\n',L);
    fprintf('Width of GND plane is: %3.4g\n',Wg);
    fprintf('Length of GND plane is: %3.4g\n',Lg);    
    fprintf('Relative effective Perm. is: %3.5g\n',epReff);
end