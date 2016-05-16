function solve(input) {
    var arrNumbers = input.filter(function(number) {
        return !isNaN(number);
    });

    Array.prototype.occurs = function(num) {
        var counter = 0;
        for (var i = 0; i < this.length; i++) { //this = arr
            if (this[i] === num) {
                counter++;
            }
        }
        return counter;
    };

    var maxFreq = 0;
    var maxFreqElement;
    for (var obj in arrNumbers) {
        var currentFreq = arrNumbers.occurs(arrNumbers[obj]);
        if(currentFreq > maxFreq) {
            maxFreq = currentFreq;
            maxFreqElement = arrNumbers[obj];
        }
    }

    arrNumbers.sort(function(x, y) {
        return x < y;
    });

    console.log('Min number: ' + Math.min.apply(null, arrNumbers));
    console.log('Max number: ' + Math.max.apply(null, arrNumbers));
    console.log('Most frequent number: ' + maxFreqElement);
    console.log(arrNumbers);
}

solve(["Pesho", 2, "Gosho", 12, 2, "true", 9, undefined, 0, "Penka", { bunniesCount : 10}, [10, 20, 30, 40]]);