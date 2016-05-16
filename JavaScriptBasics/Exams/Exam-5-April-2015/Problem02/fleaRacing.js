/**
 * Created by emily on 4/5/15.
 */

function solve(input) {
    var jumpsAllowed,
        length,
        data,
        flea,
        jumpDistance,
        dies = [];

    jumpsAllowed = Number(input[0]);
    length = Number(input[1]);

    for (var i = 2; i < input.length; i++) {
        data = input[i].split(', ');
        flea = data[0];
        jumpDistance = data[1];
    }


    //for (var i = 0; i < length; i++) {
    //    if ((jumpDistance * jumpsAllowed / length) % 1 !== 0) {
    //        console.log('winner');
    //    }
    //
    //}


    for (var i = 0; i < length; i++) {
        dies.push('#');
    }

    console.log(dies.join(''));
    console.log(dies.join(''));



    //console.log(length);console.log(length);


}


solve(['10',
'19',
'angel, 9',
'Boris, 10',
'Georgi, 3',
'Dimitar, 7']);