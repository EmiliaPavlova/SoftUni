function evaluate(array) {
    //defining constants
    var CHAR_CODE_A = "a".charCodeAt(0);
    var CHAR_CODE_M = "m".charCodeAt(0);
    var CHAR_CODE_Z = "z".charCodeAt(0);

    var input = array[0];
    var regex = /<p>(.*?)<\/p>/g;
    var matchArray;
    var currentCharCode, newCharCode;
    var output = "";

    //regex.exec is looking for the current regex in the string that is given as argument
    while(matchArray = regex.exec(input)) {
        var match = matchArray[1];

        match = match.replace(/[^a-z0-9]+/g, " "); //replaces all symbols, other than "a-z" or "0-9" with " "

        for (var c in match) {
            currentCharCode = match.charCodeAt(c); //finds the ASCII code of the current symbol
            if (currentCharCode >= CHAR_CODE_A && currentCharCode <= CHAR_CODE_M) {
                newCharCode = currentCharCode + 13;
            }
            else if (currentCharCode >= CHAR_CODE_M && currentCharCode <= CHAR_CODE_Z) {
                newCharCode = currentCharCode - 13;
            } else {
                newCharCode = currentCharCode;
            }
            output += String.fromCharCode(newCharCode);
        }
        //console.log(match);
    }
    console.log(output);
}

var input =["<html><head><title></title></head><body><h1>hello</h1><p>znahny!@#%&&&&****</p><div><button>dsad</button></div><p>grkg^^^^%%%)))([]12</p></body></html>"];

evaluate(input);