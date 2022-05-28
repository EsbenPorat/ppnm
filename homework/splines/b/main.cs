using System;
using static System.Math;
using static System.Console;
using static qspline;

public static class splines{

	public static void Main(){			
		double a=0,b=10;
		int N=30;
		double step = (b-a)/(N-1);
		double[] xtable = new double[N];
		double[] ytable = new double[N];
		double[] yderiv = new double[N];
		double[] yinteg = new double[N];
		for(int i=0; i<N; i++){
			xtable[i] = a + i*step;
			ytable[i] = Cos(xtable[i]);
			yderiv[i] = -Sin(xtable[i]);
			yinteg[i] = Sin(xtable[i]);
			Write($"{xtable[i]} {ytable[i]} {yderiv[i]} {yinteg[i]}\n");
		}

		Write("\n\n");

		qspline s = new qspline(xtable,ytable);
		for(double z=a; z<xtable[xtable.Length-1]; z+=step/200){
			Write($"{z} {s.spline(z)} {s.derivative(z)} {s.integral(z)}\n");
		}
	}
}
