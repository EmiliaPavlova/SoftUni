/**
 * Created by emily on 5/7/15.
 */
function solve(input) {
   var result = {};
    for (var i in input) {
        var data = input[i].split('|'),
            name = data[0].trim(),
            course = data[1].trim(),
            grade = Number(data[2].trim()),
            visits = Number(data[3].trim());

        if (!result[course]) {
            result[course] = { grades: [], visits: [], students: [] };
        }
        result[course].grades.push(grade);
        result[course].visits.push(visits);
        if (result[course].students.indexOf(name) === -1) {
            result[course].students.push(name);
        }
    }

    function average(array) {
        var sum = 0;
        for (var i in array) {
            sum += array[i];
        }
        var avg = sum / array.length;
        avg = Number(avg.toFixed(2));
        return avg;
    }

    var output = {};
    var courses = Object.keys(result).sort();
    for (var i in courses) {
        var courseName = courses[i];
        var courseInfo = {
            avgGrade: average(result[courseName].grades),
            avgVisits: average(result[courseName].visits),
            students: result[courseName].students.sort()
        };
        output[courseName] = courseInfo;
    }

    console.log(JSON.stringify(output));
}

solve([
    'Peter Nikolov | PHP  | 5.50 | 8',
    'Maria Ivanova | Java | 5.83 | 7',
    'Ivan Petrov   | PHP  | 3.00 | 2',
    'Ivan Petrov   | C#   | 3.00 | 2',
    'Peter Nikolov | C#   | 5.50 | 8',
    'Maria Ivanova | C#   | 5.83 | 7',
    'Ivan Petrov   | C#   | 4.12 | 5',
    'Ivan Petrov   | PHP  | 3.10 | 2',
    'Peter Nikolov | Java | 6.00 | 9'
]);