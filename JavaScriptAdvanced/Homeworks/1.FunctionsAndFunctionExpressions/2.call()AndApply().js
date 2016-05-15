function printArgsInfo(a, b) {
    return a * b;
}
var result = printArgsInfo.call(result, 10, 2);
console.log(result);
console.log(printArgsInfo.call());

function printArgsInfoNoArgs(a, b) {
    return a * b;
}
var args = [10, 3];
var result2 = printArgsInfoNoArgs.apply(result2, args);
console.log(result2);
console.log(printArgsInfoNoArgs.apply());