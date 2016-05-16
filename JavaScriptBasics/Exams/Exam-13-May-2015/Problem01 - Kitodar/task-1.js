/**
 * Created by Emily on 29-Jan-16.
 */
function solve(input) {
    var regex= /mine\s*(.*?)\s*-\s*(\w+)\s*:\s*([0-9]+)/g,
        match,
        mineName,
        ore,
        amount,
        gold = 0,
        silver = 0,
        diamonds = 0;

    while (match = regex.exec(input)) {
        mineName = match[1];
        ore = match[2];
        amount = Number(match[3]);

        switch (ore) {
            case 'gold':
                gold += amount;
                break;
            case 'silver':
                silver += amount;
                break;
            case 'diamonds':
                diamonds += amount;
                break;
        }
    }

    console.log('*Silver: ' + silver);
    console.log('*Gold: ' + gold);
    console.log('*Diamonds: ' + diamonds);
}

solve([
    'mine bobovDol - gold: 10"',
    'mine medenRudnik - silver: 22"',
    'mine chernoMore - shrimps : 24"',
    'gold: 50']);

solve(['mine bobovdol - gold : 10',
    'mine - diamonds : 5',
    'mine colas - wood : 10',
    'mine myMine - silver :  14',
    'mine silver:14 - silver : 14']);