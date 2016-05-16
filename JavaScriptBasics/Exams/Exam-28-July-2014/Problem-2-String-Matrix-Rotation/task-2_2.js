/**
 * Created by emily on 4/4/15.
 */

function solve(input) {
    var degrees = input[0].replace(/[^0-9]/g, '') % 360;
    var maxLength = 0;
    var matrix = [];

    for (var i = 1; i < input.length; i++) {
        while (input[i].length > maxLength) {
            maxLength = input[i].length;
        }
    }
    for (var i = 0; i < input.length - 1; i++) {
        matrix[i] = [];
        var currentLine = input[i + 1].split('');
        for (var j = 0; j < maxLength; j++) {
            var currentPos = currentLine[j] || ' ';
            matrix[i].push(currentPos);
        }
    }

    function rotate(array) {
        var rows = array[0].length,
            columns = array.length,
            newArray = [];
        for (var i = 0; i < rows; i++) {
            newArray[i] = [];
            for (var j = columns - 1; j >= 0; j--) {
                newArray[i].push(array[j][i]);
            }
        }
        return newArray;
    }

    while (degrees > 0) {
        matrix = rotate(matrix);
        degrees -= 90;
    }

    for (var line in matrix) {
        console.log(matrix[line].join(''));
    }

}

solve(['Rotate(90)',
    'hello',
    'softuni',
    'exam']);