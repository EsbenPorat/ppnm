qspline.plot.png: pltins.txt out.txt
	cat $< | pyxplot

out.txt: main.exe
	mono $< > $@

main.exe: main.cs qspline.dll
	mcs $< -target:exe -reference:qspline.dll

qspline.dll: qspline.cs
	mcs $< -target:library -out:$@

clean:
	rm -f *.exe *.dll out.txt
