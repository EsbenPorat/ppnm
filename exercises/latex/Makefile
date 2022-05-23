all: exp.pdf
	xdg-open exp.pdf

exp.pdf: exp.tex exp.plot.png
	pdflatex exp.tex

exp.plot.png: pltins.txt data.txt
	cat $< | pyxplot

data.txt: main.exe
	mono $< > $@

main.exe: main.cs
	mcs -out:$@ $<

clean:
	rm -f *.exe *.dll data.txt *.png *.pdf *.log *.aux
