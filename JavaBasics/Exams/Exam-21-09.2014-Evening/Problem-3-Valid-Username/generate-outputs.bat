javac *.java
FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    java ValidUsernames < "%%f" > "!file:.in.txt=.out.txt!"
)
del *.class
