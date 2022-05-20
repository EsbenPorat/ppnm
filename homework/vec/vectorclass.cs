using static System.Console;

//class statement 
public class vec{
	public double xcoord,ycoord,zcoord;
	double static x = xcoord;
       	double static y = ycoord;
       	double static z = zcoord;
//constructors
	public vec(){
		x=0; y=0; z=0;
	}
	public vec(double a, double b, double c){
		x=a;y=b;z=c;
	}
//operators
	public static vec operator*(vec v, double c){
		return new vec(c*v.x, c*v.y, c*v.z);
	}
	public static vec operator*(double c, vec v){
		return new vec(v.x*c, v.y*c, v.z*c);
	}
	public static vec operator+(vec u, vec v){
		return new vec(u.x+v.x, u.y+v.y, u.z+v.z);
	}
	public static vec operator-(vec u, vec v){
		return new vec(u.x-v.x, u.y-v.y, u.z-v.z);
	}
	public static vec operator-(vec v){
		return new vec(-1*v.x, -1*v.y, -1*v.z);
	}
//methods:
	public void print(string s, vec v){Write(s);WriteLine($"{v.x} {v.y} {v.z}");}
	public void print(){this.print("");}
}
