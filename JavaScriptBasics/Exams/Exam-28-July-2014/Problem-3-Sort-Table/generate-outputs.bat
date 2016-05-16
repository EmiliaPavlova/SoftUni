FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    node sortTable.js < "%%f" > "!file:.in.txt=.out.txt!"
)
