using System;
using static System.Console;
using static System.Math;

public class qspline {
	public double[] x, y, b, p, c, dx;


	public static int binsearch(double[] x, double z){/* locates the interval for z by bisection */ 
		if(!(x[0]<=z && z<=x[x.Length-1])) throw new Exception("binsearch: bad z");
		int i=0, j=x.Length-1;
		while(j-i>1){
			int mid=(i+j)/2;
			if(z>x[mid]) i=mid;
			else j=mid;
		}
		return i;
	}

	public qspline(double[] xs, double[] ys){
		int N = xs.Length;
		x = new double[N];
		y = new double[N];
		p = new double[N-1];		// N-1 elements
		c = new double[N-1];
		b = new double[N-1];
		dx = new double[N-1];
		for (int k=0; k<N; k++){
			x[k] = xs[k];
			y[k] = ys[k];
		}

		for(int i=0; i<N-1; i++){		// N-2 is max index from N-1 elements
			dx[i] = x[i+1] - x[i];
			p[i] =  (y[i+1] - y[i])/dx[i];
		}
		
		c[0] = 0;
		for(int i=0; i<N-2; i++){ 
			c[i+1] = (p[i+1] - p[i] - c[i]*dx[i])/dx[i+1];
		}
		c[N-2] = c[N-2]/2;
		for(int j=N-3; j>=0; j--){
			c[j] = (p[j+1] - p[j] - c[j+1]*dx[j+1])/dx[j];
		}
		for(int h=0; h<N-1; h++){
			b[h] = p[h] -c[h]*dx[h];
		}
	}

	public double spline(double z){
		int idx = binsearch(x,z);
		return y[idx] + b[idx]*(z-x[idx]) + c[idx]*(z - x[idx])*(z - x[idx]);
	}
		
	public double derivative(double z){
		int idx = binsearch(x,z);
		return b[idx] + 2 * c[idx] * (z - x[idx]);

	}

	public double integral(double z){
		int idx = binsearch(x,z);
		double dxz = z - x[idx];
		double Ival = 0;
		for(int j = 0; j<idx; j++){ //integrals for whole splines
			Ival += y[j]*dx[j] + b[j]*dx[j]*dx[j]/2 + c[j]*dx[j]*dx[j]*dx[j]/3;
		}
					  // for z between data points
		Ival += y[idx]*dxz + b[idx]*dxz*dxz/2 + c[idx]*dxz*dxz*dxz/3;
		return Ival;
	}




}
