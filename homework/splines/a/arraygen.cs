using System;
using static System.Console;
using static System.Math;
using System.IO;

public class arraygen{
	public static (double[] x, double[] y) array2D(string[] args){
	        string infile = null;
		foreach(var arg in args){
			var words = arg.Split(':');
		        
			if(words[0]=="-input"){
				 infile=words[1];
			}
		        else {
				Write("Use -input:[inputfile] as an argument!");
			}
		}

		int i = 0;
		double[] x1 = new double[1000];
		double[] y1 = new double[1000];
		var instream =new StreamReader(infile);
	        for(string line=instream.ReadLine();line!=null;line=instream.ReadLine()){
			string[] numbers = line.Split(' ','\t',',');
	                x1[i] = double.Parse(numbers[0]);
	                y1[i] = double.Parse(numbers[1]);
			i++;
		}
		double[] x = new double[i];
		double[] y = new double[i];
		for(int j=0; j<x.Length; j++){
			x[j] = x1[j];
			y[j] = y1[j];
		}
		
	        instream.Close();
		return (x,y);
	}
}
