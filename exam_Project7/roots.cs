using System;
using static System.Math;


public static class roots{

	// Calculates the Jacobian numerically as per the book's chapter's guidelines
	public static matrix calcJacobian(Func<vector,vector> f, vector x){
		int N = x.size;
		matrix Jacobian = new matrix(N,N);
		vector y = f(x);	
		for (int i=0; i<N; i++){
			double dx = Abs(x[i]) * Pow(2,-26);
			vector x_new = x.copy();
			x_new[i] += dx;
			
			vector dy = f(x_new) - y;
			for (int j=0; j<N; j++){
				Jacobian[j,i] = dy[j] / dx;
			}
		}	
		return Jacobian;
	}

	//Newton-Raphson method implementation, also according to the chapter guidelines
	public static vector NewtonRaphson(Func<vector,vector> f, vector x0, int max=1000, double eps=1e-5){
		vector x = x0.copy();
		for (int i=0; i<x.size; i++){
			if(x[i] == 0){
				x[i] = 1e-5;
			}
		}
		
		bool converged = false;
		
		for (int i=0; i<max; i++){
			matrix J = calcJacobian(f,x);
			QRGS JDecomp = new QRGS(J);
			vector NR_step = JDecomp.solve(-f(x));
			
			double stepsize = 1;
			do{stepsize /= 2;}
			while(f(x + stepsize*NR_step).norm() > (1-stepsize/2)*f(x).norm() & stepsize > 1.0/32);
			
			x += stepsize*NR_step;

			if(f(x).norm() < eps){
				converged = true;
				break;
			}
			
			
		}
				
		return x;
	}
}
