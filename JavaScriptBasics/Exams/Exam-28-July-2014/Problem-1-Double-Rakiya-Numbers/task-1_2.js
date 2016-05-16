/**
 * Created by emily on 4/4/15.
 */

function solve(input) {
    var startNum = Number(input[0]),
        endNum = Number(input[1]);

    console.log('<ul>');

    for (var i = startNum; i <= endNum; i++) {
        if (doubleRakiya(i)) {
            console.log("<li>" + "<span class='rakiya'>" + i +
            "</span><a href=\"view.php?id=" + i + ">View</a></li>");
        } else {
            console.log("<li><span class='num'>" + i + "</span></li>");
        }
    }
    console.log("</ul>");

    function doubleRakiya(num) {
        num = String(num);
        var existingPairs = {};
        for (var i = 1; i < num.length; i++) {
            var pair = num.substr(i - 1, 2);
            if (existingPairs[pair]) {
                if (i - existingPairs[pair] >= 2) {
                    return true;
                }
            } else {
                existingPairs[pair] = i;
            }
        }
        return false;
    }
}

solve(['11210',
    '11215']);