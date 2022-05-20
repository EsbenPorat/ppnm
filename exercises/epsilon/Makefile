all: out.txt
	cat $<

out.txt: epsilonminmax.exe epsilonmachine.exe
	mono epsilonminmax.exe > out.txt
	mono epsilonmachine.exe > out.txt

epsilonminmax.exe: epsilonminmax.cs
	mcs epsilonminmax.cs

epsilonmachine.exe: epsilonmachine.cs
	mcs epsilonmachine.cs

.phoney clean:
	rm -f out.txt epsilonmachine.exe epsilonminmax.exe
