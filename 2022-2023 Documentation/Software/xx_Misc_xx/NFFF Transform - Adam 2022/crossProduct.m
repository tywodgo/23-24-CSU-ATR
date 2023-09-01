% Computes cross product of two vectors a and b
% a and b must be length 3

function [xCom,yCom,zCom] = crossProduct(a,b)
    xCom = a(2).*b(3) - a(3).*b(2);
    yCom = a(3).*b(1) - a(1).*b(3);
    zCom = a(1).*b(2) - a(2).*b(1);
end