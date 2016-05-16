/**
 * Created by emily on 4/2/15.
 */

function solve(input) {
    var regex = /([^=&?]+)=([^=&?]+)/g,
        whitespaceRegex = /(\+|%20)+/g,
        currentLine,
        lineObject,
        match,
        key,
        value,
        output;

    for (var line in input) {
        currentLine = input[line];
        lineObject = {};
        match = regex.exec(currentLine);

        while (match) {
            key = match[1].replace(whitespaceRegex, ' ').trim();
            value = match[2].replace(whitespaceRegex, ' ').trim();

            if (!lineObject[key]) {
                lineObject[key] = [];
            }
            lineObject[key].push(value);
            match = regex.exec(currentLine);
        }
        output = '';
        for (var i in lineObject) {
            output += i + '=[' + lineObject[i].join(', ') + ']';
        }
        console.log(output);
    }
}

solve(['login=student&password=student']);

solve(['field=value1&field=value2&field=value3',
    'http://example.com/over/there?name=ferret']);

solve(['foo=%20foo&value=+val&foo+=5+%20+203',
    'foo=poo%20&value=valley&dog=wow+',
    'url=https://softuni.bg/trainings/coursesinstances/details/1070',
    'https://softuni.bg/trainings.asp?trainer=nakov&course=oop&course=php']);