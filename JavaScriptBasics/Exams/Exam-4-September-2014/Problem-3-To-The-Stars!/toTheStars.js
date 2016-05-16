function toTheStars(input) {
    var starOne = input[0].split(/\s+/);
    var starTwo = input[1].split(/\s+/);
    var starThree = input[2].split(/\s+/);
    var nInfo = input[3].split(/\s+/);
    var nX = parseFloat(nInfo[0]);
    var nY = parseFloat(nInfo[1]);
    var turns = parseInt(input[4]);

    var starNames = [starOne[0], starTwo[0], starThree[0]];
    var starX = [parseFloat(starOne[1]), parseFloat(starTwo[1]), parseFloat(starThree[1])];
    var starY = [parseFloat(starOne[2]), parseFloat(starTwo[2]), parseFloat(starThree[2])];

    for (var i = 0; i <= turns; i++) {
        var foundStar = false;
        for (var j = 0; j < 3; j++) {
            if (isInsideStar(nX, nY, starX[j], starY[j])) {
                console.log(starNames[j].toLowerCase());
                foundStar = true;
                break;
            }
        }
        if (!foundStar) {
            console.log("space");
        }
        nY++;
    }

    function isInsideStar(nX, nY, sX, sY) {
        return (nX <= sX + 1 && nX >= sX - 1) &&
            (nY <= sY + 1 && nY >= sY - 1);
    }
}

// ------------------------------------------------------------
// Read the input from the console as array and process it
// Remove all below code before submitting to the judge system!
// ------------------------------------------------------------

var arr = [];
require('readline').createInterface({
    input: process.stdin,
    output: process.stdout
}).on('line', function (line) {
    arr.push(line);
}).on('close', function () {
    toTheStars(arr);
});
