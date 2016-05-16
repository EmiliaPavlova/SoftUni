/**
 * Created by emily on 4/1/15.
 */

function solve(array) {
    var criteria = array.pop();
    var tourists = {};
    var name,
        luggageName,
        isFood,
        isDrink,
        isFragile,
        weight,
        transferredWith;

    for (var i in array) {
        var data = array[i].split(/\.*\*\.*/g);
        name = data[0];
        luggageName = data[1];
        isFood = data[2];
        isDrink = data[3];
        isFragile = data[4];
        weight = Number(data[5]);
        transferredWith = data[6];

        var type = 'other';
        if (isFood === 'true') {
            type = 'food';
        } else if (isDrink === 'true') {
            type = 'drink';
        }

        if (!tourists[name]) {
            tourists[name] = {};
        }

        tourists[name][luggageName] = {
            kg: weight,
            fragile: isFragile === 'true',
            type: type,
            transferredWith: transferredWith
        };
    }
    var touristsNames = Object.keys(tourists);
    var currentName,
        currentTourist,
        luggageNames,
        sortedTourist;

    switch (criteria) {
        case 'luggage name':
            for (currentName in touristsNames) {
                currentTourist = tourists[touristsNames[currentName]];
                luggageNames = Object.keys(currentTourist);
                luggageNames.sort();

                sortedTourist = {};
                for (var l in luggageNames) {
                    sortedTourist[luggageNames[l]] = currentTourist[luggageNames[l]];
                }
                tourists[touristsNames[currentName]] = sortedTourist;
            }
            break;
        case 'weight':
            for (currentName in touristsNames) {
                currentTourist = tourists[touristsNames[currentName]];
                luggageNames = Object.keys(currentTourist);
                var luggages = [];

                for (var l in luggageNames) {
                    var currentLuggage = currentTourist[luggageNames[l]];
                    currentLuggage['name'] = luggageNames[l];
                    luggages.push(currentLuggage);
                }
                luggages.sort(function (a, b) {
                    return a['kg'] - b['kg'];
                });

                sortedTourist = {};
                for (var l in luggages) {
                    sortedTourist[luggages[l]['name']] = {
                        kg: luggages[l]['kg'],
                        fragile: luggages[l]['fragile'],
                        type: luggages[l]['type'],
                        transferredWith: luggages[l]['transferredWith']
                    };
                }
                tourists[touristsNames[currentName]] = sortedTourist;
            }
            break;
        default:
            break;
    }

    console.log(JSON.stringify(tourists));
}

solve(['Yana Slavcheva.*.clothes.*.false.*.false.*.false.*.2.2.*.backpack',
    'Kiko.*.socks.*.false.*.false.*.false.*.0.2.*.backpack',
    'Kiko.*.banana.*.true.*.false.*.false.*.3.2.*.backpack',
    'Kiko.*.sticks.*.false.*.false.*.false.*.1.6.*.ATV',
    'Kiko.*.glasses.*.false.*.false.*.true.*.3.*.ATV',
    'Manov.*.socks.*.false.*.false.*.false.*.0.3.*.ATV',
    'strict']);