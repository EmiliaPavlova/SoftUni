/**
 * Created by emily on 5/6/15.
 */
function solve(input) {
    var result = {};
    for (var i in input) {
        var match = input[i].split(/[\/:-]/),
            teamHome = match[0].trim(),
            teamGuest = match[1].trim(),
            goalsHome = Number(match[2].trim()),
            goalsGuest = Number(match[3].trim());
        formatResult(result, teamHome, teamGuest, goalsHome, goalsGuest);
        formatResult(result, teamGuest, teamHome, goalsGuest, goalsHome);
    }

    function formatResult(result, teamHome, teamGuest, goalsHome, goalsGuest) {
        if (!result[teamHome]) {
            result[teamHome] = { goalsScored: 0, goalsConceded: 0, matchesPlayedWith: [] };
        }
        result[teamHome].goalsScored += goalsHome;
        result[teamHome].goalsConceded += goalsGuest;
        if (result[teamHome].matchesPlayedWith.indexOf(teamGuest) === -1) {
            result[teamHome].matchesPlayedWith.push(teamGuest);
        }
    }

    function sortProperties(obj) {
        var keySorted = Object.keys(obj).sort();
        var objectSorted = {};
        for (var i = 0; i < keySorted.length; i++) {
            objectSorted[keySorted[i]] = obj[keySorted[i]];
        }
        return objectSorted;
    }

    result = sortProperties(result);
    for (var team in result) {
        result[team].matchesPlayedWith.sort();
    }

    console.log(JSON.stringify(result));
}

solve([
    'Germany / Argentina: 1-0',
    'Brazil / Netherlands: 0-3',
    'Netherlands / Argentina: 0-0',
    'Brazil / Germany: 1-7',
    'Argentina / Belgium: 1-0',
    'Netherlands / Costa Rica: 0-0',
    'France / Germany: 0-1',
    'Brazil / Colombia: 2-1']);