scipy.plot.pn: pltins.txt data.txt
	cat $< | pyxplot

data.txt: main.exe
	mono $< > $@

main.exe: main.cs ode.dll vector.dll
	mcs -target:exe -reference:ode.dll -reference:vector.dll $<

ode.dll: ode.cs vector.dll
	mcs -target:library -reference:vector.dll $<

vector.dll: vector.cs
	mcs -target:library $<

clean:
	rm -f *.exe *.txt *.png *.dll
