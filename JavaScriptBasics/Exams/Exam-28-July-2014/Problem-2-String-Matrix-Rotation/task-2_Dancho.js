/**
 * Created by emily on 3/30/15.
 */

function solve(args) {
    var degrees = args[0].split(/\D+/)[1] %360;
    var matrix = [];
    var len = args.length;
    var maxLenght = 0;
    for (var col = 1; col < args.length; col += 1) {
        matrix[col - 1] = args[col].split('');
        if (args[col].maxLength > len) {
            len = maxLenght;
        }
    }

    len = matrix.length;
    for (var row = 0; row < len; row++) {
        for (var col = matrix[row].length; col < maxLenght; col++) {
            matrix[row].push(' ');
        }
    }

    rotateMatrix(matrix, degrees);

    function rotateMatrix(matrix, degrees) {
        var row, col;
        switch (degrees) {
            case 0:
                for (row = 0; row < matrix.length; row++) {
                    var rowAsString = matrix[row].reverse().join('')
                    console.log(rowAsString);
                }
                break;
            case 90:
                for (col = 0; col < matrix[0].length; col++) {
                    var rowAsString = '';
                    for (row = 0; row < matrix.length; row++) {
                        rowAsString += matrix[row][col];
                    }
                    console.log(rowAsString.split('').reverse().join(''));
                }
                break;
            case 180:
                for (row = matrix.length - 1; row >= 0; row--) {
                    var rowAsString = matrix[row].reverse().join('')
                    console.log(rowAsString);
                }
                break;
            case 270:
                for (col = 0; col < matrix[0].length - 1; col++) {
                    var rowAsString = '';
                    for (row = 0; row < matrix.length; row++) {
                        rowAsString += matrix[row][col];
                    }
                    console.log(rowAsString.split(''));
                }
                break;
        }
    }
}

solve(['Rotate(90', 'hello', 'softuni', 'exam']);