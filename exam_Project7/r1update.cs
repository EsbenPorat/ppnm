using System;
using static System.Console;
using System.Collections.Generic;
using static System.Math;

public static class r1update{
	public static matrix AMatrix(matrix D, vector u, double s){ // Generates the matrix A according to the project description
		int N = D.size1;
		matrix A = new matrix(N,N);
		matrix U = new matrix(N,N);
		for(int i=0;i<N;i++){
			for(int j=0;j<N;j++){
				U[i,j]=u[i]*u[j];
			}
		}
		A = D + s*U;
		return A;		
	}

	public static (matrix, vector) IneqSort(matrix D, vector u){
		int N = D.size1;
		matrix Dsorting = new matrix(N,N);
		vector usorting = new vector(N);
		
		var recorded_mins = new HashSet<int>(); // records indexes that have been used as smallest value
		for(int i=0; i<N; i++){
			double min_val = Double.PositiveInfinity;
			int min_index = 0;
			for(int j=0; j<N; j++){
				if(D[j,j]<= min_val && !recorded_mins.Contains(j)){
					min_val = D[j,j];
					min_index = j;
				}
			}

			recorded_mins.Add(min_index);

			Dsorting[i,i] = D[min_index,min_index];
			usorting[i] = u[min_index];
		}
		
		return (Dsorting, usorting);
	}


	public static vector EigenSecularEQ(matrix D, vector u, double s){
		(D, u) = IneqSort(D,u);
		int N = D.size1;
		vector eigenvals = new vector(N);
		
		for(int i=0; i<N; i++){
			//Scalar secular equation, for one particular solution
			Func<vector,vector> f = eigenfinder => {
				vector result = new vector(1);
				double sum = 1;
				for(int j=0; j<N; j++){
					if (u[j] != 0 && D[j,j]-eigenfinder[0] !=0){
						sum += s*u[j]*u[j]/(D[j,j]-eigenfinder[0]);
					}
				}
				result[0] = sum;
				return result;
			};
			
			//Sigma is arbitrarily set to 1 here, can always adjust u*u^T to get sigma = 1 anyways.
			//We make our initial guess based on the inequality pertaining to the eigenvalues and the D matrix diagonal values,
			//as is explained in the book chapter. We choose the halfway point between the bounding values for each eigenvalue.
			var x0 = new vector(1);

			if (i == N-1){
				double inner_product = u.dot(u);
				x0[0] = (2*D[N-1, N-1] + s * inner_product)/2;
			}
			else {
				x0[0] = (D[i,i]+D[i+1,i+1])/2;
			}

			var eigenval = roots.NewtonRaphson(f,x0);
			eigenvals[i] = eigenval[0];
		}
		return eigenvals;	
	}
}
