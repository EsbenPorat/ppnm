all: out.txt
	cat $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs mktable.dll
	mcs -reference:mktable.dll main.cs

mktable.dll : mktable.cs
	mcs -target:library mktable.cs

clean:
	rm -f *.dll *.txt *.exe
