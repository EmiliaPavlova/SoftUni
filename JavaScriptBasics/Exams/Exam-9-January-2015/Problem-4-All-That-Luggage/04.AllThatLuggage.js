function solve(input) {

    var filterInfo = input[input.length - 1];

    var dataArray = {};
    for (var row = 0; row < input.length - 1; row++) {
        var arrayInfo = input[row].split(/\.*\*\.*/g);
        var ownerName = arrayInfo[0];
        var luggageName = arrayInfo[1];
        var isFood = (arrayInfo[2] === 'true');
        var isDrink = (arrayInfo[3] === 'true');
        var isFragile = (arrayInfo[4] === 'true')
        var weight = parseFloat(arrayInfo[5]);
        var transferredWith = arrayInfo[6];

        if(!(ownerName in dataArray)) {
            dataArray[ownerName] = {};
        }

        var type = '';
        isFood ? type = 'food' : isDrink ? type = 'drink' : type = 'other';
        dataArray[ownerName][luggageName] = {'kg':weight, 'fragile':isFragile, 'type': type, 'transferredWith' : transferredWith};
    }
    if(filterInfo === 'luggage name') {
        var outputNameSort = {};
        Object.keys(dataArray).forEach(function(key) {
            outputNameSort[key]={};
            var sortedInnerKeys = Object.keys(dataArray[key]).sort();

            sortedInnerKeys.forEach(function (innerkey) {
                outputNameSort[key][innerkey] = dataArray[key][innerkey];
            })
        });
        console.log(JSON.stringify(outputNameSort));
    } else if (filterInfo === 'weight') {
        var outputKgSort = {};
        Object.keys(dataArray).forEach(function(key) {
            outputKgSort[key]={};
            var a = Object.keys(dataArray[key]).sort(function (a,b) {
                return dataArray[key][a].kg- dataArray[key][b].kg;
            });
            a.forEach(function (value) {
                outputKgSort[key][value] = dataArray[key][value];
            })
        });
        console.log(JSON.stringify(outputKgSort))
    } else if (filterInfo === 'strict') {
        console.log(JSON.stringify(dataArray));
    }
    //console.log(dataArray)
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
    solve(arr);
});
//
//solve ([
//    'Yana Slavcheva...*..clothes..*false*false......*...false..*..2.2..*.backpack',
//    'Kiko..*...socks..*false*false......*...false..*..0.2..*.backpack',
//    'Kiko....*...banana..*true*false......*...false..*..3.2..*.backpack',
//    'Kiko......*...sticks..*false.....*false......*...false..*..1.6..*.ATV',
//    'Kiko*...glasses..*false*...false......*...true..*..3..*.ATV',
//    'Manov..*...socks..*false*false....*...false..*0.3..*.ATV',
//    'strict']);