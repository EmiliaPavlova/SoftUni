/**
 * Created by emily on 4/4/15.
 */

function solve(input) {
    var star1 = input[0].split(/\s+/),
        star2 = input[1].split(/\s+/),
        star3 = input[2].split(/\s+/),
        coordinates = input[3].split(/\s+/),
        x = parseFloat(coordinates[0]),
        y = parseFloat(coordinates[1]),
        turns = Number(input[4]),
        starNames = [star1[0], star2[0], star3[0]],
        starX = [parseFloat(star1[1]), parseFloat(star2[1]), parseFloat(star3[1])],
        starY = [parseFloat(star1[2]), parseFloat(star2[2]), parseFloat(star3[2])];

    function isInsideStar(x, y, starX, starY) {
        return (x <= starX + 1 && x >= starX - 1 && y <= starY + 1 && y >= starY - 1);
    }

    for (var i = 0; i <= turns; i++) {
        var foundStar = false;
        for (var j = 0; j < 3; j++) {
            if (isInsideStar(x, y, starX[j], starY[j])) {
                console.log(starNames[j].toLowerCase());
                foundStar = true;
                break;
            }
        }
        if (!foundStar) {
            console.log('space');
        }
        y += 1;
    }
}

solve(['Sirius 3 7',
    'Alpha-Centauri 7 5',
    'Gamma-Cygni 10 10',
    '8 1',
    '6']);