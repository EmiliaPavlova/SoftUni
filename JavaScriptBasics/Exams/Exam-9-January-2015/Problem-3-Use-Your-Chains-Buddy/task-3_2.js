/**
 * Created by emily on 4/3/15.
 */

function solve(array) {
    var input = array[0],
        regex= /<p>(.*?)<\/p>/g,
        text,
        match,
        currentCharCode,
        newCharCode,
        output = '';

    while(match = regex.exec(input)) {
        text = match[1];
        text = text.replace(/[^a-z0-9]+/g, ' ');

        for (var c in text) {
            currentCharCode = text.charCodeAt(c);
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

solve(['<html><head><title></title></head><body><h1>hello</h1><p>znahny!@#%&&&&****</p><div>\<' +
'button>dsad</button></div><p>grkg^^^^%%%)))([]12</p></body></html>']);