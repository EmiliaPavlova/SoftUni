/**
 * Created by emily on 4/3/15.
 */

function solve(input) {
    var output = [];
    for (var i = 0; i < input.length; i++) {
        output[i] = input[i].split('');
    }

    for (var row = 1; row < input.length; row++) {
        var maxCol = Math.min(input[row - 1].length, input[row].length - 1);
        for (var col = 0; col < maxCol; col++) {
            var a = input[row - 1][col],
                b = input[row][col - 1],
                c = input[row][col],
                d = input[row][col + 1];

            if (a === b && b === c && c === d) {
                output[row - 1][col] = '*';
                output[row][col - 1] = '*';
                output[row][col] = '*';
                output[row][col + 1] = '*';
            }
        }
    }
    for (var i = 0; i < input.length; i++) {
        console.log(output[i].join(''));

    }
}

solve(['abcdexgh',
    'bbbdxxxh',
    'abcxxxxx']);