function solve(input) {
    var htmlText = input[0];
    var myRegexp = /<p>(.+?[\n]*)<\/p>/g;
    var match = myRegexp.exec(htmlText);
    var outputArr = [];
    while (match != null) {
        //console.log(match[1])
        var spaceReplaceArr = match[1].replace(/[A-Z\W]+/g, ' ').split('');
        var decryptString = '';
        for (var letterIndex = 0; letterIndex < spaceReplaceArr.length; letterIndex ++) {
            var letter = spaceReplaceArr[letterIndex]
            var newLetter = letter;
            if(letter.charCodeAt(0) > 96 && letter.charCodeAt(0) < 110) {
                var newCharCode = letter.charCodeAt(0) + 13;
                newLetter = String.fromCharCode(newCharCode);
            } else if (letter.charCodeAt(0) > 109 && letter.charCodeAt(0) < 123) {
                var newCharCode = letter.charCodeAt(0) - 13;
                newLetter = String.fromCharCode(newCharCode);
            }
            decryptString += newLetter;
        }
        outputArr.push(decryptString);

        match = myRegexp.exec(htmlText);
    }
    console.log(outputArr.join(''))
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
    solve(arr);
});

//solve (['<html><head><title></title></head><body><h1>hello</h1><p>znahny!@#%&&&&****</p><div><button>dsad</button></div><p>grkg^^^^%%%)))([]12</p></body></html>']);

//solve (['<html><head><title></title></head><body><h1>Intro</h1><ul><li>Item01</li><li>Item02</li><li>Item03</li></ul><p>jura qevivat va jrg fyvccrel fabjl pbaqvgvbaf fabj punvaf ner nofbyhgryl rffragvny sbe fnsr unaqyvat nygubhtu fabj punvaf znl ybbx vagvzvqngvat gur onfvp vqrn vf ernyyl fvzcyr svg gurz bire lbhe gverf qevir sbejneq fybjyl naq gvtugra gurz hc va pbyq jrg pbaqvgvbaf guvf vf rnfvre fnvq guna qbar ohg vs lbh chg ba lbhe gverf orsber lbh ernpu fabjl ebnqf lbh jvyy znxr lbhe yvsr jnl rnfvre</p>']);

//solve (['<html><head><title></title></head><body><h1>Intro</h1><ul><li>Item01</li><li>Item02</li><li>Item03</li></ul><p>jura qevivat va jrg fyvccrel fabjl</p><div><button>Click me, baby!</button></div><p> pbaqvgvbaf fabj punvaf ner nofbyhgryl rffragvny sbe fnsr unaqyvat nygubhtu fabj punvaf znl ybbx </p><span>This manual is false, do not trust it! The illuminati wrote it down to trick you!</span><p>vagvzvqngvat gur onfvp vqrn vf ernyyl fvzcyr svg gurz bire lbhe gverf qevir sbejneq fybjyl naq gvtugra gurz hc va pbyq jrg</p><p> pbaqvgvbaf guvf vf rnfvre fnvq guna qbar ohg vs lbh chg ba lbhe gverf </p><div>It is frustrating that you have not put car chains yet... Embarrassing...</div><p>orsber lbh ernpu fabjl ebnqf lbh jvyy znxr lbhe yvsr jnl rnfvre</p></body>']);