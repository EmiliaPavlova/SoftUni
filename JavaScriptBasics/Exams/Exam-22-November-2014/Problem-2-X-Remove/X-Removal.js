function xRemove(arr) {
   var matrix = [];
   var resultMatrix = [];

   arr.forEach(function(string) {
      matrix.push(string.toLowerCase().split(''));
      resultMatrix.push(string.split(''));
   });

   for (var row = 0; row < matrix.length - 2; row++) {
      for (var col = 0; col < matrix[row].length; col++) {
         var char = matrix[row][col];
         var isX = matrix[row][col + 2] == char &&
             matrix[row + 1][col + 1] == char &&
             matrix[row + 2][col] == char &&
             matrix[row + 2][col + 2] == char;

         if (isX) {
            resultMatrix[row][col] = " ";
            resultMatrix[row][col + 2] = " ";
            resultMatrix[row + 1][col + 1] = " ";
            resultMatrix[row + 2][col] = " ";
            resultMatrix[row + 2][col + 2] = " ";
         }
      }
   }
   var resultArray = [];
   resultMatrix.forEach(function(str) {
      resultArray.push(str.join('').split(" ").join(''));
   });

   resultArray.forEach(function(item) {
      console.log(item);
   });
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
    xRemove(arr);
});