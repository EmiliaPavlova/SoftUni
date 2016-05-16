FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    node ewoks-fans-solution.js < "%%f" > "!file:.in.txt=.out.txt!"
)
