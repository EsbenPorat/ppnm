using static System.Math;
using static System.Console;
static public class precision{
	public static int Main(){
		Write($"approx fungerer, hvis approx(1,1) er true. Den er {approx(1,1)} \n");
		Write($"approx fungerer, hvis approx(1,2) er false. Den er {approx(1,2)} \n");
		return 0;
	}
	public static bool approx(double a, double b, double tau=1e-9, double epsilon=1e-9){
		if (Abs(a-b)<tau)
			return true;
		else if (Abs(a-b)/(Abs(a)+Abs(b))<epsilon)
			return true;
		else
			return false;
	}
}	

