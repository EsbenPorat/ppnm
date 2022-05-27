using System;
using static System.Math;
using static System.Console;
using static arraygen;

public static class splines{

	public static int binsearch(double[] x, double z){ // locates the interval for z by bisection
		if(!(x[0]<=z && z<=x[x.Length-1])) throw new Exception("binsearch: bad z");
		int i=0, j=x.Length-1;
		while(j-i>1){
			int mid=(i+j)/2;
			if(z>x[mid]) i=mid; else j=mid;
			}
		return i;
	}

	public static double linterp(double[] x, double[] y, double z){
	        int i=binsearch(x,z);
	        double dx=x[i+1]-x[i]; if(!(dx>0)) throw new Exception("x[i+1] - x[i] < 0!");
	        double dy=y[i+1]-y[i];
	        return y[i]+dy/dx*(z-x[i]);
        }

	public static double linterpInteg(double[] x, double[] y, double z){
		double dxj = 0;
		double dyj = 0;
		double Ival = 0;
		int i = binsearch(x,z);
		for (int j = 0; j < i; j++){
			dxj = x[j+1] - x[j];
			dyj = y[j+1] - y[j];
			Ival += y[j]*dxj + dyj*dxj * 0.5;	// adds area under segment
		}
		double dxz = z - x[i];
		double dxi = x[i+1] - x[i];
		double dyi = y[i+1] - y[i];
		Ival +=  y[i]*dxz + dyi/dxi * dxz * dxz * 0.5;
		return Ival;
	}




	public static void Main(string[] args){			
		(double[] x, double[] y) = array2D(args);	//x=0:0.5:6.5,y=sin(x)
			
		for(double z = 0; z<=6.5; z+=0.01){
			double interp = linterp(x,y,z); 
			double integ = linterpInteg(x,y,z) - 1;
			Write($"{z} {interp} {integ} \n");
		}
	
	
	
	
	}
}
