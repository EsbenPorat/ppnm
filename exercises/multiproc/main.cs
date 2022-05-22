using static System.Console;
using System.Threading;
public class mult{

	public class data{
		public int start; public int end;
		public double sum;
	}
	
	public static void hsum(object obj){
		data a = (data) obj;
		a.sum = 0;
		for (double i=a.start; i<=a.end; i++){
			a.sum += 1/i;
		}
		Write($"Calculated from {a.start} to {a.end}, got {a.sum} \n");
	}

	public static int Main(){ 
		int max = 100;
		data x1 = new data();
		x1.start = 1; x1.end = max/2;
		data x2 = new data(); 
		x2.start = x1.end + 1; x2.end = max;
		Thread hsum1 = new Thread(hsum);
		Thread hsum2 = new Thread(hsum);
		hsum1.Start(x1);
		hsum2.Start(x2);
		hsum1.Join();
		Write($"The total sum is {x1.sum + x2.sum} \n");
		return 0;
	}
}
