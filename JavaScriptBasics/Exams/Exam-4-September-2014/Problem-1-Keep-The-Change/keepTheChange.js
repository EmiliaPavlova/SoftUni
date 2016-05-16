function keepTheChange(input) {
	var bill = parseFloat(input[0]);
	var mood = input[1];

	var tip = getTip(bill, mood);
	console.log(tip.toFixed(2));

    function getTip(bill, mood) {
        var tipPercent;
        switch (mood) {
            case 'drunk':
                var tip = 0.15 * bill;
                return Math.pow(tip, tip.toString().charAt(0));
            case 'happy':
                tipPercent = 0.1;
                break;
            case 'married':
                tipPercent = 0.0005;
                break;
            default:
                tipPercent = 0.05;
                break;
        }
        return tipPercent * bill;
    }
}

//keepTheChange(['3', 'greedy']);

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
    keepTheChange(arr);
});
