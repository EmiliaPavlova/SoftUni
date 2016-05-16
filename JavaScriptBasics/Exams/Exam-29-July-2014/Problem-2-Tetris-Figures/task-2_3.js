/**
 * Created by emily on 5/6/15.
 */
function solve(input) {
    var figureI = [
            "o",
            "o",
            "o",
            "o"],
        figureL = [
            "o-",
            "o-",
            "oo"],
        figureJ = [
            "-o",
            "-o",
            "oo"],
        figureO = [
            "oo",
            "oo"],
        figureZ = [
            "oo-",
            "-oo"],
        figureS = [
            "-oo",
            "oo-"],
        figureT = [
            "ooo",
            "-o-"];

    function fit(field, figure) {
        var figWidth = figure[0].length,
            figHeight = figure.length,
            fieldWidth = field[0].length,
            fieldHeight = field.length,
            fitCounts = 0;

        for (var row = 0; row <= (fieldHeight - figHeight); row++) {
            for (var col = 0; col <= (fieldWidth - figWidth); col++) {
                if (isFit(field, figure, row, col)) {
                    fitCounts += 1;
                }
            }
        }
        return fitCounts;
    }

    function isFit(field, figure, startRow, startCol) {
        var figWidth = figure[0].length,
            figHeight = figure.length;
        for (var row = 0; row < figHeight; row++) {
            for (var col = 0; col < figWidth; col++) {
                if (figure[row][col] == 'o' && field[row + startRow][col + startCol] != 'o') {
                    return false;
                }
            }
        }
        return true;
    }

    var result = {
        "I": fit(input, figureI),
        "L": fit(input, figureL),
        "J": fit(input, figureJ),
        "O": fit(input, figureO),
        "Z": fit(input, figureZ),
        "S": fit(input, figureS),
        "T": fit(input, figureT)
    };

    console.log(JSON.stringify(result));
}

solve([
    '--o--o-',
    '--oo-oo',
    'ooo-oo-',
    '-ooooo-',
    '---oo--']);