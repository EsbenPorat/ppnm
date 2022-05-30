all: problem.txt 3dgamma.plot.png
	cat $<

problem.txt: out.txt
	tail -n 1 $< > $@

3dgamma.plot.png: pltins.txt
	cat $< | pyxplot

out.txt: main.exe
	mono $< > $@

main.exe: main.cs cmath.dll
	mcs $< -target:exe -reference:cmath.dll

clean:
	rm -f *.exe out.txt
