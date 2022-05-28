using System;
using static System.Console;
using static System.Random;

public static class linearequations{
	public static void Main(){
		int rows = 10;
		int cols = 10;
		matrix M = new matrix(rows,cols);
		Random rng = new Random();
		for(int i=0; i<rows; i++){
			for(int j=0; j<cols; j++){
			int random = rng.Next(11);
			M[i,j] = random;
			}
		}


		QRGS qrgsM = new QRGS(M);
		matrix invM = qrgsM.inverse();
		matrix invMM = invM * M;

		Write($"--------------------------------Part 1--------------------------------\n");
		Write($"Initial square matrix M:\n");
		M.print();
		Write($"\n");

		Write($"Calculated inverse matrix M^(-1):\n");
		invM.print();
		Write($"\n");

		Write($"M^(-1) * M:\n");
		invMM.print();
		Write($"\n");
	}

}
