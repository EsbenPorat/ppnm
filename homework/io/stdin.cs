using System;
using static System.Console;
using static System.Math;

public static class stdin{
	public static void Main(){
		char[] delimiters = {' ', '\t','\n'};
		var options = StringSplitOptions.RemoveEmptyEntries;
		for (string line = ReadLine(); line != null; line = ReadLine() ) {
			var words = line.Split(delimiters,options);
			foreach(var word in words){
				double x = double.Parse(word);
				Write($"{x} {Sin(x)} {Cos(x)}\n");
			}
		}
	}
}
