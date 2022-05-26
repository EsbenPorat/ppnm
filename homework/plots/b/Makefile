all: lngamma.plot.png gamma.plot.png
	
gamma.plot.png: pltgamma.txt data.txt
	cat $< | pyxplot

lngamma.plot.png: pltlngamma.txt data.txt
	cat $< | pyxplot

data.txt: main.exe
	mono $< > $@

main.exe: main.cs
	mcs $<

clean:
	rm -f *.exe data.txt *.png *.dll
