/**
 * Created by emily on 4/4/15.
 */

function solve(input) {
    var sortingCondition = input[0].split('^');
    var matrix = [];
    for (var i = 1; i < input.length; i++) {
        matrix.push(JSON.parse(input[i]));

    }
    var sortedStudents = matrix
    .filter(function(person) {
            return person.role === 'student';
        })
    .sort(function(a, b) {
            if (sortingCondition[0] === 'name') {
                if (a.firstname !== b.firstname) {
                    return a.firstname < b.firstname ? -1 : 1;
                } else if (a.lastname !== b.lastname) {
                    return a.lastname < b.lastname ? -1 : 1;
                }
            } else {
                if (a.level !== b.level) {
                    return a.level < b.level ? -1 : 1;
                } else if (a.id !== b.id) {
                    return a.id < b.id ? -1 : 1;
                }
            }
        })
    .map(function(person) {
            var avgGrade = 0;
            for (var i = 0; i < person.grades.length; i++) {
                avgGrade += Number(person.grades[i]);
            }
            avgGrade /= person.grades.length;
            return {
                id: person.id,
                firstname: person.firstname,
                lastname: person.lastname,
                averageGrade: avgGrade.toFixed(2),
                certificate: person.certificate
            };
        });

    var sortedTrainers = matrix
    .filter(function(person) {
            return person.role === 'trainer';
        })
    .sort(function(a, b) {
            if (a.courses.length !== b.courses.length) {
                return a.courses.length - b.courses.length;
            } else {
                return a.lecturesPerDay - b.lecturesPerDay;
            }
        })
    .map(function(person) {
            return {
                id: person.id,
                firstname: person.firstname,
                lastname: person.lastname,
                courses: person.courses,
                lecturesPerDay: person.lecturesPerDay
            };
        });

    var result = {
        students: sortedStudents,
        trainers: sortedTrainers
    };

    console.log(JSON.stringify(result));
}

solve(['level^courses',
    '{"id":0,"firstname":"Angel","lastname":"Ivanov","town":"Plovdiv","role":"student","grades":["5.89"],"level":2,"certificate":false}',
    '{"id":1,"firstname":"Mitko","lastname":"Nakova","town":"Dimitrovgrad","role":"trainer","courses":["PHP","Unity Basics"],"lecturesPerDay":6}',
    '{"id":2,"firstname":"Bobi","lastname":"Georgiev","town":"Varna","role":"student","grades":["5.59","3.50","4.54","5.05","3.45"],"level":4,"certificate":false}',
    '{"id":3,"firstname":"Ivan","lastname":"Ivanova","town":"Vidin","role":"trainer","courses":["JS","Java","JS OOP","Database","OOP","C#"],"lecturesPerDay":7}',
    '{"id":4,"firstname":"Mitko","lastname":"Petrova","town":"Sofia","role":"trainer","courses":["Database","JS Apps","Java"],"lecturesPerDay":2}']);