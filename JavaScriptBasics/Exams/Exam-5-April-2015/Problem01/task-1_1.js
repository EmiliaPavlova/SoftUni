/**
 * Created by emily on 5/8/15.
 */
function solve(input) {
    var gold,
        silver,
        bronze,
        data,
        coin,
        value,
        sum = 0;

    for (var i in input) {
        data = input[i].split(/\s+/g);
        coin = data[0].toLowerCase();
        if (coin === 'coin') {
            value = Number(data[1]);
            if (value % 1 === 0 && value > 0) {
                sum += value;
            }
        }
    }
    gold = Math.floor(sum / 100 );
    silver = Math.floor(sum / 10 % 10);
    bronze = sum % 10;
    console.log('gold : ' + gold);
    console.log('silver : ' + silver);
    console.log('bronze : ' + bronze);
}

solve(['coin 1','coin 2', 'coin 5', 'coin 10', 'coin 20', 'coin 50', 'coin 100', 'coin 200', 'coin 500',
    'cigars 1']);

solve(['coin -1', 'coin 2', 'coin -5', 'coin 10.50', 'coin 2002', 'coin 50', 'coin -100', 'cigars 1']);