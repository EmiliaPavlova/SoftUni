/**
 * Created by emily on 3/25/15.
 */

function solve(input) {
    var startNum = Number(input[0]),
        endNum = Number(input[1]);

    function isDoubleRakiaNum(num) {
        var numString = '' + num,
            existingPairs = {};
        for (var i = 1; i < numString.length; i++) {
            var pair = numString.substr(i - 1, 2);
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

    console.log("<ul>");
    for (var num = startNum; num <= endNum; num++) {
        if (isDoubleRakiaNum(num)) {
            console.log("<li>" + "<span class='rakiya'>" + num +
                "</span><a href=\"view.php?id=" + num + ">View</a></li>")
        } else {
            console.log("<li><span class='num'>" + num + "</span></li>")
        }
    }
    console.log("</ul>")
}

solve([11210, 11215]);