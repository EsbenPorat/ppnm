all: out.txt
	cat $<

out.txt: main.exe
	mono main.exe > out.txt

main.exe: main.cs cmath.dll
	mcs -reference:cmath.dll main.cs

CMATHDIR = ~/repos/ppnm/exercises/complex
cmath.dll :  $(CMATHDIR)/cmath.cs $(CMATHDIR)/complex.cs
	mcs -target:library -out:./cmath.dll $^

.phoney clean:
	rm -f out.txt main.exe
