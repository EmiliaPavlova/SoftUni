/**
 * Created by emily on 4/4/15.
 */

function solve(input) {
    var price ,
        prevPrice,
        trend;

    console.log('<table>');
    console.log('<tr><th>Price</th><th>Trend</th></tr>');

    for (var i in input) {
        price = Number(input[i]).toFixed(2);
        price = Number(price);
        if (prevPrice == undefined || prevPrice == price) {
            trend = "fixed.png";
        } else if (price < prevPrice) {
            trend = "down.png";
        } else if (price > prevPrice) {
            trend = "up.png";
        }
        console.log("<tr><td>" + price.toFixed(2) + "</td><td><img src=\"" + trend + "\"/></td></tr>");
        prevPrice = price;
    }
    console.log('</table>');
}

solve(['36.333',
    '36.3334',
    '36.5',
    '37.019',
    '37.024',
    '35.4',
    '35',
    '35.001',
    '35',
    '36.225',
    '37.001',
    '37.000',
    '37.0',
    '38',
    '39',
    '40',
    '0',
    '0.00']);