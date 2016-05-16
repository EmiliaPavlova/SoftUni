/**
 * Created by Emily on 31-Jan-16.
 */
function solve(input) {
    var regex = /#([a-zA-Z]+[\w-]*[a-zA-Z0-9]+)/g,
        regexCode = /<code>[\s+\S+]+<\/code>/g,
        textToScip = [],
        match,
        line,
        user,
        linkUser,
        bannedUser = input.pop();

    for (var i in input) {
        line = input[i];

        while (match = regexCode.exec(line)) {
            textToScip.push(match[1]);
        }
        console.log(textToScip);
    }

    //for (var i = 0; i < input.length; i++) {
    //    line = input[i];
    //
    //    if (line === '<code>') {
    //        line = input[i + 1];
    //        while (line !== '<\/code>') {
    //            console.log(line);
    //            line = input[i + 1];
    //            //while (match = regex.exec(line)) {
    //            //    user = match[1].trim();
    //            //
    //            //    if (user.length >= 3) {
    //            //        line = line.replace(
    //            //            user, '<a href=”/users/profile/show/' + user + '”>' + user + '</a>');
    //            //    }
    //            //
    //            }
    //        }
    //    }
        console.log(textToScip);
}

solve([
    "#RoYaL: I'm not sure what you mean,",
    "but I am confident that I've written",
    "everything correctly. Ask #iordan_93",
    "and #pesho if you don't believe me",
    "<code>",
    "#trying to print stuff",
    "print(\"yoo\")",
    "</code>",
    "pesho gosho"
]);