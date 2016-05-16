function cloudManager(input) {
    var results = [];

    for (var i = 0; i < input.length; i++) {
        var data = input[i].split(/\s+/);
        var file = data[0];
        var extension = data[1];
        var memory = parseFloat(data[2]);
        if (!results[extension]) {
            results[extension] = { 'files': [], 'memory': [] };
        }
        results[extension].files.push(file);
        results[extension].memory.push(memory);
    }


    for (var key in results) {
        results[key].memory = getAvg(results[key].memory);
        results[key].files.sort();
    }

    var output = [];
    var keys = Object.keys(results);
    keys.sort();
    for (var i = 0; i < keys.length; i++) {
        output[keys[i]] = results[keys[i]];
    }
    var outputObj = toObject(output);
    console.log(JSON.stringify(outputObj));

    function getAvg(arr) {
        var sum = 0;
        for (var i = 0; i < arr.length; i++) {
            sum += arr[i];
        }
        return sum.toFixed(2);
    }

    function toObject(arr) {
        var obj = { };
        for (var key in arr) {
            obj[key] = arr[key];
        }
        return obj;
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
    cloudManager(arr);
});
