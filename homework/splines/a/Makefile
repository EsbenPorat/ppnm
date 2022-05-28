all: linterp.plot.png out.txt

linterp.plot.png: pltins.txt
	cat $< | pyxplot

out.txt: main.exe sintabs.txt
	mono $<  -input:sintabs.txt > $@

main.exe: main.cs arraygen.dll
	mcs -target:exe -out:$@ -reference:arraygen.dll $<

arraygen.dll: arraygen.cs
	mcs -target:library -out:$@ $<

clean:
	rm -f *.exe *.dll out.txt
