javac *.java
FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    java OfficeStuff < "%%f" > "!file:.in.txt=.out.txt!"
)
del *.class
