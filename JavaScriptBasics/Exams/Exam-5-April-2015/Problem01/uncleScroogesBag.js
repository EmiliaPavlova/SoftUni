/**
 * Created by emily on 4/5/15.
 */

function solve(input) {
    var data,
        item,
        value,
        gold,
        silver,
        bronze;

    function checkNum(value) {
        var regex = /^[0-9]+$/;
        return (regex.test(value)) ? true : false;
    }

    var totalValue = 0;
    for (var i in input) {
        data = input[i].split(' ');
        item = data[0].toLowerCase();
        value = Number(data[1]);
        if (item === 'coin' && checkNum(value)) {
            totalValue += value;
        }
    }

    gold =  Math.floor(totalValue / 100);
    silver = Math.floor(totalValue / 10 % 10);
    bronze = totalValue % 10;

    console.log('gold : ' + gold);
    console.log('silver : ' + silver);
    console.log('bronze : ' + bronze);
}

solve(['coin 1', 'coin 2', 'coin 5', 'coin 10', 'coin 20', 'coin 50', 'coin 100',
    'coin 200', 'coin 500', 'cigars 1']);

solve(['coin 1', 'coin two', 'coin 5', 'coin 10.50', 'coin 20', 'coin 50', 'coin hundred',
    'cigars 1']);