/**
 * Created by Emily on 31-Jan-16.
 */
function solve(input) {
    var result = {};
    for (var i in input) {
        var data = input[i].split(/\s*&\s*/g),
            name = data[0].trim(),
            type = data[1].trim(),
            taskNumber = 'Task ' + data[2].trim(),
            score = Number(data[3].trim()),
            lines = Number(data[4].trim());

        if (!result[taskNumber]) {
            result[taskNumber] = {
                tasks: [],
                average: 0,
                lines: 0
            }
        }
        result[taskNumber].tasks.push({
            name: name,
            type: type
        });

        result[taskNumber].tasks.sort(function(a, b) {
            return a.name > b.name;
        });

        result[taskNumber].average += score;
        result[taskNumber].lines += lines;
    };

    var totalTasks = 0;
    for (var property in result) {
        totalTasks += 1;
        if (result.hasOwnProperty(property)) {
            result[property].average =
                parseFloat((result[property].average / result[property].tasks.length).toFixed(2));
        }
    }

    var sorted = Object.keys(result).sort(function (a, b){
        if (result[a].average !== result[b].average) {
            return result[a].average < result[b].average;
        } else {
            return result[a].lines > result[b].lines;
        }
    });

    var counter = 0;
    var output = '';
    sorted.forEach(function(x) {
        if (counter === 0) {
            output += '{'
        }
        output += '"' + x + '":';
        output += JSON.stringify(result[x]);
        if (counter === totalTasks - 1) {
            output += '}';
        }

        if (counter < totalTasks - 1) {
            output += ',';
        }
        counter += 1;
    })

    console.log(output);
}

solve([
    "Array Matcher & strings & 4 & 100 & 38",
    "Magic Wand & draw & 3 & 100 & 15",
    "Dream Item & loops & 2 & 88 & 80",
    "Knight Path & bits & 5 & 100 & 65",
    "Basket Battle & conditionals & 2 & 100 & 120",
    "Torrent Pirate & calculations & 1 & 100 & 20",
    "Encrypted Matrix & nested loops & 4 & 90 & 52",
    "Game of bits & bits & 5 &  100 & 18",
    "Fit box in box & conditionals & 1 & 100 & 95",
    "Disk & draw & 3 & 90 & 15",
    "Poker Straight & nested loops & 4 & 40 & 57",
    "Friend Bits & bits & 5 & 100 & 81"
]);