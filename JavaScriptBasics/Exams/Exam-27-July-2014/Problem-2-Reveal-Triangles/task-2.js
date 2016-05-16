/**
 * Created by emily on 3/25/15.
 */

function solve(input) {
    var output = [];
    for (var row = 0; row < input.length; row++) {
        output[row] = input[row].split('');
    }

    for (var row = 1; row < input.length; row++) {
        var maxCol = Math.min(input[row - 1].length - 2, input[row].length - 3);
        for (var col = 0; col <= maxCol; col++) {
            var a = input[row][col],
            b = input[row][col + 1],
            c = input[row][col + 2],
            d = input[row - 1][col + 1];

            if ( a === b && b === c && c === d) {
                output[row][col] = '*';
                output[row][col + 1] = '*';
                output[row][col + 2] = '*';
                output[row - 1][col + 1] = '*';
            }
        }
    }
    for (var row = 0; row < input.length; row++) {
        console.log(output[row].join(''));
    }
}

solve(['abcdexgh\
bbbdxxxh\
abcxxxxx'])