/**
 * Created by emily on 5/7/15.
 */
function solve(input) {
    var line,
        date,
        min = new Date('January 1, 1900'),
        max = new Date('January 1, 2015'),
        breakPoint = new Date('May 25, 1973'),
        isHater = false,
        isFan = false,
        dateArray = [];

    for (var i in input) {
        line = input[i].split('.');
        date = new Date(line[2], line[1] - 1, line[0]);

        if (date > min && date < breakPoint) {
            isHater = true;
            dateArray.push(date);
        }
        if (date >= breakPoint && date < max) {
            isFan = true;
            dateArray.push(date);
        }
    }
    dateArray.sort(function(a, b) {
        return a.getTime() - b.getTime();
    });

    if (!dateArray.length) {
        console.log('No result');
        return;
    }
    if (isFan) {
        console.log('The biggest fan of ewoks was born on ' + dateArray[dateArray.length - 1].toDateString());
    }
    if (isHater) {
        console.log('The biggest hater of ewoks was born on ' + dateArray[0].toDateString());
    }
}

solve(['22.03.2014',
    '17.05.1933',
    '10.10.1954']);