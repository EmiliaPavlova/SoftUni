/**
 * Created by emily on 5/8/15.
 */
function solve(input) {
    var fuelConsumption,
        totalConsumption;

    for (var i in input) {
        var data = input[i].split(' '),
            model = data[0],
            fuelType = data[1],
            route = Number(data[2]),
            weight = Number(data[3]);

        fuelConsumption = 10;
        switch (fuelType) {
            case 'gas':
                fuelConsumption *= 1.2;
                break;
            case 'diesel':
                fuelConsumption *= 0.8;
                break;
            case 'petrol':
            default:
                break;
        }
        fuelConsumption += weight * 0.01;

        if (route === 1) {
            totalConsumption = fuelConsumption * 110 / 100;
            totalConsumption += fuelConsumption * 0.3 * 10 / 100;
        } else {
            totalConsumption = fuelConsumption * 95 / 100;
            totalConsumption += fuelConsumption * 0.3 * 30 / 100;
        }
        totalConsumption = Math.round(totalConsumption);

        console.log(model + ' ' + fuelType + ' ' + route + ' ' + totalConsumption);
    }
}

solve(['BMW petrol 1 320.5',
    'Golf petrol 2 150.75',
    'Lada gas 1 202',
    'Mercedes diesel 2 312.54']);