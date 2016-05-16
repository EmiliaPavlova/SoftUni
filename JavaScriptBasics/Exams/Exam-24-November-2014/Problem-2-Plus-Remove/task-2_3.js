/**
 * Created by emily on 5/7/15.
 */
function solve(input) {
    var matrix = [],
        result = [];
    input.forEach(function(line) {
        matrix.push(line.toLowerCase().split(''));
        result.push(line.split(''));
    });
    for (var row = 0; row < matrix.length-2; row++) {
        for (var col = 1; col < matrix[row].length; col++) {
            if (matrix[row][col] === matrix[row+1][col-1] &&
                matrix[row][col] === matrix[row+1][col] &&
                matrix[row][col] === matrix[row+1][col+1] &&
                matrix[row][col] === matrix[row+2][col]) {
                result[row][col] = '';
                result[row+1][col-1] = '';
                result[row+1][col] = '';
                result[row+1][col+1] = '';
                result[row+2][col] = '';
            }
        }
    }
    var output = [];
    result.forEach(function(str) {
        output.push(str.join(''));
    });
    output.forEach(function(char) {
        console.log(char);
    });
}

solve(['@s@a@p@una',
    'p@@@@@@@@dna',
    '@6@t@*@*ego',
    'vdig*****ne6',
    'li??^*^*']);