using static System.Math;
public static class epsilonminmax{
	static int Main(){
		int i=1; while(i+1>i) {i++;}
		System.Console.Write("My max int = {0}\n",i);
		int negi=1; while(negi-1<negi) {negi--;}
		System.Console.Write("My min int = {0}\n",negi);
		return 0;
	}
}
