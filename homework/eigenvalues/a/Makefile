all: out.txt
	cat $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs jacobirot.dll matrix.dll vector.dll
	mcs $< -reference:jacobirot.dll,matrix.dll,vector.dll

jacobirot.dll: jacobirot.cs matrix.dll vector.dll
	mcs $< -target:library -reference:matrix.dll,vector.dll

matrix.dll: matrix.cs vector.dll
	mcs $< -target:library -reference:vector.dll

vector.dll: vector.cs
	mcs $< -target:library

clean:
	rm -r *.dll *.exe out.txt
