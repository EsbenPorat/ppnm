all: output.txt
	cat $<

out.txt: main.exe
	mono main.exe > out.txt

main.exe: main.cs
	mcs main.cs

CMATHDIR = /repos/ppnm/exercises/complex
cmath.dll : $(CMATHDIR)/cmath.cs $(CMATHDIR)/complex.cs
	mcs - target:library -out:./cmath.dll $^

.phoney clean:
	rm -f out.txt main.exe
