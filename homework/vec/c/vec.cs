using static System.Console;
using static System.Math;

//class statement 
public class vec{
	public double x,y,z;
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
	
	public double dot(vec v){
		return this.x*v.x + this.y*v.y + this.z*v.z;
	}
	public vec cross(vec v){
		return new vec((this.y*v.z - this.z*v.y), (this.z*v.x - this.x*v.z), (this.x*v.y - this.y*v.x));
	}

	public double norm(){
		return this.x*this.x + this.y*this.y + this.z*this.z;
	}

	public void print(){
		Write($"{x} {y} {z} \n");
	}	

	static bool approx(double a,double b,double tau=1e-9,double eps=1e-9){
		if(Abs(a-b)<tau){
			return true;
		}
		if(Abs(a-b)/(Abs(a)+Abs(b))<eps){
			return true;
		}
		return false;
	}

	public bool approx(vec other){
		if(!approx(this.x,other.x)){
			return false;
		}
		if(!approx(this.y,other.y)){
			return false;
		}
		if(!approx(this.z,other.z)){
			return false;
		}
		return true;
	}

	public static bool approx(vec u, vec v){
		return u.approx(v);
	}

}
	
