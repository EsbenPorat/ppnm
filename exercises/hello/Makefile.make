out.txt : hello.exe
	mono hello.exe > out.txt

hello.exe : hello.cs
	mcs hello.cs

clean:
	rm -rf out.txt hello.exe
