/**
 * Created by emily on 4/3/15.
 */

function solve(input) {
    var startNum = Number(input[0]),
        endNum = Number(input[1]),
        square,
        isFibNum = calcFibonacci(endNum);

    console.log('<table>');
    console.log('<tr><th>Num</th><th>Square</th><th>Fib</th></tr>');

    for (var i = startNum; i <= endNum; i++) {
        square = i * i;
        var fib = isFibNum[i] ? 'yes' : 'no';

        console.log('<tr><td>' + i + '</td><td>' + square + '</td><td>' + fib + '</td></tr>');
    }

    function calcFibonacci (maxNum) {
        var fibNum = {1: true};
        var f1 = 1;
        var f2 = 1;
        while (true) {
            var f3 = f1 + f2;
            if (f3 > maxNum) {
                return fibNum;
            }
            fibNum[f3] = true;
            f1 = f2;
            f2 = f3;
        }
    }

    console.log('</table>');
}

solve([2, 6])