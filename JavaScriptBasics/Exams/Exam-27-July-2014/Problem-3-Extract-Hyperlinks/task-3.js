/**
 * Created by emily on 3/25/15.
 */

function solve(input) {
    var html = input.join('\n'),
        regex = /<a\s+([^>]+\s+)?href\s*=\s*('([^']*)'|"([^"]*)|([^\s>]+))[^>]*>/g,
        match;
    while(match = regex.exec(html)) {
        var hrefValue = match[3];
        if (hrefValue === undefined) {
            hrefValue = match[4];
        }
        if (hrefValue === undefined) {
            hrefValue = match[5];
        }

        console.log(hrefValue);
    }
}

solve(['<!DOCTYPE html>\n<html>\n<head>\n<title>Hyperlinks< http://www.nakov.com class=\'new\'>nak</a></li></ul>'])
