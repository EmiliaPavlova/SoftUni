/**
 * Created by emily on 3/26/15.
 */

function solve(input) {
    var degrees = input[0].replace(/[^0-9]/g, '') % 360;
    var maxLenght = 0;
    var matrix = [];

    //finding the longest row
    for (var i = 1; i < input.length; i++) {
        while (input[i].length > maxLenght) {
            maxLenght = input[i].length;
        }
    }

    //padding with ' '
    for (var i = 0; i < input.length - 1; i++) {
        matrix[i] = [];
        var currentLine = input[i + 1].split(''); //input[i] = rotate(degree)
        for (var j = 0; j < maxLenght; j++) {
            var currentPosition = currentLine[j] || ' ';
            matrix[i].push(currentPosition);
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

    while(degrees > 0) {
        matrix = rotate(matrix);
        degrees -= 90;
    }

    for (var line in matrix) {
        console.log(matrix[line].join(''));
    }
}

solve(['Rotate(90)', 'hello', 'softuni', 'exam']);