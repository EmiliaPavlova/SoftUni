/**
 * Created by emily on 5/12/15.
 */
function solve(input) {
    var allowedJumps = input.shift(),
        trackLength = input.shift(),
        fleas = [],
        haveWinner = false,
        winner = "";

    for (var fleaIndex in input) {
        var line = input[fleaIndex].split(', '),
            name = line[0],
            jumpDistance = Number(line[1]);
// fill object
        fleas.push({
            'name': name,
            'jumpDistance': jumpDistance,
            'position' : 1
        })
    }
// get positions + find winner
    for (var i = 0; i < allowedJumps; i++) {
        for (var fleaI in fleas) {
            if(!haveWinner) {
                fleas[fleaI].position += fleas[fleaI].jumpDistance;
                if(fleas[fleaI].position >= trackLength) {
                    fleas[fleaI].position = trackLength;
                    haveWinner = true;
                    winner = fleas[fleaI].name;
                }
            }
        }
    }
//check if there is a winner -> set the winner to be the last flea
    if(winner === "") {
        var maxDistance = 1;
        fleas.forEach(function(flea) {
            if(flea.position >= maxDistance) {
                maxDistance = flea.position;
                winner = flea.name;
            }
        });
    }
//make the audience
    var audience = "";
    for (var i = 0; i < trackLength; i++) {
        audience += "#";
    }
    console.log(audience);
    console.log(audience);
//print the trace
    for (var fleaInd in fleas) {
        var currentFlea = "",
            fleaInitial = (fleas[fleaInd].name)[0].toUpperCase();
        for (var i = 0; i < trackLength; i++) {
            if(i === fleas[fleaInd].position - 1) {
                currentFlea += fleaInitial;
            } else {
                currentFlea += "."
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