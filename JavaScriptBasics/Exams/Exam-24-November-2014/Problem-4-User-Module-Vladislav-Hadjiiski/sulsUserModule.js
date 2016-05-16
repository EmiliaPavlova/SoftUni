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


// ------------------------------------------------------------
// Read the input from the console as array and process it
// Remove all below code before submitting to the judge system!
// ------------------------------------------------------------

var arr = [];
require('readline').createInterface({
    input: process.stdin,
    output: process.stdout
}).on('line', function (line) {
    arr.push(line);
}).on('close', function () {
    sulsUserModule(arr);
});