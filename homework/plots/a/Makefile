erf.plot.png: pltins.txt data.txt
	cat $< | pyxplot

data.txt: main.exe
	mono $< > $@

main.exe: main.cs
	mcs $<

clean:
	rm -f *.exe data.txt *.png *.dll
