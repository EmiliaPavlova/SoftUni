/**
 * Created by emily on 4/1/15.
 */

function solve(input) {
    var inputLine,
        pos,
        verticalPos,
        ahaa = false;

    for (var i in input) {
        inputLine = input[i];

        if (ahaa) {
            for (var c in inputLine) {
                if (inputLine[c] === '>') {
                    pos++;
                } else if (inputLine[c] === '<') {
                    pos--;
                }
            }
            switch (inputLine[pos]) {
                case '_':
                    console.log("Landed on the ground like a boss!");
                    console.log(i + ' ' + pos);
                    return; //aha = false;
                    break;
                case '~':
                    console.log("Drowned in the water like a cat!");
                    console.log(i + ' ' + pos);
                    return
                    break;
                case '/':
                case '|':
                case '\\':
                    console.log("Got smacked on the rock like a dog!");
                    console.log(i + ' ' + pos);
                    return;
                    break;
                default:
                    break;
            }
        }

        if (!ahaa) {
            pos = inputLine.indexOf('o');
        }

        if (pos > -1) {
            ahaa = true;
        }
    }
}

solve([
    '--o----------------------',
    '>------------------------',
    '>------------------------',
    '>-----------------/\\-----',
    '-----------------/--\\----',
    '>---------/\\----/----\\---',
    '---------/--\\--/------\\--',
    '<-------/----\\/--------\\-',
    '\\------/----------------\\',
    '-\\____/------------------']);

solve([
    "-------------o-<<--------",
    "-------->>>>>------------",
    "---------------->-<---<--",
    "------<<<<<-------/\\--<--",
    "--------------<--/-<\\----",
    ">>--------/\\----/<-<-\\---",
    "---------/<-\\--/------\\--",
    "<-------/----\\/--------\\-",
    "\\------/--------------<-\\",
    "-\\___~/------<-----------"]);