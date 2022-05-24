using static System.Console;
using static vec;

public static class vechomework{
	public static void Main(){
	// testvars and printing them
		vec v1 = new vec(1.0, 1.0, 0.0);
		vec v2 = new vec(0.0, 1.0, 1.0);
		double c = 10.0;

		Write("Part A:\n");
		Write("------------------------------ \n");
		v1.print("v1 = ");
		v2.print("v2 = ");
		Write($"Constant c = {c} \n");
		Write("-------\n");
		
		vec vecMul = v1*c;
		vec conMul = c*v1;
		vec add = v1+v2;
		vec sub = v1-v2;
		vec negSign = -v1;
		
		vecMul.print("v1 * c = ");
		conMul.print("c * v1 = ");
		add.print("v1 + v2 = ");
		sub.print("v1 - v2 = ");
		negSign.print("-v1 = ");
		Write("------------------------------ \n");

		double dot = v1.dot(v2);
		vec cross = v1.cross(v2);
		double norm = v1.norm();	

		Write("Part B: \n");
		Write($"v1 . v2 = {dot} \n");
		cross.print("v1 x v2 = ");
		Write($"norm(v1) = {norm} \n");
		Write("------------------------------ \n");

	}
}
