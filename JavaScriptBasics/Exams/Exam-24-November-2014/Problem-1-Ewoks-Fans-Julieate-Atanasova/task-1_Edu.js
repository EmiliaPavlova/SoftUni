/**
 * Created by emily on 4/1/15.
 */

function solve(input) {
    var currentDate,
        index,
        youngestPerson = new Date(1900,0,1),
        oldestPerson = new Date(2015,0,1),
        borderDate = new Date(1973,4,25),
        maxBorder = new Date(2015,0,1),
        minBorder = new Date(1900,0,1),
        changeInUpperIf = false,
        changeInLowerIf = false;
    for (index in input) {
        var dateTokens = input[index].split('.');
        currentDate = new Date(dateTokens[2], dateTokens[1] - 1, dateTokens[0]);
        if (currentDate >= borderDate  && currentDate < maxBorder && currentDate > youngestPerson) {
            youngestPerson = currentDate;
            changeInUpperIf = true;
        }
        else if (currentDate < borderDate  && currentDate > minBorder && currentDate < oldestPerson) {
            oldestPerson = currentDate;
            changeInLowerIf = true;
        }
    }

    if (!changeInLowerIf && !changeInUpperIf) {
        console.log('No result');
    }
    else if (changeInUpperIf && !changeInLowerIf) {
        console.log('The biggest fan of ewoks was born on ' + youngestPerson.toDateString());
    }
    else if (!changeInUpperIf && changeInLowerIf) {
        console.log('The biggest hater of ewoks was born on ' + oldestPerson.toDateString());
    } else {
        console.log('The biggest fan of ewoks was born on ' + youngestPerson.toDateString());
        console.log('The biggest hater of ewoks was born on ' + oldestPerson.toDateString());
    }
}

solve(['22.03.2014',
    '17.05.1933',
    '10.10.1954'
]);
solve(['22.03.2000']);
solve(['22.03.1700', '01.07.2020']);