FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    node 01.TetevenTrip.js < "%%f" > "!file:.in.txt=.out.txt!"
)
PAUSE
