/**
 * Created by Emily on 28-Jan-16.
 */
function solve(input) {
    var allowedJumps = input.shift(),
        trackLength = input.shift(),
        fleas = [],
        haveWinner = false,
        winner = '';

    for (var line in input) {
        var fleaData = input[line].split(' '),
            name = fleaData[0],
            jumpDistance = Number(fleaData[1]);

        fleas.push({
            'name': name,
            'jumpDistance': jumpDistance,
            'position': 1
        });
    }

    if (winner === '') {
        var maxDistance = 1;
        fleas.forEach(function(flea) {
            if (flea.position >= maxDistance) {
                maxDistance = flea.position;
                winner = flea.name;
            }
        });
    }

    var audience = '';
    for (var i = 0; i < trackLength; i++) {
        audience += '#';
    }
    console.log(audience);
    console.log(audience);

    for (var fl in fleas) {
        var currentFlea = '',
            fleaInitial = fleas[fl].name[0].toUpperCase();
        for (var i = 0; i < trackLength; i++) {
            if (i === fleas[fl].position - 1) {
                currentFlea += fleaInitial;
            } else {
                currentFlea += '.';
            }
        }
        console.log(currentFlea);
    }
    console.log(audience);
    console.log(audience);
    console.log("Winner: " + winner);
}

solve([
    '10',
    '19',
    'angel, 9',
    'Boris, 10',
    'Georgi, 3',
    'Dimitar, 7'
]);

solve([
    '3',
    '5',
    'cura, 1',
    'Pepi, 1',
    'UlTraFlea, 1',
    'BOIKO, 1'
]);