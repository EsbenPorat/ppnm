using System;
using static System.Console;
using static System.Math;

public static class cmdline{
	public static void Main(string[] args){
		foreach(var arg in args){
			double x = double.Parse(arg);
			Write($"{x} {Sin(x)} {Cos(x)}\n");
		}
	}
}
