/**
 * Created by emily on 4/6/15.
 */
function solve(input) {
    var data,
        item,
        value,
        sum = [],
        gold,
        silver,
        bronze;

    for (var i in input) {
        data = input[i].split(' ');
        item = data[0].toLowerCase();
        if (item === 'coin') {
            value = data[1];

            if(!isNaN(value) && value % 1 === 0 && value > 0) {
                sum.push(value);
            }
        }
    }

    var totalValue = 0;
    for (var i = 0; i < sum.length; i++) {
        totalValue += Number(sum[i]);
    }

    gold = Math.floor(totalValue / 100);
    totalValue = totalValue % 100;
    silver = Math.floor(totalValue / 10);
    totalValue = totalValue % 10;
    bronze = totalValue;


    console.log('gold : ' + gold);
    console.log('silver : ' + silver);
    console.log('bronze : ' + bronze);
}


solve(['coin 1', 'coin 2', 'coin 5', 'coin 10', 'coin 20', 'coin 50', 'coin 100',
    'coin 200', 'coin 500', 'cigars 1']);

solve(['coin 1', 'coin two', 'coin 5', 'coin 10.50', 'coin 20', 'coin 50', 'coin hundred',
    'cigars 1']);