erf.plot.png: plotinstructions.txt data.txt
	cat $< | pyxplot

data.txt: main.exe
	mono $< > $@

main.exe: main.cs integrate.dll
	mcs -reference:integrate.dll -out:$@ $<

integrate.dll: integrate.cs
	mcs -target:library -out:$@ $<

clean:
	rm -f *.exe *.dll *.txt *.png
