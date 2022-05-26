using System;
using static System.Math;
using static System.Console;

public static class plots{
	static double erf(double x){	/// single precision error function (Abramowitz and Stegun, from Wikipedia)
		if(x<0) return -erf(-x);
		double[] a={0.254829592,-0.284496736,1.421413741,-1.453152027,1.061405429};
		double t=1/(1+0.3275911*x);
		double sum=t*(a[0]+t*(a[1]+t*(a[2]+t*(a[3]+t*a[4]))));
		return 1-sum*Exp(-x*x);
	} 

	public static void Main(){
		for (double i=0; i<3.5; i+=0.02) {
			Write($"{i} {erf(i)} \n");
		}
		
	}

}

