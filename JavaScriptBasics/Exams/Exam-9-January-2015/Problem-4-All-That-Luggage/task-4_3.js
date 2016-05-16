/**
 * Created by emily on 5/12/15.
 */
function solve(input) {
    var criteria = input.pop().replace(" ", ""),
        collection = [];

    for (var row in input) {
        var data = input[row].split(/\.*\*\.*/g),
            name = data[0],
            posessionName = data[1],
            isFood = data[2],
            isDrink = data[3],
            isFragile = data[4],
            weight = Number(data[5]),
            transferredWith = data[6],
            type = "other";

        if (isFood == "true") {
            type = "food";
        } else if (isDrink == "true") {
            type = "drink";
        }

        var possesion = {
            luggagename: posessionName, // this key name will be used for sorting later
            weight: weight, // this key name will be used for sorting later too
            isFragile: isFragile == "true",
            type: type,
            transferredWith: transferredWith
        };

        var found = false;
        for (var k in collection) {
            //if we have that tourist in the collection of tourists
            if (collection[k]['name'] === name) {
                for (var p in collection[k]['possessions']) {
                    //if a tourist already has a luggage with that name
                    if (collection[k]["possessions"][p]["name"] == posessionName) {
                        delete collection[k]["possessions"][p]
                        break;
                    }
                }
                collection[k]["possessions"].push(possesion);
                found = true;
            }
        }
        if (!found) {
            var tourist = {
                name: name,
                possessions: []
            };
            tourist.possessions.push(possesion);
            collection.push(tourist);
        }
    }
    function mySort(a, b) {
        if (criteria == 'strict') {
            return 0;
        }
        return a[criteria] > b[criteria];
    }

    collection.forEach(function(tourist) {
        tourist.possessions.sort(mySort);
    });

    var result = {};

    collection.forEach(function(tourist) {
        result[tourist.name] = {};
        tourist.possessions.forEach(function(possesion) {
            result[tourist.name][possesion.luggagename] = {
                kg: possesion.weight,
                fragile: possesion.isFragile,
                type: possesion.type,
                transferredWith: possesion.transferredWith
            }
        })
    });
    //console.log(result);
    console.log(JSON.stringify(result));
}

solve ([
    'Yana Slavcheva...*..clothes..*false*false......*...false..*..2.2..*.backpack',
    'Kiko..*...socks..*false*false......*...false..*..0.2..*.backpack',
    'Kiko....*...banana..*true*false......*...false..*..3.2..*.backpack',
    'Kiko......*...sticks..*false.....*false......*...false..*..1.6..*.ATV',
    'Kiko*...glasses..*false*...false......*...true..*..3..*.ATV',
    'Manov..*...socks..*false*false....*...false..*0.3..*.ATV',
    'luggage name']);