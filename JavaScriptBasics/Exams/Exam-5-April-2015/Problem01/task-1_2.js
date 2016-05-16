/**
 * Created by Emily on 28-Jan-16.
 */
function solve(input) {
    var data,
        coin,
        value,
        sum = 0,
        gold,
        silver,
        bronze;

    for (var line in input) {
        data = input[line].split(/\s+/g);
        coin = data[0].toLowerCase();

        if (coin === 'coin') {
            value = Number(data[1]);

            if (value % 1 === 0 && value > 0) {
                sum += value;
            }
        }
    }

    gold = Math.floor(sum / 100);
    silver = Math.floor(sum / 10 % 10);
    bronze = sum % 10;

    console.log('gold : ' + gold);
    console.log('silver : ' + silver);
    console.log('bronze : ' + bronze);
}

solve(['coin 1','coin 2', 'coin 5', 'coin 10', 'coin 20', 'coin 50', 'coin 100', 'coin 200', 'coin 500','cigars 1']);
solve(['coin 1', 'coin two', 'coin 5', 'coin 10.50', 'coin 20', 'coin 50', 'coin hundred', 'cigars 1']);