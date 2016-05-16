/**
 * Created by emily on 5/8/15.
 */
function solve(array) {
    var input = array[0],
        regex= /<p>(.*?)<\/p>/g,
        text,
        match,
        currentCharCode,
        newCharCode,
        output = '';

    while (match = regex.exec(input)) {
        text = match[1];
        text = text.replace(/[^a-z0-9]+/g, ' ');

        for (var c in text) {
            currentCharCode = text.charCodeAt(c);
            if (currentCharCode >= 97 && currentCharCode <= 109) {
                newCharCode = currentCharCode + 13;
            } else if (currentCharCode >= 110 && currentCharCode <= 122) {
                newCharCode = currentCharCode - 13;
            } else {
                newCharCode = currentCharCode;
            }
            output += String.fromCharCode(newCharCode);
        }
    }
    console.log(output);
}

solve(['<html><head><title></title></head><body><h1>hello</h1><p>znahny!@#%&&&&****</p><div>' +
'<button>dsad</button></div><p>grkg^^^^%%%)))([]12</p></body></html>']);

solve(['<html><head><title></title></head><body><h1>Intro</h1><ul><li>Item01</li><li>Item02</li>' +
'<li>Item03</li></ul><p>jura qevivat va jrg fyvccrel fabjl</p><div><button>Click me, baby!</button></div>' +
'<p> pbaqvgvbaf fabj  qpunvaf ner nofbyhgryl rffragvny sbe fnsr unaqyvat nygubhtu fabj punvaf znl ybbx </p>' +
'<span>This manual is false, do not trust it! The illuminati wrote it down to trick you!</span>' +
'<p>vagvzvqngvat gur onfvp vqrn vf ernyyl fvzcyr svg gurz bire lbhe gverf qevir sbejneq fybjyl naq gvtugra gurz hc va pbyq jrg</p>' +
'<p> pbaqvgvbaf guvf vf rnfvre fnvq guna qbar ohg vs lbh chg ba lbhe gverf</p></body>']);