/**
 * Created by Emily on 31-Jan-16.
 */
function solve(input) {
    var sequence = Number(input.pop()),
        allInLine = [],
        matrix = [];

    for (var line in input) {
        var data = input[line].split(' ');
        matrix.push(data);
    }

    for (var i = 0; i < input.length; i++) {
        allInLine = allInLine.concat(input[i].split(' '));
    }

    for (var i = 0; i < allInLine.length; i++) {
        var counter = 1;
        for (var j = i + 1; j < i + sequence; j++) {
            if (allInLine[i] === allInLine[j]) {
                counter += 1;
            }
        }

        if (counter === sequence) {
            for (var j = i; j < i + sequence; j++) {
                allInLine[j] = 'removed';
            }
        }
    }

    for (var i = 0; i < matrix.length; i++) {
        var output = allInLine.splice(0, matrix[i].length)
            .filter(function(x) {
                return x !== 'removed';
            });
        if (output.length) {
            console.log(output.join(' '));
        } else {
            console.log('(empty)');
        }
    }
}

solve([
    "2 1 1 1",
    "1 1 1",
    "3 7 3 3 1",
    "2"
]);

solve([
    "3 3 3 2 5 9 9 9 9 1 2",
    "1 1 1 1 1 2 5 8 1 1 7 7",
    "7 1 2 3 5 7 4 4 1 2",
    "2"]);

solve([
    "1 2 3 3",
    "3 5 7 8",
    "3 2 2 1",
    "3"]);