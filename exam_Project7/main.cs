using System;
using System.Diagnostics;
using static System.Console;
using static System.Random;
using System.IO;
using static vector;
using static matrix;
using static jacobirot;
using static roots;
using static r1update;
using static leastsquares;


static class ExamQuestionA{

	public static void Main(){
		ExampleCase();
		TimingTest();
	}

	public static void ExampleCase(){
		//Constructing the D matrix, with diagonal elements between 0 and 100
		Random rng = new Random();
		int n = 8;
		matrix D = new matrix(n,n);
		for (int i=0; i<n; i++){
			D[i,i] = rng.Next(101);
		}

		//Constructing the u vector with elements also between 0 and 100
		vector u = new vector(n);
		for (int i=0; i<n; i++){
			u[i] = rng.Next(21);
		}

		//Creating the A matrix of interest
		double sigma = 1;
		matrix A = AMatrix(D,u,sigma);

		//Finding the eigenvalues using the scalar secular equation
		vector lambda = EigenSecularEQ(D,u,sigma);

		//Finding the eigenvalues using the Jacobi algorithm
		matrix V = new matrix(n,n);
		matrix AJacobi = A.copy();
		(AJacobi,V) = Cyclic(AJacobi,V);
		vector lambdaJacobi = new vector(n);
		for (int i=0; i<n; i++){
			lambdaJacobi[i] = AJacobi[i,i];
		}		

		//Text for print-out
		Write("---Exam project #7: Symmetric rank-1 update of a size-n symmetric eigenvalue problem.---\n");

		Write("The random diagonal matrix, D:");
		D.print();
		Write("\n");

		Write("The random vector, u:\n");
		u.print();
		Write("\n");

		Write("The resulting matrix to be diagonalized, A:");
		A.print();
		Write("\n");

		Write("The eigenvalues according to the roots of the scalar secular equation:\n");
		lambda.print();
		Write("\n");

		Write("The eigenvalues according to the Jacobi algorithm:\n");
		lambdaJacobi.print();
		Write("\n");

	}

	public static void TimingTest(){
		int n_max = 200; double sigma = 1;
		Random rngT = new Random();

		//We start with N=2 and end at N=200, so we get 199 (n_max-1) cases
		double[] x, tJacobi, tSecularEQ, dy;
		x = new double[n_max-1];
		dy = new double[n_max-1];
		tJacobi = new double[n_max-1];
		tSecularEQ = new double[n_max-1];


		using (StreamWriter outfile = new StreamWriter($"timedata.txt")){
			// Runs through sizes n = 2 to n = 200
			for (int i=0; i<=n_max-2; i++){
				int N = i+2;
				
				//Constructing D and u for size N 
				//Values are ints up to 1000 to account for larger N compared to test case
				matrix D = new matrix(N,N);
				for (int j=0; j<N; j++){
					D[j,j] = rngT.Next(1001);
				}
				vector u = new vector(N);
				for (int j=0; j<N; j++){
					u[j] = rngT.Next(1001);
				}
				
				//Matrixes needed for Jacobi algorithm
				matrix V = new matrix(N,N);
				matrix U = new matrix(N,N);
				for(int j=0;j<N;j++){
					for(int k=0;k<N;k++){
						U[j,k]=u[j]*u[k];
					}
				}
				matrix AJ = D + sigma*U;
	
				//Timing tests, Jacobi first
				Stopwatch stopwatchJ = new Stopwatch();
				stopwatchJ.Start();
				Cyclic(AJ,V);
				stopwatchJ.Stop();
				double tJ = stopwatchJ.ElapsedMilliseconds;
				tJacobi[i] = tJ;
	
				//Then using scalar secular equation
				Stopwatch stopwatchR1 = new Stopwatch();
				stopwatchR1.Start();
				EigenSecularEQ(D,u,sigma);
				stopwatchR1.Stop();
				double tSE = stopwatchR1.ElapsedMilliseconds;
				tSecularEQ[i] = tSE;

				x[i] = N;
				dy[i] = 1e-4;
				//Write the values to timedata.txt
				outfile.WriteLine($"{N} {tJ} {tSE}");
				
			}	
		}	
		
		var fs_r1 = new Func<double,double>[] {z => 1, z => z, z => z*z};
		double[] cs_r1;
		cs_r1 = lsfit(fs_r1,x,tSecularEQ,dy);

		var fs_J = new Func<double,double>[] {z => 1, z => z, z => z*z, z => z*z*z};
		double[] cs_J;
		cs_J = lsfit(fs_J,x,tJacobi,dy);

		
		using (var outfile = new System.IO.StreamWriter($"fitvals.txt")){
			for (double X = 1; X < n_max; X += 0.1){
				double y_r1 = 0;
				for (int i = 0; i < fs_r1.Length; i++){
					y_r1 += cs_r1[i] * fs_r1[i](X);
				}	
				double y_J = 0;
				for (int i = 0; i < fs_J.Length; i++){
					y_J += cs_J[i] * fs_J[i](X);
				}
				outfile.WriteLine($"{X}\t{y_J}\t{y_r1}");
			}
		}
	}
}
