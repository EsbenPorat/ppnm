public static class mktable{
	public static void make_table(System.Func<double,double> f, double a, double b, double dx){
		for(double x=a;x<=b;x+=dx)
		System.Console.Write($"{x} | {f(x)}\n");
	}
}
