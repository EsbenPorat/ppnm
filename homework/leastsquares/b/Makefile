all: problem.txt
	cat $<

problem.txt: out.txt
	tail -n 6 $< > $@

out.txt: main.exe
	mono $< > $@

main.exe: main.cs leastsquares.dll lineq.dll matrix.dll vector.dll
	mcs $< -reference:leastsquares.dll,lineq.dll,matrix.dll,vector.dll

leastsquares.dll: leastsquares.cs lineq.dll matrix.dll vector.dll
	mcs $< -target:library -reference:matrix.dll,vector.dll,lineq.dll

lineq.dll: lineq.cs matrix.dll vector.dll
	mcs $< -target:library -reference:matrix.dll,vector.dll

matrix.dll: matrix.cs vector.dll
	mcs $< -target:library -reference:vector.dll

vector.dll: vector.cs
	mcs $< -target:library

clean:
	rm -r *.dll *.exe out.txt
