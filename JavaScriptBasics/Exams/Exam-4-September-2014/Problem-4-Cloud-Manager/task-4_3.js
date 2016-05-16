/**
 * Created by emily on 5/8/15.
 */
function solve(input) {
    var result = {};
    for (var i = 0; i < input.length; i++) {
        var data = input[i].split(/\s+/),
            file = data[0],
            extension = data[1],
            memory = parseFloat(data[2]);

        if (!result[extension]) {
            result[extension] = {
                files: [],
                memory: []
            };
        }
        result[extension].files.push(file);
        result[extension].memory.push(memory);
    }

    function getSum(array) {
        var sum = 0;
        for (var i in array) {
            sum += array[i];
        }
        return sum.toFixed(2);
    }

    for (var key in result) {
        result[key].files.sort();
        result[key].memory = getSum(result[key].memory);
    }

    var output = {};
    var keys = Object.keys(result);
    keys.sort();
    for (var i = 0; i < keys.length; i++) {
        output[keys[i]] = result[keys[i]];

    }

    console.log(JSON.stringify(output));
}

solve(['sentinel .exe 15MB',
    'zoomIt .msi 3MB',
    'skype .exe 45MB',
    'trojanStopper .bat 23MB',
    'kindleInstaller .exe 120MB',
    'setup .msi 33.4MB',
    'winBlock .bat 1MB']);

solve(['eclipse .tar.gz 198.00MB',
    'uTorrent .gyp 33.02MB',
    'nodeJS .gyp 14MB',
    'nakov-naked .jpeg 3MB',
    'gnuGPL .pdf 5.6MB',
    'skype .tar.gz 66MB',
    'selfie .jpeg 7.24MB',
    'myFiles .tar.gz 783MB']);