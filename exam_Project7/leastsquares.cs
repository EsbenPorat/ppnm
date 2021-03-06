using System;

public class leastsquares{
	public static vector lsfit(Func<double,double>[] fs, vector x, vector y, vector dy){
		int n = x.size, m = fs.Length;
		var A = new matrix(n,m); 
		var b = new vector(n); 
		for(int i=0; i<n ; i ++){ 
			b[i] = y[i]/dy[i];
			for(int k=0; k<m; k++){
				 A[i,k] = fs[k](x[i]) / dy[i];
			}
		}
		var qra = new QRGS(A);
		vector c = qra.solve(b);
		return c;
	}
}
