function solve(args) {
    var sortingOrders = args[0].split("^");
    var people = [];
    for (var i = 1; i < args.length; i += 1) {
        people.push(JSON.parse(args[i]));
    }
    
    var sortedStudents = people
    .filter(function (person) {
        return person.role == "student";
    })
    .sort(function (a, b) {
        if (sortingOrders[0] == "name") {          
            if (a.firstname != b.firstname) {
                return a.firstname < b.firstname ? -1 : 1;
            }
            else if (a.lastname != b.lastname) {
                return a.lastname < b.lastname ? -1 : 1;
            }
        }
        else {
            if (a.level != b.level) {
                return a.level < b.level ? -1 : 1;
            } 
            else {
                return a.id < b.id ? -1 : 1;
            }
        }
    })
    .map(function (person) {
        var avgGrade = 0;
        for (var i = 0; i < person.grades.length; i += 1) {
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
    
    var sortedTrainers = people
    .filter(function (person) {
        return person.role == "trainer";
    })
    .sort(function (a, b) {
        if (a.courses.length != b.courses.length) {
            return a.courses.length - b.courses.length;
        } 
        else {
            return a.lecturesPerDay - b.lecturesPerDay;
        }
    })
    .map(function (person) {
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