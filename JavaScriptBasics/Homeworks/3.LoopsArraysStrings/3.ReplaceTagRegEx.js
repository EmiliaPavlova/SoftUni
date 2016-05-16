function solve(input) {
    input = input.replace((/<a(\shref=.*)>(.*)<\/a>/ig), '[URL$1]$2[/URL]');

    console.log(input);
}

solve('<ul><li><a href=http://softuni.bg>SoftUni</a></li></ul>')

