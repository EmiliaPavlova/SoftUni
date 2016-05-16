/**
 * Created by emily on 3/25/15.
 */

function solve(input) {
    var startNumber = Number(input[0]),
        endNumber = Number(input[1]);

    fibNums = calcFibonacciNums(endNumber);

    console.log('<table>');
    console.log('<tr><th>Num</th><th>Square</th><th>Fib</th></tr>');
    for (var num = startNumber; num <= endNumber; num++) {
        var numSquare = num * num;
        var isFibonacci = fibNums[num] ? "yes" : "no";
        printAsTableRow(num, numSquare, isFibonacci);
    }
    console.log('</table>');

    function calcFibonacciNums(maxNum) {
        var fibNums = { 1: true };
        var f1 = 1;
        var f2 = 1;
        while (true) {
            var f3 = f1 + f2;
            if (f3 > maxNum) {
                return fibNums;
            }
            fibNums[f3] = true;
            f1 = f2;
            f2 = f3;
        }
    }

    function printAsTableRow() {
        var tableRow = '<tr>';
        for (var i in arguments) {
            tableRow += '<td>' + arguments[i] + '</td>';
        }
        tableRow += '</tr>';
        console.log(tableRow);
    }
}

solve([5, 10]);
solve([55, 56]);