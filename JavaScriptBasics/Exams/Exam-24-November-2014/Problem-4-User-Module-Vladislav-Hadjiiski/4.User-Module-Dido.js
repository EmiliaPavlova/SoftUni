function solve(arr) {
    function getUsers() {
        var users = [];
        var userObjs = arr.slice(1);
        userObjs.forEach(function(str, index) {
           users.push(JSON.parse(str));
        });

        return users;
    }

    var sortConditions = arr[0].split('^');
    var users = getUsers();
    var students = [];
    var trainers = [];
    users.forEach(function(student) {
        if (student.role == "student") {
            students.push(student);
        } else {
            trainers.push(student);
        }
    });

    if (sortConditions[0] == "name") {
        students = students.sort(function(s1, s2) {
            if (s1.firstname == s2.firstname) {
                return s1.lastname.localeCompare(s2.lastname);
            }
            return s1.firstname.localeCompare(s2.firstname);
        });
    } else {
        students = students.sort(function(s1, s2) {
            if (s1.level == s2.level) {
                return s1.id - s2.id;
            }
            return s1.level - s2.level;
        });
    }
    trainers.sort(function(t1, t2) {
        var t1Courses = t1.courses.length;
        var t2Courses = t2.courses.length;
        if (t1Courses == t2Courses) {
            return t1.lecturesPerDay - t2.lecturesPerDay;
        }
        return t1Courses - t2Courses;
    });

    var resultStudents = [];
    students.forEach(function (el) {
        var student = {
            id: el.id,
            firstname: el.firstname,
            lastname: el.lastname,
            averageGrade: avg(el.grades).toFixed(2),
            certificate: el.certificate
        };
        resultStudents.push(student);
    });
    var resultTrainers = [];
    trainers.forEach(function (el) {
        var trainer = {
            id: el.id,
            firstname: el.firstname,
            lastname: el.lastname,
            courses: el.courses,
            lecturesPerDay: el.lecturesPerDay
        };
        resultTrainers.push(trainer);
    });
    function avg(arr) {
        var sum = 0;
        arr.forEach(function (el) {
            sum += parseFloat(el);
        });

        return sum / arr.length;
    }


    var result = {"students": resultStudents, "trainers": resultTrainers};
    console.log(JSON.stringify(result));
}

function sulsUserModule(args) {

    function sortStudentByLevel(fS, sS) {
        if (fS.level < sS.level) {
            return -1;
        } else if (fS.level > sS.level) {
            return 1;
        }
        if (fS.id < sS.id) {
            return -1;
        } else if (fS.id > sS.id) {
            return 1;
        }
    }

    function sortStudentByName(fS, sS) {
        if (fS.firstname < sS.firstname) {
            return -1;
        } else if (fS.firstname > sS.firstname) {
            return 1;
        }
        if (fS.lastname < sS.lastname) {
            return -1;
        } else if (fS.lastname > sS.lastname) {
            return 1;
        }
    }

    function sortTrainerByCourses(fT, sT) {
        var fCourses = fT.courses.length,
            sCourses = sT.courses.length;
        if (fCourses == sCourses) {
            return fT.lecturesPerDay - sT.lecturesPerDay;
        }
        return fCourses - sCourses;
    }

    function dispatchSort(sortArgs, studentArr, trainerArr) {
        if (sortArgs[0] === 'level') {
            studentArr.sort(sortStudentByLevel);
        } else if (sortArgs[0] === 'name') {
            studentArr.sort(sortStudentByName);
        }
        if (sortArgs[1] === 'courses') {
            trainerArr.sort(sortTrainerByCourses);
        }
    }

    function printStudents(arr) {
        var output = [];
        arr.forEach(function (el) {
            var student = {
                id: el.id,
                firstname: el.firstname,
                lastname: el.lastname,
                averageGrade: avg(el.grades).toFixed(2),
                certificate: el.certificate
            };
            output.push(student);
        });

        return output;
    }

    function printTrainers(arr) {
        var output = [];
        arr.forEach(function (el) {
            var trainer = {
                id: el.id,
                firstname: el.firstname,
                lastname: el.lastname,
                courses: el.courses,
                lecturesPerDay: el.lecturesPerDay
            };
            output.push(trainer);
        });

        return output;
    }

    function avg(arr) {
        var sum = 0;
        arr.forEach(function (el) {
            sum += parseFloat(el);
        });

        return sum / arr.length;
    }

    var sortArguments = args[0].split('^'),
        trainers = [],
        students = [];

    for (var i = 1; i < args.length; i++) {
        var currentLine = args[i],
            objLine = JSON.parse(currentLine);

        if (objLine.role.trim() === 'student') {
            students.push(objLine);
        } else if (objLine.role.trim() === 'trainer') {
            trainers.push(objLine);
        }
    }
    dispatchSort(sortArguments, students, trainers);
    var trainerOutput = printTrainers(trainers);
    var studentOutput = printStudents(students);
    var result = {'students': studentOutput, 'trainers': trainerOutput};
    console.log(JSON.stringify(result));
}
solve([
    'level^courses',
    '{"id":0,"firstname":"Hristiqn","lastname":"Petrov","town":"Sofia","role":"student","grades":["4.06","5.17"],"level":5,"certificate":false}',
    '{"id":1,"firstname":"Angel","lastname":"Petrov","town":"Sofia","role":"trainer","courses":["Java","JS OOP"],"lecturesPerDay":6}',
    '{"id":2,"firstname":"Gergana","lastname":"Nakov","town":"Sliven","role":"trainer","courses":["Java","JS OOP","SDA"],"lecturesPerDay":5}',
    '{"id":3,"firstname":"Angel","lastname":"Nakova","town":"Burgas","role":"trainer","courses":["Database","JS OOP","JS","C#","iOS","HTML/CSS"],"lecturesPerDay":6}',
    '{"id":4,"firstname":"Petq","lastname":"Nakova","town":"Petrich","role":"student","grades":["5.14"],"level":4,"certificate":true}',
    '{"id":5,"firstname":"Julieta","lastname":"Petrov","town":"Svishtov","role":"trainer","courses":["iOS","OOP","JS","C#","Java"],"lecturesPerDay":6}',
    '{"id":6,"firstname":"Ivan","lastname":"Ivanov","town":"Stara Zagora","role":"student","grades":["5.28","2.15","4.25","4.95"],"level":2,"certificate":true}',
    '{"id":7,"firstname":"Gergana","lastname":"Daskalov","town":"Sofia","role":"trainer","courses":["PHP","ASP.NET","SDA"],"lecturesPerDay":5}',
    '{"id":8,"firstname":"Qvor","lastname":"Dimitrov","town":"Sevlievo","role":"student","grades":["4.30","3.14","4.09","4.08","2.25"],"level":5,"certificate":true}',
    '{"id":9,"firstname":"Petq","lastname":"Nakov","town":"Gabrovo","role":"trainer","courses":["JS Apps","Java","JS","iOS","SDA","HTML/CSS"],"lecturesPerDay":9}',
    '{"id":10,"firstname":"Bobi","lastname":"Nakov","town":"Gabrovo","role":"student","grades":["3.80"],"level":1,"certificate":false}'
]);
//sulsUserModule([
//    'name^courses',
//    '{"id":0,"firstname":"Angel","lastname":"Stoyanov","town":"Plovdiv", "role":"student","grades":["5.89"],"level":2,"certificate":false}',
//    '{"id":0,"firstname":"Angel","lastname":"Georgiev","town":"Plovdiv", "role":"student","grades":["5.89"],"level":2,"certificate":false}',
//    '{"id":6,"firstname":"Angel","lastname":"bGeorgiev","town":"Plovdiv", "role":"student","grades":["5.89"],"level":2,"certificate":false}',
//    '{"id":1,"firstname":"Mitko","lastname":"Nakova","town":"Dimitrovgrad", "role":"trainer","courses":["PHP","Unity Basics"],"lecturesPerDay":6}',
//    '{"id":2,"firstname":"Bobi","lastname":"Ivanov","town":"Varna", "role":"student","grades":["5.59","3.50","4.54","5.05","3.45"],"level":4,"certificate":false}',
//    '{"id":3,"firstname":"Ivan","lastname":"Ivanova","town":"Vidin", "role":"trainer","courses":["JS","Java","JS OOP","Database","OOP","C#"],"lecturesPerDay":7}',
//    '{"id":4,"firstname":"Mitko","lastname":"Petrova","town":"Sofia", "role":"trainer","courses":["Database","JS Apps","Java"],"lecturesPerDay":2}'
//]);

