/**
 * Created by emily on 5/12/15.
 */
function solve(input) {
    var jumpsAllowed = input.shift(),
        tracklength = input.shift(),
        fleas = [],
        haveWinner = false,
        winner = "",
        diesArray = [];

    for (var line in input) {
        var fleaData = input[line].split(', '),
            name = fleaData[0],
            jumpDistance = Number(fleaData[1]);
        fleas.push({
            'name': name,
            'jumpDistance': jumpDistance,
            'position' : 0
        });
    }
    //console.log(fleas);
    for (var i = 0; i < jumpsAllowed; i++) {
        for (var flea in fleas) {
            if (!haveWinner) {
                fleas[flea].position += fleas[flea].jumpDistance;
                if (fleas[flea].position >= tracklength - 1) {
                    fleas[flea].position = tracklength - 1;
                    haveWinner = true;
                    winner = fleas[flea].name;
                }
            }
        }
    }
    //console.log(fleas);
    //order the fleas-winners
    if (winner === '') {
        var maxDistance = 0;
        fleas.forEach(function(flea) {
            if (flea.position >= maxDistance) {
                maxDistance = flea.position;
                winner = flea.name;
            }
        });
    }
    //print
    for (var i = 0; i < tracklength; i++) {
        diesArray.push('#');
    }
    console.log(diesArray.join(""));
    console.log(diesArray.join(""));

    for (var flea in fleas) {
        var currentFlea = '',
            fleaInitial = (fleas[flea].name)[0].toUpperCase();
        for (var i = 0; i < tracklength; i++) {
            if (i === fleas[flea].position) {
                currentFlea += fleaInitial;
            } else {
                currentFlea += '.';
            }
        }
        console.log(currentFlea);
    }

    console.log(diesArray.join(""));
    console.log(diesArray.join(""));
    console.log('Winner: ' + winner);
}

solve([
    '10',
    '19',
    'angel, 9',
    'Boris, 10',
    'Georgi, 3',
    'Dimitar, 7']);

solve([
    '3',
    '5',
    'cura, 1',
    'Pepi, 1',
    'UlTraFlea, 1',
    'BOIKO, 1']);