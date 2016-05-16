function evaluate(array) {

    var carModel, fuelType, road, luggageWeight;
    var currentLine;
    var fuelConsumption, totalConsumption;

    for(var i in array) {
        currentLine = array[i].split(" ");
        //console.log(currentLine);

        carModel = currentLine[0];
        fuelType = currentLine[1];
        road = Number(currentLine[2]);
        luggageWeight = Number(currentLine[3]);

        fuelConsumption = 10;
        switch (fuelType) {
            case "gas":
                fuelConsumption *= 1.2;
                break;
            case "diesel":
                fuelConsumption *= 0.8;
                break;
            case "petrol":
            default:
                break;
        }

        fuelConsumption += luggageWeight * 0.01;

        if (road == 1) {
            totalConsumption = fuelConsumption * 110 / 100;
            totalConsumption += fuelConsumption * 0.3 * 10 / 100;
        }
        else {
            totalConsumption = fuelConsumption * 95 / 100;
            totalConsumption += fuelConsumption * 0.3 * 30 / 100;
        }
        totalConsumption = Math.round(totalConsumption);

        console.log(carModel + " " + fuelType + " " + road + " " + totalConsumption);
    }
}

var input = ['BMW petrol 1 320.5',
    'Golf petrol 2 150.75',
    'Lada gas 1 202',
    'Mercedes diesel 2 312.54'];

evaluate(input);
