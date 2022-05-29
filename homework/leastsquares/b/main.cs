using System;
using System.Linq;
using static System.Console;
using static System.Math;
using static lsquares;

public static class leastsquares{
	public static void Main(){
		var fs = new Func<double,double>[] { z => 1.0, z => z, z => z*z}; // linear comb. of these are used for fitting
		var fslog = new Func<double,double>[] { z => 1.0, z => z}; // for log-fit

		double[] t = {1,2,3,4,6,9,10,13,15};			// time in days
		double[] y = {117,100,88,72,53,29.5,25.2,15.2,11.1};	// activity(t)
		double[] dy = {5,5,5,5,5,5,1,1,1,1};			// uncertainty(y)
		double[] ylog = new double[y.Length];
		double[] dylog = new double[dy.Length];
		
		for(int i=0; i<t.Length; i++){
			Write($"{t[i]} {y[i]} {dy[i]} \n");		// writes data points with errors for plot
		}

		Write($"\n\n");

		for(int i=0; i<t.Length; i++){
			ylog[i] = Log(y[i]);
			dylog[i] = dy[i]/y[i];
			Write($"{t[i]} {ylog[i]} {dylog[i]} \n");	// for log plot
		}

		(vector c, matrix S) = lsfit(fs,t,y,dy);		// returns solution coefficients c for reg plot
		(vector clog, matrix Slog) = lsfit(fslog,t,ylog,dylog);	// returns solution coefficients c for log plot

		Write($"\n\n");
		
		for(double x = 0; x<t.Last(); x+=t.Last()/1000){	// writes fit out for x=0 to t.max
			double yfit = 0;
			for(int j=0; j<fs.Length; j++){			// adds contribution from each fitting function
				yfit += c[j]*fs[j](x);
			}
			Write($"{x} {yfit} \n");
		}

		Write($"\n\n");
		
		for(double x = 0; x<t.Last(); x+=t.Last()/1000){		// writes fit out for x=0 to t.max
			double yfit = 0;
			for(int j=0; j<fslog.Length; j++){			// adds contribution from each fitting function
				yfit += clog[j]*fslog[j](x);
			}
			Write($"{x} {yfit} \n");
		}

		Write($"\n\n");
		double t12 = -Log(2.0)/clog[1];
		double t12var = Sqrt(Slog[1,1]);
		Write($"The calculated half-life is ln(2) divided by the linear coefficient of the log plot fit. \n");
		Write($"It is {t12} days, and the current value is about 3.6 days.\n");
		Write($"The calculated error is the 1,1 index of the covariance matrix, which is +-{t12var*t12} days.\n");
		Write($"Which means the current value is *not* within the uncertainties of our fit!\n");
		Write("\n");
	}


}
