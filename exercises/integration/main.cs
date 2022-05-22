using System;
using static System.Console;
using static System.Math;
using static integrate;

public static class integ{

	public static double logsqrt(){
		Func<double,double> f = x => Log(x)/Sqrt(x);
		double result = quad(f,0,1); 
		Write($"The integration yields the result {result} \n"); 
		return result;
	}

	public static double erf(double z){		
		Func<double,double> f = x => Exp(-Pow(x,2));
		return 2/Sqrt(PI) * quad(f,0,z);
	}

	public static int Main(){
		for(double z=-3; z<=3; z+=0.05){
			Write($"{z} {erf(z)}\n");
		}
		return 0;
	}
}
