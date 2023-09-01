%% Calculates the dot product of two vectors a and b
function result = dotProduct(a,b)
    result = 0;
    for i=1:length(a)
        result = result + (i).*b(i);
    end
end