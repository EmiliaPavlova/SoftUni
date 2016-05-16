/**
 * Created by emily on 5/6/15.
 */
function solve(input) {
    var html = input.join('\n'),
        regex = /<a\s+([^>]+\s+)?href\s*=\s*('([^']*)'|"([^"]*)|([^\s>]+))[^>]*>/g,
    match;

    while (match = regex.exec(html)){
        var hrefValue = match[3];if (hrefValue === undefined) {
            hrefValue = match[4];
        }
        if (hrefValue === undefined) {
            hrefValue = match[5];
        }

        console.log(hrefValue);
    }
}

solve(['<a href="http://softuni.bg" class="new"></a>']);
solve(['<p>This text has no links</p>']);
solve(['' +
'<!DOCTYPE html>',
'<html>',
'<head>',
    '<title>Hyperlinks</title>',
    '<link href="theme.css" rel="stylesheet" />',
'</head>',
'<body>',
'<ul><li><a   href="/"  id="home">Home</a></li><li><a class="selected" href=/courses>Courses</a>',
'</li><li><a href = \'/forum\' >Forum</a></li><li><a class="href" onclick="go()" href= "#">Forum</a></li>',
    '<li><a id="js" href = "javascript:alert(\'hi yo\')" class="new">click</a></li>',
    '<li><a id=\'nakov\' href = http://www.nakov.com class=\'new\'>nak</a></li></ul>',
    '<a href="#empty"></a>',
    '<a id="href">href=\'fake\'<img src=\'http://abv.bg/i.gif\'',
    'alt=\'abv\'/></a><a href="#">&lt;a href=\'hello\'&gt;</a>',
        '<!-- This code is commented:',
          '<a href="#commented">commentex hyperlink</a> -->',
    '</body>']);