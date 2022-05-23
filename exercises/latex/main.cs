using System;
using static System.Math;
using static System.Console;

public static class latex{

	static double ex(double x) {
		if (x<0) return 1/ex(-x); // takes care of negative case
		if(x>1.0/8) return Pow(ex(x/2),2); // approximation is best near x=0, so we want a small x
						   // the Pow([],2) operation is equivalet to ex(x*2)
		return 1+x*(1+x/2*(1+x/3*(1+x/4*(1+x/5*(1+x/6*(1+x/7*(1+x/8*(1+x/9*(1+x/10)))))))));
	}

	public static int Main(){
		for (double x=-2; x<=2; x+=0.01){
			Write($"{x} {ex(x)} {Exp(x)}\n");
		}
		return 0;
	}
}
