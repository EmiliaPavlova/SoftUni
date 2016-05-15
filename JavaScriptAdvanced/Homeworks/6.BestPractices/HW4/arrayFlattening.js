Array.prototype.flatten = function() {
    var result = [];
    
    function getValues(array) {
        for (var i = 0; i < array.length; i++) {
            var value = array[i];
            if (Array.isArray(value)) {
                getValues(value);
            } else {
                result.push(value);
            }
        }
    }

    getValues(this);
    return result;
};

var array = [1, 2, 3, 4];
console.log(array.flatten());

var array = [1, 2, [3, 4], [5, 6]];
console.log(array.flatten());
console.log(array); // Not changed

var array = [0, ["string", "values"], 5.5, [[1, 2, true], [3, 4, false]], 10];
console.log(array.flatten());
