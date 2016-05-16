/**
 * Created by Emily on 30-Jan-16.
 */
function solve(input) {
    var message = input.shift(),
        magicNumber = Number(input.shift()),
        matrix = [],
        sum = 0;

    input.forEach(function(line) {
        matrix.push(line.split(' '));
    });

    for (var row = 0; row < matrix.length; row++) {
        for (var col = 0; col < matrix[row].length; col++) {
            for (var row2 = 0; row2 < matrix.length; row2++) {
                for (var col2 = 0; col2 < matrix[row].length; col2++) {
                    if (parseInt(matrix[row][col]) + parseInt(matrix[row2][col2]) === magicNumber &&
                        (row, col) !== (row2, col2)) {
                        sum += parseInt(row);
                        sum += parseInt(col);
                    }
                }
            }
        }
    }

    //console.log(sum);

    var output = '';
    var array = message.split('');
    for (var i = 0; i < array.length; i++) {
        if (i % 2 === 0) {
            output += String.fromCharCode(parseInt(array[i].charCodeAt(array[i]) + sum));
        } else {
            output += String.fromCharCode(parseInt(array[i].charCodeAt(array[i]) - sum));
        }
    }

    console.log(output);
}

solve(["QqdvSpg",
    "400",
    "100 200 120",
    "120 300 310",
    "150 290 370"]);

solve(["Vi`ujr!sihtudts",
    "0",
    "0 0 120 300",
    "100 9 300 100",
    "1 290 370 100",
    "10 11 100 550"]);