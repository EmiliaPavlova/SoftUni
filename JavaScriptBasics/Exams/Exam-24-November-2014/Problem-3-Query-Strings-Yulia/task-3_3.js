/**
 * Created by emily on 5/7/15.
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

    for (var i in input) {
        currentLine = input[i];
        lineObject = {};

        while (match = regex.exec(currentLine)) {
            key = match[1].replace(whitespaceRegex, ' ').trim();
            value = match[2].replace(whitespaceRegex, ' ').trim();

            if (!lineObject[key]) {
                lineObject[key] = [];
            }
            lineObject[key].push(value);
        }
        output = '';
        for (var line in lineObject) {
            output += line + '=[' + lineObject[line].join(', ') + ']';
        }
        //console.log(lineObject);
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