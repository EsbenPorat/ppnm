using static System.Math;
public static class epsilonsums{
	static int Main(){
		int n=1000000;
		double epsilon = System.Math.Pow(2,-52);
		double tiny = epsilon/2;
		double sumA=0,sumB=0;
		
		sumA+=1; for(int i=0;i<n;i++){sumA+=tiny;}
		System.Console.Write($"sumA-1 = {sumA-1:e} should be {n*tiny:e} \n");

		for(int i=0;i<n;i++){sumB+=tiny;} sumB+=1;
		System.Console.Write($"sumB-1 = {sumB-1:e} should be {n*tiny:e} \n");
		return 0;
	}
}
