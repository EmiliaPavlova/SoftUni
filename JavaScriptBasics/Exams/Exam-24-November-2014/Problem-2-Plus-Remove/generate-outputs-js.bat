FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    node Plus-Removal.js < "%%f" > "!file:.in.txt=.out.txt!"
)
