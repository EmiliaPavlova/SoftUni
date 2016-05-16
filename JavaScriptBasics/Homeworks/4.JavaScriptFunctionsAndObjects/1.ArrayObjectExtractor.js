function extractObjects(array) {
    var result = [];
    for (var i in array) {
        if (typeof array[i] === 'object' && array[i].constructor !== Array) {
            result.push(array[i]);
        }
        //console.log(typeof array[i]);
    }

    //second way:
    //array.forEach(function(i) {
    //    if (typeof i === 'object' && i.constructor !== Array) {
    //        result.push(i);
    //    }
    //});

    console.log(result);
}

extractObjects([
    "Pesho",
    4,
    4.21,
    { name : 'Valyo', age : 16 },
    { type : 'fish', model : 'zlatna ribka' },
    [1,2,3],
    "Gosho",
    { name : 'Penka', height: 1.65}
]);
