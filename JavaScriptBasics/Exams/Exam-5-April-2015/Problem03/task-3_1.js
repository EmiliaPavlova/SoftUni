/**
 * Created by emily on 5/12/15.
 */
function solve(input) {
    var directions = input[0].split(', '),
        garden = [],
        moves = [],
        rowPosition = 0,
        colPosition = 0,
        goshko = {
            '&': 0,
            '*': 0,
            '#': 0,
            '!': 0,
            'wall hits': 0
        };
    for (var i = 1; i < input.length; i++) {
        garden.push(input[i].split(', '));
    }

    directions.forEach(move);
    console.log(JSON.stringify(goshko));
    console.log(moves.length > 0 ? moves.join('|') : 'no');

    function move(direction) {
        switch (direction) {
            case 'right':
                if (colPosition + 1 < garden[rowPosition].length) {
                    colPosition++;
                    checkVegetable();
                } else {
                    goshko['wall hits']++;
                }
                break;
            case 'left':
                if (colPosition - 1 >= 0) {
                    colPosition--;
                    checkVegetable();
                } else {
                    goshko['wall hits']++;
                }
                break;
            case 'up':
                if (rowPosition - 1 >= 0) {
                    rowPosition--;
                    checkVegetable();
                } else {
                    goshko['wall hits']++;
                }
                break;
            case 'down':
                if (rowPosition + 1 < garden.length) {
                    rowPosition++;
                    checkVegetable();
                } else {
                    goshko['wall hits']++;
                }
                break;
        }
    }
    function checkVegetable() {
        garden[rowPosition][colPosition] = garden[rowPosition][colPosition]
            .replace(/\{([&*#!])\}/g, function(match, group) {
            goshko[group] += 1;
            return '@';
        });
        moves.push(garden[rowPosition][colPosition]);
    }
}

solve(['right, up, up, down',
    'asdf, as{#}aj{g}dasd, kjldk{}fdffd, jdflk{#}jdfj',
    'tr{X}yrty, zxx{*}zxc, mncvnvcn, popipoip',
    'poiopipo, nmf{X}d{X}ei, mzoijwq, omcxzne']);

solve(['up, right, left, down',
    'as{!}xnk']);