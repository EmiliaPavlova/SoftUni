/**
 * Created by emily on 5/13/15.
 */
function solve(input) {
    var output = {};
    for (var i in input) {
        var data = input[i].split(/-|:/g),
            name = data[0].trim(),
            exam = data[1].trim(),
            result = parseInt(data[2].trim()),
            students = {},
            makeupExam = 0;

        if (result >= 0 && result <= 400) {
            if (!output[exam]) {
                output[exam] = {};
            }
            if (!output[exam][name]) {
                output[exam][name] = {};
                output[exam][name] = {
                    name: name,
                    result: [],
                    makeUpExam: makeupExam
                };
                output[exam][name].result.push(result);
            } else {
                output[exam][name].makeUpExam += 1;
                output[exam][name].result.push(result);
            }
        }
    }
    Object.keys(output).forEach(function(key) {

    })



    console.log(JSON.stringify(output));
}

solve(['Peter Jackson - Java : 350',
    'Jane - JavaScript : 200',
    'Jane     -    JavaScript :     400',
    'Simon Cowell - PHP : 100',
    'Simon Cowell-PHP: 500',
    'Simon Cowell - PHP : 200']);

//solve(['Simon Cowell - PHP : 100',
//    'Simon Cowell-PHP: 500',
//    'Peter Jackson - PHP: 350',
//    'Simon Cowell - PHP : 400']);