var add = function add(x) {
    var sum = x;

    function result(y) {
        sum += y;
        return result;
    };

    result.toString = function(){
        return sum;
    };

    return result;
};

console.log(add(1).toString()); //1
console.log(add(1)(2)(3).toString()); //6
console.log(add(1)(1)(1)(1)(1)(1).toString()); //6
console.log(add(1)(1)(1)(1)(1).toString()); // returns 5
console.log(add(1)(0)(-1)(-1).toString()); // returns -1

var addTwo = add(2);
console.log(addTwo.toString()); //2

var addTwo = add(2);
console.log(addTwo(3).toString()); //5

var addTwo = add(2);
console.log(addTwo(3)(5).toString()); //10