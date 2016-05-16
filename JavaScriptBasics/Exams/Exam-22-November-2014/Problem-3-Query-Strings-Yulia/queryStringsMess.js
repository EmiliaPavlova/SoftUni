/**
 * Created by emily on 3/24/15.
 */

function solve(args) {
    var regex = /([^=&?]+)=([^=&?]+)/g,
        whiteSpaceRegex = /(\+|%20)+/g,
        output;

    for (var lineIndex in args) {
        var currentLine = args[lineIndex],
            lineObject = {},
            match = regex.exec(currentLine);

        while(match) {
            var key = match[1].replace(whiteSpaceRegex, ' ').trim();
            var value = match[2].replace(whiteSpaceRegex, ' ').trim();

            if (!lineObject[key]) {
                lineObject[key] = [];
            }
            lineObject[key].push(value);
            match = regex.exec(currentLine);
        }
        output = '';
        for (var i in lineObject) {
            output = output + i + '=[' + lineObject[i].join(', ') + ']';
        }
        console.log(output);
    }
}

solve(['login=student&password=student']);

solve(['foo=%20foo&value=+val&foo+=5+%20+203',
    'foo=poo%20&value=valley&dog=wow+',
    'url=https://softuni.bg/trainings/coursesinstances/details/1070',
    'https://softuni.bg/trainings.asp?trainer=nakov&course=oop&course=php'])