vec.dll: vectorclass.cs
	mcs -target:library -out:vectorclass.dll vectorclass.cs

main.exe: main.cs vectorclass.dll
	mcs -target:exe -out:main.exe -reference:vectorclass.dll vectorclass.cs

.phoney clean:
		rm -f main.exe
