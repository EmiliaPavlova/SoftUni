/**
 * Created by emily on 5/8/15.
 */
function solve(input) {
    var parachute = false;
    var pos;

    for (var i in input) {
        var row = input[i];

        if (parachute) {
            for (var ch in row) {
                if (row[ch] === '>') {
                    pos += 1;
                } else if (row[ch] === '<') {
                    pos -= 1;
                }
            }
            switch (row[pos]) {
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
            pos = row.indexOf('o');
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