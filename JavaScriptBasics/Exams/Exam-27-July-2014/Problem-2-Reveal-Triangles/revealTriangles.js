function revealTriangles(input) {
    // Initialize the output as char[][], holding the input chars
    var output = [];
    for (var row = 0; row < input.length; row++) {
        output[row] = input[row].split('');
    }
    
    // Replace all triangles with '*' (with overlapping)
    for (var row = 1; row < input.length; row++) {
        var maxCol = Math.min(
            input[row - 1].length - 2,
            input[row].length - 3);
        for (var col = 0; col <= maxCol; col++) {
            var a = input[row][col];
            var b = input[row][col + 1];
            var c = input[row][col + 2];
            var d = input[row - 1][col + 1];
            if (a == b && b == c & c == d) {
                // Triangle found --> fill it with '*'
                output[row][col] = '*';
                output[row][col + 1] = '*';
                output[row][col + 2] = '*';
                output[row - 1][col + 1] = '*';
            }
        }
    }
    
    // Print the result
    for (var row = 0; row < input.length; row++) {
        console.log(output[row].join(''));
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
    revealTriangles(arr);
});

revealTriangles(['abcdexgh\
bbbdxxxh\
abcxxxxx'])