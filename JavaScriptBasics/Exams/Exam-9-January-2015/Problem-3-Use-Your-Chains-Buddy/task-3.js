/**
 * Created by emily on 4/1/15.
 */

function solve(array) {
    var input = array[0];
    var regex = /<p>(.*?)<\/p>/g;
    var matchArray,
        currentCharCode,
        newCharCode,
        output = '';

    while(matchArray = regex.exec(input)) {
        var match = matchArray[1];

        match = match.replace(/[^a-z0-9]+/g, ' ');

        for (var c in match) {
            currentCharCode = match.charCodeAt(c); //finds the ASCII code of the current symbol
            if (currentCharCode >= 97 && currentCharCode <= 109) {
                newCharCode = currentCharCode + 13;
            } else if (currentCharCode >= 110 && currentCharCode <= 122) {
                newCharCode = currentCharCode - 13;
            } else {
                newCharCode = currentCharCode;
            }
            output += String.fromCharCode(newCharCode);
        }
    }
    console.log(output);
}

solve(['<html><head><title></title></head><body><h1>hello</h1><p>znahny!@#%&&&&****</p><div><button>dsad</button></div><p>grkg^^^^%%%)))([]12</p></body></html>']);