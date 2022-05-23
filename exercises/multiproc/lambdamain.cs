using static System.Console;
using System.Threading;
public class mult{

	public static Thread lambdathread(int max, int subs, int current) {
		var t = new Thread(() => sumdiv(max, subs, current));
		t.Start();
		return t;
	}
	
	public static double sumdiv(int a, int b, int c){ //a=max, b=subdivs, c=current subdiv(0->b-1)
		double sum = 0;
		for (double i=1+c*(a-a%b)/b; i<=(c+1)*(a-a%b)/b; i++){
			sum += 1/i;
		}
		Write($"Sum from subdivision number {c+1} is {sum}. \n");
		return sum;
	}

	public static int Main(){ 
		int max = 1000000, subs = 6; 
		for (int i=0; i<subs; i++) {
			lambdathread(max,subs,i);
		}
		Write("The total sum is not calculated :( \n");
		return 0;
	}
}
