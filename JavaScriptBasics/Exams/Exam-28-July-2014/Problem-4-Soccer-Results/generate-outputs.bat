FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    node soccerResults.js < "%%f" > "!file:.in.txt=.out.txt!"
)
