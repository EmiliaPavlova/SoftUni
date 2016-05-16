/**
 * Created by emily on 3/31/15.
 */

function solve(input) {
    var numbers = input[0].split(/\D+/g).filter(Boolean);
    var numArr = [];

    for (var i in numbers) {
        var hex = parseInt(numbers[i]).toString(16).toUpperCase();
        var zerosCount = 4 - hex.length;
        var zerosArray = [];
        for (var j = 0; j < zerosCount; j++) {
            zerosArray.push(0);
        };
        var num = zerosArray.join('');
        num = '0x' + num + hex;
        numArr.push(num);

    }
    console.log(numArr.join('-'));
}

solve(['5tffwj(//*7837xzc2---34rlxXP%$”.']);

console.log(isNaN(NaN));
console.log(typeof NaN);
console.log(isNaN(''));
console.log(typeof '');