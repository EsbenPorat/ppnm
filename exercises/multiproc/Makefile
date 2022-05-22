all: out.txt
	cat $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs
	mcs main.cs

clean:
	rm -f *.txt *.exe
