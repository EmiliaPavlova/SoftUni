function Person(firstName, lastName, age){
    return{
        firstName: firstName,
        lastName: lastName,
        age: age
    }
}

function groupBy(array, property){
    var result = {};
    for (var i in people) {
        var searchProperty = people[i][property];
        if (!result[searchProperty]) {
            result[searchProperty] = [];
        }
        result[searchProperty].push(people[i]);
    }
    //console.log(result);

    for (var key in result) {
        var groupAsString = ('Group ' + key + ' : [');
        for (var i = 0; i < result[key].length; i++) {
            if (i !== result[key].length - 1) {
                groupAsString = groupAsString + (result[key][i].firstName + ' ' + result[key][i].lastName + '(' + result[key][i].age + '), ');
            }
            else {
                groupAsString = groupAsString + (result[key][i].firstName + ' ' + result[key][i].lastName + '(' + result[key][i].age + ')]');
            }
        }
        console.log(groupAsString);
    }
}

var people = [
    new Person("Scott", "Guthrie", 38),
    new Person("Scott", "Johns", 36),
    new Person("Scott", "Hanselman", 39),
    new Person("Jesse", "Liberty", 57),
    new Person("Jon", "Skeet", 38)
];

//console.log(people);
console.log(groupBy(people, 'firstName'));
console.log();
console.log(groupBy(people, 'age'));
console.log();
console.log(groupBy(people, 'lastName'));