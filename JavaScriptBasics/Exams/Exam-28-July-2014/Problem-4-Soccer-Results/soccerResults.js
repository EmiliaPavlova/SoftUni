function soccerResults(input) {
    var results = { };
    for (i in input) {
        var matchResults = input[i].split(/[\/:-]+/);
        var teamHome = matchResults[0].trim();
        var teamAway = matchResults[1].trim();
        var goalsHome = Number(matchResults[2].trim());
        var goalsAway = Number(matchResults[3].trim());
        processResults(results, teamHome, teamAway, goalsHome, goalsAway);
        processResults(results, teamAway, teamHome, goalsAway, goalsHome);
    }
    
    // Sort the results structure
    results = sortObjectProperties(results);
    for (var team in results) {
        results[team].matchesPlayedWith.sort();
    }
    
    // Print the results as JSON string
    console.log(JSON.stringify(results));

    function processResults(results, teamHome, teamAway, goalsHome, goalsAway) {
        if (!results[teamHome]) {
            results[teamHome] = { goalsScored: 0, goalsConceded: 0, matchesPlayedWith: []};
        }
        results[teamHome].goalsScored += goalsHome;
        results[teamHome].goalsConceded += goalsAway;
        if (results[teamHome].matchesPlayedWith.indexOf(teamAway) == -1) {
            results[teamHome].matchesPlayedWith.push(teamAway);
        }
    }

    function sortObjectProperties(obj) {
        var keysSorted = Object.keys(obj).sort();
        var sortedObj = {};
        for (var i = 0; i < keysSorted.length; i++) {
            var key = keysSorted[i];
            sortedObj[key] = obj[key];
        }
        return sortedObj;
    }
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
    soccerResults(arr);
});
