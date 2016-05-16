function theNumbers(input) {
    var text = input[0];
    var numbers = text.split(/\D+/g).filter(Boolean);
    for (var i = 0; i < numbers.length; i++) {
        var num = parseInt(numbers[i]);
        var hex = num.toString(16);
        var leadingZeros = 4 - hex.length;
		var upperHex = Array(leadingZeros + 1).join('0') + hex;
        numbers[i] = '0x' + upperHex.toUpperCase();
    }
    console.log(numbers.join('-'));
}

// ------------------------------------------------------------mbezn5tu
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
    theNumbers(arr);
});
