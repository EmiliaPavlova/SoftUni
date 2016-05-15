javac *.java
FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    java BePositive_Solution < "%%f" > "!file:.in.txt=.out.txt!"
)
PAUSE
