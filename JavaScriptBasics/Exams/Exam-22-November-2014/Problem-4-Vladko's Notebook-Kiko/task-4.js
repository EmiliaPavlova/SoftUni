/**
 * Created by emily on 4/2/15.
 */

function solve(array) {
    var data,
        color,
        prop,
        value,
        rank,
        sortedColors;

    var result = {};
    var output = {};

    for (var i in array) {
        data = array[i].split('|');
        color = data[0];
        prop = data[1];
        value = data[2];

        if (!result[color]) {
            result[color] = {
                opponents: [],
                wins: 0,
                losses: 0
            };
        }

        switch (prop) {
            case 'age':
            case 'name':
                result[color][prop] = value;
                break;
            case 'win':
                result[color].wins += 1;
                result[color].opponents.push(value);
                break;
            case 'loss':
                result[color].losses += 1;
                result[color].opponents.push(value);
                break;
        }
    }

    sortedColors = Object.keys(result).sort();
    //console.log(sortedColors);

    for (var i in sortedColors) {
        rank = ((result[sortedColors[i]].wins + 1) / (result[sortedColors[i]].losses + 1)).toFixed(2);
        //console.log(result[sortedColors[i]]);

        if (!result[sortedColors[i]].name || !result[sortedColors[i]].age) {
            continue;
        }

        output[sortedColors[i]] = {
            age: result[sortedColors[i]].age,
            name: result[sortedColors[i]].name,
            opponents: result[sortedColors[i]].opponents.sort(),
            rank: rank
        }
    }

    console.log(JSON.stringify(output));
}

solve([
    'purple|age|99',
    'red|age|44',
    'blue|win|pesho',
    'blue|win|mariya',
    'purple|loss|Kiko',
    'purple|loss|Kiko',
    'purple|loss|Kiko',
    'purple|loss|Yana',
    'purple|loss|Yana',
    'purple|loss|Manov',
    'purple|loss|Manov',
    'red|name|gosho',
    'blue|win|Vladko',
    'purple|loss|Yana',
    'purple|name|VladoKaramfilov',
    'blue|age|21',
    'blue|loss|Pesho']);