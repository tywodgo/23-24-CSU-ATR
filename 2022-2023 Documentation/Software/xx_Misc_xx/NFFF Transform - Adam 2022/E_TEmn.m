clear Ex Ey
close all
%% TEmn Plotter

% Choose TEmn mode
m = 1;
n = 1;

% Waveguide Dimensions
a = 0.084;    % Width of waveguide
b = 0.06;    % Height of waveguide
N = 41;     % Number of data points along each axis
f = 10E9;    % Frequency

% Constants
c0 = 3E8;    % Speed of propagaion
mu0 = pi*4E-7;      % Freespace permeability
ep0 = 8.8542E-12;   % Freespace permittivity
omega = 2*pi*f;     % Angular freq
beta = omega * sqrt(mu0*ep0);   % Wavenumber
betaX = m*pi./a;
betaY = n*pi./b;
kSqr = betaX.^2 + betaY.^2;
ExyCoeff = j*omega*mu0/kSqr;

% Determines cutoff frequency of waveguide
cutoffCoeff = sqrt((m./a).^2 + (n./b).^2);
cutoffFrequency = c0./2.*cutoffCoeff

x = linspace(0,a,N);
y = linspace(0,b,N);
z = 0;
[X,Y] = meshgrid(x,y);

% Finds X and Y components of E field
% Note that this does not have any other variable coeff, that is because
% they only affect magnitude. Where here we mainly care direction.
Ex = cos(betaX .* X) .* sin(betaY .* Y) .* exp(-j.*beta.*z);
Ey = -sin(betaX .* X) .* cos(betaY .* Y) .* exp(-j.*beta.*z);

% Plots front view
quiver(X,Y,real(Ex),real(Ey),'r');
xlabel('Width of waveguide - a (m)');
ylabel('Height of waveguide- b (m)');
title(['E-field of TE',num2str(m),num2str(n),' mode']);
legend('E-field');

% If needed, here are the full complex formulas
%{
Ex = ExyCoeff .* betaY .* cos(betaX .* X) .* sin(betaY .* Y);
Ey = -ExyCoeff .* betaX .* sin(betaX .* X) .* cos(betaY .* Y);
%quiver(X,Y,real(Ex),real(Ey),'r');
%}
