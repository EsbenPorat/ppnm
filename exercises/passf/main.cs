using System;
using static System.Console;
using static System.Math;
using static mktable;
public static class passf{
	public static int Main(){ 
		double a = PI/8, b = 2*PI, dx = PI/8, k = 1; 
		Func<double,double> f = delegate(double x){return Sin(k*x);}; 
		for (int i=1; i<=3; i++){
			k = i;
			Write($"\n Table of f(x) = sin({k}*x) \n");
			make_table(f,a,b,dx);
		}
		return 0;
	}
}
