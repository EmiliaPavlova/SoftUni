function doubleRakiyaNumbers(input) {
    var startNum = Number(input[0]);
    var endNum = Number(input[1]);
    console.log("<ul>");
    for (var num = startNum; num <= endNum; num++) {
        if (isDoubleRakiyaNum(num)) {
            console.log("<li>" + 
                "<span class='rakiya'>" + num + "</span>" +
                "<a href=\"view.php?id=" + num +"\">View</a>" +
                "</li>")
        } else {
            console.log("<li><span class='num'>" + num + "</span></li>")
        }
    }
    console.log("</ul>");
    
    function isDoubleRakiyaNum(num) {
        var numStr = '' + num;
        var existingPairs = { };
        for (var i = 1; i < numStr.length; i++) {
            var pair = numStr.substr(i - 1, 2);
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



// ------------------------------------------------------------
// Read the input from the console as array and process it
// Remove all below code before submitting to the judge system!
// ------------------------------------------------------------

var arr = [];
require('readline').createInterface({
    input: process.stdin,
    output: process.stdout
}).on('line', function (line) {
    arr.push(line);
}).on('close', function () {
    doubleRakiyaNumbers(arr);
});
