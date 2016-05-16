function solve(input) {
    var degrees = parseInt(/[0-9]+/.exec(input[0])),
        matrix = [],
        maxLength = 0,
        i,
        j,
        currentLine,
        currentToken;

    for (i = 1; i < input.length ; i++) {
        if (input[i].length > maxLength) {
            maxLength = input[i].length;
        }
    }

    for (i = 0; i < input.length - 1; i++) {
        matrix[i] = [];
        currentLine = input[i + 1].split('');
        for (j = 0; j < maxLength; j++) {
            currentToken = currentLine[j] || ' ';
            matrix[i].push(currentToken);
        }
    }

    degrees = degrees % 360;

    while (degrees > 0) {
        matrix = rotate(matrix);
        degrees -= 90;
    }

    for (var obj in matrix) {
        console.log(matrix[obj].join(''));
    }

    function rotate(arr) {
        var rowLimit = arr[0].length,
            colLimit = arr.length,
            newMatrix = [],
            k,
            m;
        for (k = 0; k < rowLimit; k++) {
            newMatrix[k] = [];
            for (m = colLimit - 1; m >= 0; m--) {
                //console.log(arr[m][k]);
                newMatrix[k].push(arr[m][k]);
            }
        }
        return newMatrix;
    }
}


solve(['Rotate(180)',
        'hello',
        'softuni',
        'exam']
);