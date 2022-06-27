all: output.txt timings.png
	cat $<

timings.png: pltins.txt timedata.txt
	cat $< | pyxplot

output.txt timedata.txt fitvals.txt: main.exe
	mono $< > $@

main.exe: main.cs matrix.dll vector.dll jacobirot.dll r1update.dll roots.dll lineq.dll leastsquares.dll
	mcs -reference:matrix.dll,vector.dll,jacobirot.dll,r1update.dll,roots.dll,lineq.dll,leastsquares.dll main.cs

leastsquares.dll: leastsquares.cs lineq.dll matrix.dll vector.dll
	mcs -target:library -reference:matrix.dll,vector.dll,lineq.dll leastsquares.cs

r1update.dll: r1update.cs matrix.dll vector.dll roots.dll lineq.dll
	mcs -target:library -reference:matrix.dll -reference:vector.dll -reference:roots.dll -reference:lineq.dll r1update.cs

roots.dll: roots.cs matrix.dll vector.dll lineq.dll
	mcs -target:library -reference:matrix.dll,vector.dll,lineq.dll roots.cs

lineq.dll: lineq.cs matrix.dll vector.dll
	mcs -target:library -reference:matrix.dll,vector.dll lineq.cs

jacobirot.dll: jacobirot.cs matrix.dll vector.dll
	mcs -target:library -reference:matrix.dll -reference:vector.dll jacobirot.cs

matrix.dll: matrix.cs vector.dll
	mcs -target:library -reference:vector.dll matrix.cs

vector.dll: vector.cs
	mcs -target:library vector.cs

clean:
	rm -r *.dll *.exe *.txt
