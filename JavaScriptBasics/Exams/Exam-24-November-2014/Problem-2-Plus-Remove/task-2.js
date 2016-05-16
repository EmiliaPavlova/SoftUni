/**
 * Created by emily on 4/2/15.
 */

function solve(input) {
    var matrix = [];
    var result = [];
    var output = [];

    input.forEach(function(string) {
        matrix.push(string.toLowerCase().split(''));
        result.push(string.split(''));
    });

    for (var row = 0; row < matrix.length - 2; row += 1) {
        for (var col = 1; col <= matrix[row].length; col += 1) {
            if (matrix[row][col] === matrix[row + 1][col - 1] &&
                matrix[row][col] === matrix[row + 1][col] &&
                matrix[row][col] === matrix[row + 1][col + 1] &&
                matrix[row][col] === matrix[row + 2][col]) {
                result[row][col] = '';
                result[row + 1][col - 1] = '';
                result[row + 1][col] = '';
                result[row + 1][col + 1] = '';
                result[row + 2][col] = '';
            }
        }
    }
    result.forEach(function(str) {
        output.push(str.join(''));
    });
    output.forEach(function(item) {
        console.log(item);
    });
}

solve([
    'ab**l5',
    'bBb*555',
    'absh*5',
    'ttHHH',
    'ttth']);