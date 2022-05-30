using System;
using static System.Console;
using static System.Math;
using static cmath;

public static class plots{

	public static void Main(){
		for(double i=-5.1; i<=5.1; i+=0.1){
			for(double j=-5.1; j<=5.1; j+=0.1){
				complex z = new complex(i,j);
				complex Gamma = GammaC(z);
				double absGamma = abs(Gamma);
				Write($"{z.Re} {z.Im} {absGamma}\n");
			}
		}
		Write("\n\n");
		Write("Absolute value of complex Gamma-function plotted in pyxplot as 3dgamma.pyxplot.png. \n");
	}
	

	public static complex GammaC(complex z){
		if(abs(z)<0) return PI/sin(PI*z)/GammaC(1-z);
		if(abs(z)<9) return GammaC(z+1)/z;
		complex lnGammaC=z*log(z+1/(12*z-1/z/10))-z+log(2*PI/z)/2;
		return exp(lnGammaC);
	}

}
