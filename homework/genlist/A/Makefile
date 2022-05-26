all: out.txt
	cat $<

out.txt: main.exe inputfile.txt
	mono $< < inputfile.txt > $@

main.exe: main.cs genlist.dll
	mcs -target:exe -out:$@ -reference:genlist.dll $<

genlist.dll: genlist.cs
	mcs -target:library -out:$@ $<

clean:
	rm -f *.exe *.dll out.txt
