/**
 * Created by emily on 4/3/15.
 */

function solve(array) {
    var input,
        band,
        town,
        venue;
    var result = {};

    for (var i in array) {
        input = array[i].split('|');
        band = input[0].trim();
        town = input[1].trim();
        venue = input[3].trim();

        if (!result[town]) {
            result[town] = {};
        }
        if (!result[town][venue]) {
            result[town][venue] = [];
        }
        if (result[town][venue].indexOf(band) == -1) {
            result[town][venue].push(band);
        }

    }
    function sortProperties(obj) {
        var keySorted = Object.keys(obj).sort();
        var objectSorted = {};
        for (var i = 0; i < keySorted.length; i++) {
            objectSorted[keySorted[i]] = obj[keySorted[i]];
        }
        return objectSorted;
    }
    result = sortProperties(result);

    for (var town in result) {
        result[town] = sortProperties(result[town]);
        for (var venue in result[town]) {
            result[town][venue].sort();
        }
    }
    console.log(JSON.stringify(result));
}

solve(['ZZ Top | London | 2-Aug-2014 | Wembley Stadium',
    'Iron Maiden | London | 28-Jul-2014 | Wembley Stadium',
    'Metallica | Sofia | 11-Aug-2014 | Lokomotiv Stadium',
    'Helloween | Sofia | 1-Nov-2014 | Vassil Levski Stadium',
    'Iron Maiden | Sofia | 20-June-2015 | Vassil Levski Stadium',
    'Helloween | Sofia | 30-July-2015 | Vassil Levski Stadium',
    'Iron Maiden | Sofia | 26-Sep-2014 | Lokomotiv Stadium',
    'Helloween | London | 28-Jul-2014 | Wembley Stadium',
    'Twisted Sister | London | 30-Sep-2014 | Wembley Stadium',
    'Metallica | London | 03-Oct-2014 | Olympic Stadium',
    'Iron Maiden | Sofia | 11-Apr-2016 | Lokomotiv Stadium',
    'Iron Maiden | Buenos Aires | 03-Mar-2014 | River Plate Stadium']);