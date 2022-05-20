using static System.Console;

vec testVectorOne = vec(double 1.0, double 1.5, double 2.0);
vec testVectorTwo = vec(double 2.5, double 3.0, double 3.5);
double testConstant = double 10.0;

vec vectorFirstMultiple = testVectorOne*testConstant;
vec constantFirstMultiple = testConstant*testVectorOne;
vec addition = testVectorOne+testVectorTwo;
vec subtraction = testVectorOne-testVectorTwo;
vec negativeSign = -testVectorOne;

print(string vectorFirstMultiple);
print(string constantFirstMultiple);
print(string addition);
print(string subtraction);
print(string negativeSign);
