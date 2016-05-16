function clone(obj) {
    return JSON.parse(JSON.stringify(obj));
}
function compareObjects(obj, objCopy) {
    console.log('a == b --> ' + (a == b));
}

var a = { name: 'Pesho', age: 21 }
var b = clone(a); // a deep copy
compareObjects(a, b);
a = { name: 'Pesho', age: 21 };
b = a; // not a deep copy
compareObjects(a, b);