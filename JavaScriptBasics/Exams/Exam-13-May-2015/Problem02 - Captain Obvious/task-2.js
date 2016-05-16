/**
 * Created by Emily on 30-Jan-16.
 */
function solve(input) {
    var words = [];
    var firstText = input[0];
    firstText.replace(/[a-zA-Z]+/g, function(text) {
        var key = text.toLowerCase();
        if (!words[key]) {
            words[key] = 1;
        } else {
            words[key] += 1;
        }
        return text;
    });

    var repeatedWords = Object.keys(words)
        .filter(function(word) {
            return words[word] >= 3;
        });

    if (repeatedWords.length === 0) {
        console.log('No words');
        return;
    }

    var regex = /[\w].+?[?!.]/g;
    var match;
    var sentenceMatched = false;

    while (match = regex.exec(input[1])) {
        var currentSentence = match[0].toLowerCase();
        var counter = 0;
        for (var i = 0; i < repeatedWords.length; i++) {
            var currentRegex = new RegExp('\\b' + repeatedWords[i] + '\\b');
            currentSentence.replace(currentRegex, function(sentence) {
                counter += 1;
                return sentence;
            });

            if (counter >= 2) {
                console.log(match[0]);
                sentenceMatched =  true;
                break;
            }
        }
    }

    if (!sentenceMatched) {
        console.log("No sentences");
    }
    //console.log(words);
    //console.log(repeatedWords);
}

//solve(["Captain Obvious was walking down the street. As the captain was walking a person came and told him: You are Captain Obvious! He replied: Thank you CAPTAIN OBVIOUS you are the man!",
//    "The captain was walking and he was obvious. He did not know what was going to happen to you in the future. Was he curious? We do not know."]);

solve(["You will match no words in this text. Print No words in the console.",
    "Do not look at this text. You already have an output."]);