function findYoungestPerson(array) {
    array = array.filter(function(element) {
        return element.hasSmartphone;
    })
    array = array.sort(function (a, b) {
        return a.age - b.age;
    });

    //console.log(array);
    console.log('The youngest person with smartphone is ' + array[0].firstname + ' ' + array[0].lastname + '.');
}

var people = [
    { firstname : 'George', lastname: 'Kolev', age: 32, hasSmartphone: false },
    { firstname : 'Vasil', lastname: 'Kovachev', age: 40, hasSmartphone: true },
    { firstname : 'Bay', lastname: 'Ivan', age: 81, hasSmartphone: true },
    { firstname : 'Baba', lastname: 'Ginka', age: 40, hasSmartphone: false }];

findYoungestPerson(people);