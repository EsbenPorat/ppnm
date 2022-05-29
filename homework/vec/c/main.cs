using System;
using static System.Console;
using static System.Random;
using static vec;

public static class vechomework{
	public static void Main(){

		int N = 400000;		// amount of random vectors to test on
		vec v1 = new vec(1, 1, 1);	// two test vectors to be adjusted
		vec v2 = new vec(1, 1, 1);
		Random rng = new Random();	// to decide the first vector's indices
		Write($"\nTesting {N} different sets of vectors each with indices equal to a / b, where both are random integers from 1 to 10.. \n");

		for(int i=0; i<N; i++){ 
			v1.x = (double)rng.Next(1,10)/rng.Next(1,10); 
			v1.y = (double)rng.Next(1,10)/rng.Next(1,10); 
			v1.z = (double)rng.Next(1,10)/rng.Next(1,10);
			v2.x = (double)rng.Next(1,10)/rng.Next(1,10); 
			v2.y = (double)rng.Next(1,10)/rng.Next(1,10); 
			v2.z = (double)rng.Next(1,10)/rng.Next(1,10);
			if(approx(v1,v2)){
				Write($"-------------Test # {i}-------------------\n");
				Write($"Test says these two vectors are approximately identical. v1 is:\n");
				v1.print();
				Write($"And v2 is:\n");
				v2.print();
				Write($"---------------------------------------------\n");
			}
		}

	}
}
