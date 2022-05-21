using static System.Math;
using static System.Console;
using static cmath;
using static complex;
public static class calculations{
	public static int Main(){
	complex a = -1;
	Write($"The value of sqrt(-1) is {sqrt(a)}, manually calculated to 1*i \n");
	Write($"The value of sqrt(i) is {sqrt(I)} , manually calculated to 0.7071 + 0.7071*i \n");
	Write($"The value of e^i is {exp(I)}, manually calculated to 0.540 + 0.841*i \n");
	Write($"The value of e^(i*pi) is {exp(I*PI)}, manually calculated to -1 \n");
	Write($"The value of i^(-i) is {cmath.pow(I,-I)}, manually calculated to 4.180 \n");
	Write($"The value of ln(i) is {cmath.log(I)}, manually calculated to 1.571*i \n");
	Write($"The value of sin(i*pi) is {cmath.sin(I*PI)}, manually calculated to 11.549*i \n");
	return 0;
	}
}
