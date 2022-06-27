using System;
using static System.Console;
using static System.Math;

public static class rootfinding{
	public static void Main(){
	        Func<vector,vector> f2 = x => new vector(2*(200*Pow(x[0],3) - 200*x[0]*x[1] + x[0] - 1), 200*(x[1] - Pow(x[0],2)));
	        vector x02 = new double[2] {0,0};
	        vector res2 = roots.NewtonRaphson(f2, x02);
	        WriteLine("\nFinding extremum of Rosenbrock's valley function f(x,y) = (1-x)^2 + 100(y-x^2)^2");
	        WriteLine("Looking for roots of the gradient f'(x,y) = [2*(200*x^3 - 200*x*y + x - 1), 200*(y - x^2)] gives the extremum.");
	        WriteLine("It is found at:");
	        WriteLine($"x = {res2[0]}, y = {res2[1]}\n");
	        WriteLine("The analytical result is (1,1)\n");
	}


}


