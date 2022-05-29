using System;
using static System.Console;
using static System.Math;
using static matrix;
using static vector;
using static System.Random;
using static jacobirot;

public static class eigenvalues{

	public static void Main(){
		int n = 6;
		matrix A = new matrix(n,n);
		matrix V = new matrix(n,n); 
		matrix I = matrix.id(n);
	        Random rnd = new Random();

		for(int i=0;i<n;i++){
			for(int j=0;j<n;j++){
				int random = rnd.Next(10);
				A[i,j]=random;
				A[j,i]=random;
			} 
	        }

		matrix D = A.copy();		
		(D,V) = Cyclic(D,V);

		matrix VTAV = V.transpose() * A * V;
		matrix VDVT = V * D * V.transpose();
		matrix VTV = V.transpose() * V;
		matrix VVT = V * V.transpose();


		Write("The randomly generated matrix, A:\n");			
		A.print();

	        Write("The diagonalized matrix, D:\n");
		D.print();

		Write("The orthogonal matrix of eigenvectors, V:\n");
		V.print();

		
		Write($"Checking whether V^TAV = D, using .approx from matrix class: {D.approx(VTAV)} \n");
		Write($"Checking whether VDV^T = A, using .approx from matrix class: {A.approx(VDVT)} \n");
		Write($"Checking whether VV^T = I, using .approx from matrix class: {I.approx(VVT)} \n");
		Write($"Checking whether V^TV = I, using .approx from matrix class: {I.approx(VTV)} \n");


	}
}
