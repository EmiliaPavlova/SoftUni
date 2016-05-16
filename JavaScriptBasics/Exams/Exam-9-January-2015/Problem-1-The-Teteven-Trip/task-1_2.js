/**
 * Created by emily on 4/3/15.
 */

function solve(array) {
    var input,
        carModel,
        fuelType,
        fuelConsumption,
        routeNumber,
        luggage,
        totalConsumption;

    for (var i in array) {
        input = array[i].split(' ');
        carModel = input[0];
        fuelType = input[1];
        routeNumber = Number(input[2]);
        luggage = Number(input[3]);

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
        fuelConsumption += luggage * 0.01;

        if (routeNumber === 1) {
            totalConsumption = fuelConsumption * 110 / 100;
            totalConsumption += fuelConsumption * 0.3 * 10 / 100;
        } else {
            totalConsumption = fuelConsumption * 95 / 100;
            totalConsumption += fuelConsumption * 0.3 * 30 / 100;
        }
        totalConsumption = Math.round(totalConsumption);

        console.log(carModel + ' ' + fuelType + ' ' + routeNumber + ' ' + totalConsumption);
    }
}

solve(['BMW petrol 1 320.5',
    'Golf petrol 2 150.75',
    'Lada gas 1 202',
    'Mercedes diesel 2 312.54']);