using System;
using static System.Console;
using static System.Math;

public class QRGS{
	public matrix Q,R;
	public int m,n;

	public QRGS(matrix A){
		n = A.size1;
		m = A.size2;
		Q = A.copy();
		R = new matrix(m,m);
		for(int i =0; i<m; i++){
			R[i,i]=Q[i].norm();
			Q[i]/=R[i,i];
			for(int j=i+1; j<m; j++){
				R[i,j] = Q[i].dot(Q[j]);
				Q[j] -= Q[i]*R[i,j];
			}
		}
	}	

	public vector solve(vector b){
		matrix Qt = Q.transpose();
		vector x = b.copy();
		x = Qt * x;
		backsub(R,x);
		return x;
	}

	public void backsub(matrix U, vector c){
		for(int i = c.size-1; i>=0; i--){
			double sum = 0;
			for(int j = i+1; j<c.size; j++){
				sum += U[i,j]*c[j];
			}
		c[i] = (c[i] - sum) / U[i,i];
		}
	}

	public matrix transinverse(){
		matrix multtrans = Q.transpose() * Q;
		return multtrans;
	}

	public double determinant(){
		double det = 0;
		for(int i=0; i<m; i++){
			det += R[i,i];
		}
		return det;
	}

	public matrix inverse(){
//		if (n!=m) throw new Exception("Original matrix must be square to be invertible.");
		matrix I = matrix.id(n);
		matrix inv = new matrix(n,n);
		for(int i=0; i<n; i++){
			inv[i] = solve(I[i]);
		}
		return inv;
	}
}
