/**
 * Created by emily on 5/6/15.
 */
function solve(input) {
    var startNumber = Number(input[0]),
        endNumber = Number(input[1]);

    console.log("<ul>");

    for (var i = startNumber; i <= endNumber; i++) {
        if (doubleRakiya(i)) {
            console.log("<li>" + "<span class='rakiya'>" + i +
                "</span><a href=\"view.php?id=" + i + ">View</a></li>")
        } else {
            console.log("<li><span class='num'>" + i + "</span></li>");
        }
    }
    console.log("</ul>");

    function doubleRakiya(num) {
        num = String(num);
        var existing = {};
        for (var i = 1; i < num.length; i++) {
            var pair = num.substr(i-1, 2);
            if (existing[pair]) {
                if (i - existing[pair] >= 2) {
                    return true;
                }
            } else {
                existing[pair] = i;
            }
        }
        return false;
    }
}

solve(['11210',
    '11215']);