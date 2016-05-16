/**
 * Created by Emily on 30-Jan-16.
 */
function solve(input) {
    var students = {};
    for (var i in input) {
        var data = input[i].split(/-|:/g),
            name = data[0].trim(),
            exam = data[1].trim(),
            examResult = Number(data[2].trim()),
            makeUpExams = 0;

        if (examResult >= 0 && examResult <= 400) {
            var newStudent = {
                name: name,
                result: examResult,
                makeUpExams: makeUpExams
            };
            if (!students[exam]){
                students[exam] = [newStudent];
            } else {
                var student = students[exam]
                    .filter(function(person) {
                        return person.name == name
                    })[0];
                if (student) {
                    student.makeUpExams += 1;
                    if (examResult > student.result) {
                        student.result = examResult;
                    }
                } else {
                    students[exam].push(newStudent);
                }
            }
        }
    }

    var sortedStudents = {};
    Object.keys(students).forEach(function(exam) {
        sortedStudents[exam] = students[exam].sort(function(a, b) {
            if (a.result === b.result) {
                if (a.makeUpExams === b.makeUpExams) {
                    return a.name > b.name;
                }
                return a.makeUpExams - b.makeUpExams;
            }
            return b.result - a.result;
        });
    });

    console.log(JSON.stringify(students));
}

//solve(['Peter Jackson - Java : 350',
//    'Jane - JavaScript : 200',
//    'Jane     -    JavaScript :     400',
//    'Simon Cowell - PHP : 100',
//    'Simon Cowell-PHP: 500',
//    'Simon Cowell - PHP : 200']);

solve(['Simon Cowell - PHP : 100',
    'Simon Cowell-PHP: 500',
    'Peter Jackson - PHP: 350',
    'Simon Cowell - PHP : 400']);