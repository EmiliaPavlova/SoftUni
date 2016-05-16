function solve(input) {
    var firstString = input.substring(0, 9);
    var secondString = input.substring(9);
    secondString = secondString.replace('<a', '[URL');
    secondString = secondString.replace('>', ']');
    secondString = secondString.replace('</a>', '[/URL]');

    console.log(firstString + secondString);
}

solve("<ul>\n<li>\n<a href=http://softuni.bg>SoftUni</a>\n</li>\n</ul>")

