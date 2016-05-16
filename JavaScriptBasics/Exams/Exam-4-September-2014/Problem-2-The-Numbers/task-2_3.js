/**
 * Created by emily on 5/7/15.
 */
function solve(input) {
    var numbers = input[0].split(/\D+/g).filter(Boolean);
    var numArray = [];

    for (var num in numbers) {
        var hex = parseInt(numbers[num]).toString(16).toUpperCase();
        var zerosCount = 4 - hex.length;
        var zerosArray = [];
        for (var i = 0; i < zerosCount.length; i++) {
            zerosCount.push(0);
        }
        var number = zerosArray.join('');
        number = '0x' + number + hex;
        numArray.push(number)
    }
    console.log(numArray);
}

solve(['5tffwj(//*7837xzc2---34rlxXP%$”.']);
solve(['482vMWo(*&^%$213;k!@41341((()&^>><///]42344p;e312']);
solve(['20']);