/**
 * Created by emily on 4/4/15.
 */

function solve(input) {
    var matrix = [],
        result = [];

    input.forEach(function(line) {
        matrix.push(line.toLowerCase().split(''));
        result.push(line.split(''));
    });
    for (var row = 0; row < matrix.length - 2; row++) {
        for (var col = 0; col < matrix[row].length; col++) {
            if (matrix[row][col] === matrix[row][col + 2] &&
                matrix[row][col] === matrix[row + 1][col + 1] &&
                matrix[row][col] === matrix[row + 2][col] &&
                matrix[row][col] === matrix[row + 2][col + 2]) {
                result[row][col] = '';
                result[row][col + 2] = '';
                result[row + 1][col + 1] = '';
                result[row + 2][col] = '';
                result[row + 2][col + 2] = '';
            }
        }
    }
    var output = [];

    result.forEach(function(str) {
        output.push(str.join(''));
    });

    output.forEach(function(item) {
        console.log(item);
    });
}

solve(['puoUdai',
    'miU',
    'ausupirina',
    '8n8i8',
    'm8o8a',
    '8l8o860',
    'M8i8',
    '8e8!8?!']);