public class genlist<T>{
	public T[] data;
	public int size => data.Length; // size of list
	public T this[int i] => data[i]; // indexer
	public genlist(){
		data = new T[0]; // constructor
	}
	public void push(T item) {
		T[] newdata = new T[size+1];
 // initializes array that is one larger
		for(int i=0; i<size; i++) {newdata[i] = data[i];} // copies previous array into new one
		newdata[size]=item; // adds the new element at the end
		data=newdata; //overwrites old array as the new array
	}
}
