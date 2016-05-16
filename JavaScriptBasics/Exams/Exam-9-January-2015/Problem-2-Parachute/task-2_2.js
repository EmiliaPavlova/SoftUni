/**
 * Created by emily on 4/3/15.
 */

function solve(array) {
    var input,
        pos,
        parachute = false;

    for (var i in array) {
        input = array[i];

        if (parachute) {
            for (var c in input) {
                if (input[c] === '>') {
                    pos += 1;
                } else if (input[c] === '<') {
                    pos -= 1;
                }
            }
            switch (input[pos]) {
                case '_':
                    console.log('Landed on the ground like a boss!');
                    console.log(i + ' ' + pos);
                    return;
                    break;
                case '~':
                    console.log('Drowned in the water like a cat!');
                    console.log(i + ' ' + pos);
                    return;
                    break;
                case '/':
                case '|':
                case '\\':
                    console.log('Got smacked on the rock like a dog!');
                    console.log(i + ' ' + pos);
                    return;
                    break;
            }
        } else {
            pos = input.indexOf('o');
            if (pos > -1) {
                parachute = true;
            }
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
    '-\\____/------------------'
]);

solve([
    '-------------o-<<--------',
    '-------->>>>>------------',
    '---------------->-<---<--',
    '------<<<<<-------/\\--<--',
    '--------------<--/-<\\----',
    '>>--------/\\----/<-<-\\---',
    '---------/<-\\--/------\\--',
    '<-------/----\\/--------\\-',
    '\\------/--------------<-\\',
    '-\\___~/------<-----------'
]);