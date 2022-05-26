public class genlist<T>{
	public T[] data;
	public int size = 0, capacity= 8; // size of list
	public T this[int i] => data[i];  // indexer
	public genlist(){
		data = new T[capacity];   // constructor
	}

	public void push(T item) {
		if(size==capacity){	
			T[] newdata = new T[capacity*=2];		  // initializes array that is twice as large
			for(int i=0; i<size; i++) {newdata[i] = data[i];} // copies previous array into new one
			data=newdata;					  // overwrites old array as the new array
		}
		
		data[size]=item; // adds the new element
		size++;		 // increments recorded size
	}
	
	public void remove(int j){
		for(i=j; i<size; i++){		// loops over all elements from (inclusive) the one to be removed
			data[i]=data[i+1];	// moves all elements one index down (overwriting the removed one)
		}
		size--;				// decremenst recorded size
	}
}
