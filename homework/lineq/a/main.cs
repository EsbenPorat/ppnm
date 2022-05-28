using System;
using static System.Console;
using static System.Random;

public static class linearequations{
	public static void Main(){
		int rows = 10;
		int cols = 6;
		matrix M = new matrix(rows,cols);
		Random rng = new Random();
		for(int i=0; i<rows; i++){
			for(int j=0; j<cols; j++){
			int random = rng.Next(11);
			M[i,j] = random;
			}
		}


		QRGS qrgsM = new QRGS(M);
		matrix RM = qrgsM.R;
		matrix QM = qrgsM.Q;
		matrix QTQM = qrgsM.transinverse();

		Write($"--------------------------------Part 1--------------------------------\n");
		Write($"Initial tall matrix:\n");
		M.print();
		Write($"\n");

		Write($"Calculated Q matrix:\n");
		QM.print();
		Write($"\n");

		Write($"Calculated R matrix:\n");
		RM.print();
		Write($"\n");

		Write($"Q^T * Q =\n");
		QTQM.print();
		Write($"\n");


// Part two code starts here

		cols = rows;
		vector b = new vector(rows);
		matrix N = new matrix(rows,cols);

		for(int i=0; i<rows; i++){
			for(int j=0; j<cols; j++){
				int random = rng.Next(11);
				N[i,j] = random;
			}
			int randomv = rng.Next(11);
			b[i] = randomv;
		}

		QRGS qrgsN = new QRGS(N);
		matrix RN = qrgsN.R;
		matrix QN = qrgsN.Q;
		vector x = qrgsN.solve(b);
		vector comp = N*x-b;
		
		Write($"--------------------------------Part 2--------------------------------\n");

		Write($"Initial square matrix N:\n");
		N.print();
		Write($"\n");

		Write($"Initial vector b:\n");
		b.print();
		Write($"\n");
		
		Write($"Solution vector x:\n");
		x.print();
		Write($"\n");

		Write($"N*x - b to see accuracy:\n");
		comp.print();
			

	}

}
