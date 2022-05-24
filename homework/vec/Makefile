all: out.txt
	cat $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs vec.dll
	mcs -target:exe -out:$@ -reference:vec.dll $<

vec.dll: vec.cs
	mcs -target:library -out:$@ $<

clean:
	rm -f *.exe *.dll
