all: out.txt
	cat $<

out.txt : hello.exe
	mono hello.exe > out.txt

hello.exe : hello.cs
	mcs hello.cs

.phoney clean:
	rm -rf out.txt hello.exe
