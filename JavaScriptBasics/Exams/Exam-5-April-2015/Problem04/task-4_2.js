/**
 * Created by Emily on 28-Jan-16.
 */
function solve(input) {
    var players = [];
    for (var key in input) {
        input[key] = input[key].replace(/\s+/g, ' ');
        var data = input[key].split(/\s*vs.\s*/g),
            firstPlayerName = data[0],
            temp = data[1].split(/\s*:\s*/g),
            secondPlayerName = temp[0],
            sets = temp[1].split((' '));

        var firstPlayerMatch = 0;
        var secondPlayerMatch = 0;
        var firstPlayerSets = 0;
        var secondPlayerSets = 0;
        var firstPlayerGames = 0;
        var secondPlayerGames = 0;

        sets.forEach(function(tennisSets) {
            var currentFPGames = Number(tennisSets.split('-')[0]);
            var currentSPGames = Number(tennisSets.split('-')[1]);

            if (currentFPGames > currentSPGames) {
                firstPlayerSets++;
            } else {
                secondPlayerSets++;
            }
            firstPlayerGames += currentFPGames;
            secondPlayerGames += currentSPGames;
        });

        if (firstPlayerSets > secondPlayerSets) {
            firstPlayerMatch = 1
        } else {
            secondPlayerMatch = 1;
        }

        var playerForUpdate = players.filter(function(p) {
            return p.name === firstPlayerName;
        });

        if (!playerForUpdate[0]) {
            createPlayer(
                firstPlayerName,
                firstPlayerMatch,
                secondPlayerMatch,
                firstPlayerSets,
                secondPlayerSets,
                firstPlayerGames,
                secondPlayerGames);
        } else {
            playerForUpdate[0].matchesWon += firstPlayerMatch;
            playerForUpdate[0].matchesLost += secondPlayerMatch;
            playerForUpdate[0].setsWon += firstPlayerSets;
            playerForUpdate[0].setsLost += secondPlayerSets;
            playerForUpdate[0].gamesWon += firstPlayerGames;
            playerForUpdate[0].gamesLost += secondPlayerGames;
        }

        playerForUpdate = players.filter(function(p) {
            return p.name === secondPlayerName
        });

        if (!playerForUpdate[0]) {
            createPlayer(
                secondPlayerName,
                secondPlayerMatch,
                firstPlayerMatch,
                secondPlayerSets,
                firstPlayerSets,
                secondPlayerGames,
                firstPlayerGames
            );
        } else {
            playerForUpdate[0].matchesWon += secondPlayerMatch;
            playerForUpdate[0].matchesLost += firstPlayerMatch;
            playerForUpdate[0].setsWon += secondPlayerSets;
            playerForUpdate[0].setsLost += firstPlayerSets;
            playerForUpdate[0].gamesWon += secondPlayerGames;
            playerForUpdate[0].gamesLost += firstPlayerGames;
        }

        function createPlayer(name, matchesWon, matchesLost,
                              setsWon, setsLost, gamesWon, gamesLost) {
            var player = {
                name: name,
                matchesWon: matchesWon,
                matchesLost: matchesLost,
                setsWon: setsWon,
                setsLost: setsLost,
                gamesWon: gamesWon,
                gamesLost: gamesLost
            }

            players.push(player);
        }

        players.sort(function(playerX, playerY) {
            if (playerX.matchesWon !== playerY.matchesWon) {
                return playerY.matchesWon - playerX.matchesWon;
            }

            if (playerX.setsWon !== playerY.setsWon) {
                return playerY.setsWon - playerX.setsWon;
            }

            if (playerX.gamesWon !== playerY.gamesWon) {
                return playerY.gamesWon - playerX.gamesWon;
            }

            return playerX['name'].localeCompare(playerY['name']);
        });

        console.log(JSON.stringify(players));
    }
}

solve([
    'Novak Djokovic vs. Roger Federer : 6-3 6-3',
    'Roger    Federer    vs.        Novak Djokovic    :         6-2 6-3',
    'Rafael Nadal vs. Andy Murray : 4-6 6-2 5-7',
    'Andy Murray vs. David     Ferrer : 6-4 7-6',
    'Tomas   Bedrych vs. Kei Nishikori : 4-6 6-4 6-3 4-6 5-7',
    'Grigor Dimitrov vs. Milos Raonic : 6-3 4-6 7-6 6-2',
    'Pete Sampras vs. Andre Agassi : 2-1',
    'Boris Beckervs.Andre        Agassi:2-1']);