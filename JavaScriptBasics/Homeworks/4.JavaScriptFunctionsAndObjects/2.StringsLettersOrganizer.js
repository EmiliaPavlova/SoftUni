function sortLetters(string, boolean) {
    var strArr = string.split('');
    strArr.sort(function(a, b) {
        if (boolean === true) {
            return a.toLowerCase() > b.toLowerCase()
        } else {
            return a.toLowerCase() < b.toLowerCase()
        }
    });
    console.log(strArr.join(''));
}

sortLetters('HelloWorld', true);
sortLetters('HelloWorld', false);