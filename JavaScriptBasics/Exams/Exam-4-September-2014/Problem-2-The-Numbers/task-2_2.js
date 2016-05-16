/**
 * Created by emily on 4/4/15.
 */

function solve(input) {
    var numbers = input[0].split(/\D+/g).filter(Boolean);
    var numArray = [];

    for (var i in numbers) {
        var hex = parseInt(numbers[i]).toString(16).toUpperCase();
        var zerosCount = 4 - hex.length;
        var zerosArray = [];
        for (var j = 0; j < zerosCount; j++) {
            zerosArray.push(0);
        }
        var num = zerosArray.join('');
        num = '0x' + num + hex;
        numArray.push(num);
    }

    console.log(numArray.join('-'));
}

solve(['5tffwj(//*7837xzc2---34rlxXP%$”.']);