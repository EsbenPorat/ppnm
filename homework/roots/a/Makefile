all: out.txt
	cat $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs roots.dll lineq.dll matrix.dll vector.dll
	mcs $< -reference:lineq.dll,matrix.dll,vector.dll,roots.dll

roots.dll: roots.cs lineq.dll matrix.dll vector.dll
	mcs $< -target:library -reference:matrix.dll,vector.dll,lineq.dll

lineq.dll: lineq.cs matrix.dll vector.dll
	mcs $< -target:library -reference:matrix.dll,vector.dll

matrix.dll: matrix.cs vector.dll
	mcs $< -target:library -reference:vector.dll

vector.dll: vector.cs
	mcs $< -target:library

clean:
	rm -r *.dll *.exe *.txt
