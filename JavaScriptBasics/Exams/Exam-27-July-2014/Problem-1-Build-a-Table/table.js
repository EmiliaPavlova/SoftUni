function printTableOfNumbers(input) {
    var startNum = Number(input[0]);
    var endNum = Number(input[1]);
    fibNums = calcFibonacciNums(endNum);
    console.log('<table>');
    console.log('<tr><th>Num</th><th>Square</th><th>Fib</th></tr>');
    for (var num = startNum; num <= endNum; num++) {
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
// ------------------------------------------------------------
// Read the input from the console as array and process it
// Remove all below code before submitting to the judge system!
// ------------------------------------------------------------
printTableOfNumbers([2, 6]);
