FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    node keepTheChange.js < "%%f" > "!file:.in.txt=.out.txt!"
)
