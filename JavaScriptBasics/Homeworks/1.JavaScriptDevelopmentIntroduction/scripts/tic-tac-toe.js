var board = [[null, null, null],
            [null, null, null],
            [null, null, null]];

var firstTurn = true;

function changeValue(arr) {
    var row = arr[1],
        col = arr[3];

    // check whose turn it is
    if (board[row][col] === null) {
        if (firstTurn) {
            document.getElementById(arr).innerHTML = 'X';
            board[row][col] = 'X';
            firstTurn = !firstTurn;
            if (checkWinner(row, col)) {
                alert('First player wins!');
                window.location.reload();
            }
        } else {
            document.getElementById(arr).innerHTML = 'O';
            document.getElementById(arr).style.color = '#000';
            board[row][col] = 'O';
            firstTurn = !firstTurn;
            if (checkWinner(row, col)) {
                alert('Second player wins!');
                window.location.reload();
            }
        }
    }
    if (isFieldFull()) {
        alert("Draw!");
        window.location.reload();
    }
}

function checkWinner(row, col) {
    if (
        board[row][0] === board[row][1] &&
        board[row][1] === board[row][2]) {
        colorWinner('[' + row + ',0]', '[' + row + ',1]', '[' + row + ',2]');
        return true;
    }
    if (
        board[0][col] === board[1][col] &&
        board[1][col] === board[2][col]) {
        colorWinner('[0,' + col + ']', '[1,' + col + ']', '[2,' + col + ']');
        return true;
    }
    if (board[1][1] !== null &&
        board[0][0] === board[1][1] &&
        board[1][1] === board[2][2]) {
        colorWinner('[0,0]', '[1,1]', '[2,2]');
        return true;
    }
    if (board[1][1] !== null &&
        board[0][2] === board[1][1] &&
        board[1][1] === board[2][0]) {
        colorWinner('[0,2]', '[1,1]', '[2,0]');
        return true;
    }
    return false;
}

function colorWinner(div1, div2, div3) {
    var divs = [div1, div2, div3];
    var color = '';

    if  (firstTurn === true) {
        color = '#DC143C';
    } else {
        color = '#000';
    }
    for (var i = 0; i < divs.length; i++) {
        document.getElementById(divs[i].toString()).style.backgroundColor = color;
    }
}

function isFieldFull () {
    for (var i = 0; i < 9; i++) {
        if (board[Math.floor(i / 3)][i % 3] === null) {
            return false;
        }
    }
    return true;
}