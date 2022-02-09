all: out.txt
	cat $<

out.txt: mathE.exe
	mono mathE.exe > out.txt

mathE.exe: mathE.cs
	mcs mathE.cs

.phoney clean:
	rm -f out.txt mathE.exe
