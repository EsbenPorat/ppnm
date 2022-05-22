using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static ode;

public static class odeint{
	public static int Main(){
	double b=0.25, c=5;
	Func<double,vector,vector> f = delegate(double t, vector y){
		double theta = y[0]; double omega = y[1];
		return new vector(omega,-b*omega -c*Sin(theta));
	};
	double start = 0, end = 10;
	vector ystart = new vector(PI-0.1,0.0);
	var xs = new List<double>();
	var ys = new List<vector>();
	vector ylist = ivp(f,start,ystart,end,xs,ys);

	for (int i = 0; i<xs.Count; i++){
		Write($"{xs[i]} {ys[i][0]} {ys[i][1]} \n");
	}
	return 0;
	}



}
