using System;
using static System.Console;
using static System.Math;

public static class epsilon{

	public static void minmax(){
		int i=1; while(i+1>i) {i++;}
		Write("My maximum int is {0}. \n",i);
		int negi=1; while(negi-1<negi) {negi--;}
		Write("My minimum int is {0}. \n",negi);
	}

	public static void machine(){
		double x=1; while(1+x!=1){x/=2;} x*=2;
		Write("My machine epsilon with double precision is {0}. \n",x);
		float y=1f; while((float)(1f+y) != 1f) {y/=2f;} y*=2;
		Write("My machine epsilon with float precision is {0}. \n",y);
	}

	static void sums(){
		int n=1000000;
		double epsilon = Pow(2,-52);
		double tiny = epsilon/2;
		double sumA=0,sumB=0;
		
		sumA+=1; for(int i=0;i<n;i++){sumA+=tiny;}
		Write($"sumA-1 = {sumA-1:e} should be {n*tiny:e} \n");

		for(int i=0;i<n;i++){sumB+=tiny;} sumB+=1;
		Write($"sumB-1 = {sumB-1:e} should be {n*tiny:e} \n");
		Write($"This is due to the fact that epsilon is the smallest number that can be added to 1 and not give 1+epsilon = 1. \n");
	}

	public static bool approx(double a, double b, double tau=1e-9, double epsilon=1e-9){
		if (Abs(a-b)<tau)
			return true;
		else if (Abs(a-b)/(Abs(a)+Abs(b))<epsilon)
			return true;
		else
			return false;
	}

	public static int Main(){
		Write("---------------------------------------------------------------------------------------\n");
		minmax();
		Write("---------------------------------------------------------------------------------------\n");
		machine();
		Write("---------------------------------------------------------------------------------------\n");
		sums();
		Write("---------------------------------------------------------------------------------------\n");
		Write($"If approx works, approx(1,1) should evaluate as True. It evaluates as {approx(1,1)}. \n");
		Write($"If approx works, approx(1,2) should evaluate as False. It evaluates as {approx(1,2)}. \n");
		Write($"If approx works, approx(1000,1001) should evaluate as False. It evaluates as {approx(1000,1001)}. \n");
		Write("---------------------------------------------------------------------------------------\n");
		return 0;
	}
}
