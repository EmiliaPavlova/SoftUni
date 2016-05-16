/**
 * Created by Emily on 31-Jan-16.
 */
function solve(input) {
    var courseForAveragePoints = input.pop().trim(),
        requiredPoints = 80,
        averagePoints = 0,
        counter = 0;

    for (var i in input) {
        var data = input[i].trim().split(/\s+/g),
            name = data[0].trim(),
            course = data[1].trim(),
            examPoints = Number(data[2].trim()),
            bonuses = Number(data[3].trim());

        var coursePoints = examPoints / 5.00;
        var totalCoursePoints = coursePoints + bonuses;
        var grade = ((totalCoursePoints / requiredPoints) * 4) + 2;
        if (grade > 6) {
            grade = 6;
        }

        if (examPoints >= 100) {
            console.log(name + ': Exam - "' + course + '"; Points - ' +
                (Math.round(totalCoursePoints * 100) / 100) + '; Grade - ' + grade.toFixed(2));

        } else {
            console.log(name + ' failed at "' + course + '"');
        }

        if (course === courseForAveragePoints) {
            counter += 1;
            averagePoints += examPoints;
        }
    }

    console.log('"' + courseForAveragePoints + '" average points -> ' +
        Math.round(averagePoints / counter * 100) / 100);
}

solve(["    Pesho C#-Advanced 100 3",
    "Gosho Java-Basics 400 3",
    "Tosho HTML&CSS 317 12",
    "Minka C#-Advanced 57 15",
    "Stanka C#-Advanced 157 15",
    "Kircho C#-Advanced 300 0",
    "Niki C#-Advanced 400 10",
    "C#-Advanced"]);