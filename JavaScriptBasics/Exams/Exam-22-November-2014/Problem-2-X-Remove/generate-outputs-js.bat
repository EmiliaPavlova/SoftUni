FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    node X-Removal.js < "%%f" > "!file:.in.txt=.out.txt!"
)
