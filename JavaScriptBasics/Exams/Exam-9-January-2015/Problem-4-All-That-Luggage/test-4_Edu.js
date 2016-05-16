/**
 * Created by emily on 4/4/15.
 */
function solve(input) {
    var command = input.pop(),
        touristsData= {};

    for (var line in input) {
        input[line] = input[line].split(/\.*\*\.*/g);
        var name = input[line][0];
        if (!touristsData[name]) {
            touristsData[name] = {};
        }
    }

    if (command === 'luggage name') {
        input.sort(function(a, b) {
            return a[1] > b[1];
        });
    } else if (command === 'weight') {
        input.sort(function (a, b) {
            return parseFloat(a[5]) - parseFloat(b[5]);
        });
    }


    input.forEach(function(line) {
        var name = line[0],
            luggageName = line[1],
            isFood = line[2] === 'true',
            isDrink = line[3] === 'true',
            isFragile = line[4] === 'true',
            weight = parseFloat(line[5]),
            transferredWith = line[6],
            luggageType = 'other';
        if (isDrink) {
            luggageType = 'drink';
        } else if (isFood) {
            luggageType = 'food';
        }
        touristsData[name][luggageName] = {
            kg: weight,
            fragile: isFragile,
            type: luggageType,
            transferredWith: transferredWith
        }
    });

    console.log(JSON.stringify(touristsData));
}




solve ([
    'Yana Slavcheva...*..clothes..*false*false......*...false..*..2.2..*.backpack',
    'Kiko..*...socks..*false*false......*...false..*..0.2..*.backpack',
    'Kiko....*...banana..*true*false......*...false..*..3.2..*.backpack',
    'Kiko......*...sticks..*false.....*false......*...false..*..1.6..*.ATV',
    'Kiko*...glasses..*false*...false......*...true..*..3..*.ATV',
    'Manov..*...socks..*false*false....*...false..*0.3..*.ATV',
    'luggage name']);