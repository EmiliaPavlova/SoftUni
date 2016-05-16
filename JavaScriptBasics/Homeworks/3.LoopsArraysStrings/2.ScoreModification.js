function solve(input){
    var validScores = input.map(function(number) {
        return number = Number((number * 0.8).toFixed(1));
    });

    validScores = validScores.filter(function(number) {
        return (number > 0 && number < 400);
    });

    validScores.sort(function(x, y) {
        return x > y;
    });

    console.log(validScores)
}

solve([200, 120, 23, 67, 350, 420, 170, 212, 401, 615, -1])