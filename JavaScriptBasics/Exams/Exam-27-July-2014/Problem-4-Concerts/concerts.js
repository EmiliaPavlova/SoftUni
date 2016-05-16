function concerts(input) {
    var concertInfo = { };
    for (var i in input) {
        var tokens = input[i].split('|');
        var band = tokens[0].trim();
        var town = tokens[1].trim();
        var date = tokens[2].trim();
        var venue = tokens[3].trim();

        if (!concertInfo[town]) {
            concertInfo[town] = { };
        }
        if (!concertInfo[town][venue]) {
            concertInfo[town][venue] = [];
        }
        if (concertInfo[town][venue].indexOf(band) == -1) {
            concertInfo[town][venue].push(band);
        }
    }
    
    // Sort the concertInfo structure
    concertInfo = sortObjectProperties(concertInfo);
    for (var town in concertInfo) {
        concertInfo[town] = sortObjectProperties(concertInfo[town]);
        for (var venue in concertInfo[town]) {
            concertInfo[town][venue].sort();
        }
    }

	// Print the concertInfo as JSON string
    console.log(JSON.stringify(concertInfo));

    function sortObjectProperties(obj) {
        var keysSorted = Object.keys(obj).sort();
        var sortedObj = {};
        for (var i = 0; i < keysSorted.length; i++) {
            var key = keysSorted[i];
            sortedObj[key] = obj[key];
        }
        return sortedObj;
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
    concerts(arr);
});
