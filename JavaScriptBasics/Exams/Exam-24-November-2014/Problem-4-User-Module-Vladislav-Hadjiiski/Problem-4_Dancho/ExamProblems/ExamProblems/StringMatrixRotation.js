function solve(args) {
    var degrees = args[0].split(/\D+/)[1] % 360;
    var matrix = [];
    var len = args.length;
    var maxLength = 0;
    for (var i = 1; i < len; i += 1) {
        matrix[i - 1] = args[i].split("");
        if (args[i].length > maxLength) {
            maxLength = args[i].length;
        }
    }

    len = matrix.length;
    for (var row = 0; row < len; row += 1) {
        for (var col = matrix[row].length; col < maxLength; col++) {
            matrix[row].push(" ");
        }
    }

    rotateMatrix(matrix, degrees);

    function rotateMatrix(matrix, degrees) {
        var row, col;
        switch (degrees) {
            case 0:
                for (row = 0; row < matrix.length; row++) {
                    var rowAsString = matrix[row].join("");
                    console.log(rowAsString);
                }
                break;
            case 90:
                for (col = 0; col < matrix[0].length; col++) {
                    var rowAsString = "";
                    for (row = 0; row < matrix.length; row++) {
                        rowAsString += matrix[row][col];
                    }
                    console.log(rowAsString.split("").reverse().join(""));
                }
                break;
            case 180:
                for (row = matrix.length - 1; row >= 0; row--) {
                    var rowAsString = matrix[row].reverse().join("");
                    console.log(rowAsString);
                }
                break;
            case 270:
                for (col = matrix[0].length - 1; col >= 0; col--) {
                    var rowAsString = "";
                    for (row = 0; row < matrix.length; row++) {
                        rowAsString += matrix[row][col];
                    }
                    console.log(rowAsString);
                }
                break;
        }
    }
}
