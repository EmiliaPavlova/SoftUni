/**
 * Created by emily on 4/4/15.
 */

function solve(input) {
    var bill = Number(input[0]),
        mood = input[1],
        tip;

    switch (mood) {
        case 'happy':
            tip = bill * 0.1;
            break;
        case 'married':
            tip = bill * 0.0005;
            break;
        case 'drunk':
            tip = bill * 0.15;
            tip = Math.pow(tip, tip.toString().charAt(0));
            break;
        default:
            tip = bill * 0.05;
            break;
    }
    tip = tip.toFixed(2);

    console.log(tip);
}

solve(['120.44',
    'happy']);