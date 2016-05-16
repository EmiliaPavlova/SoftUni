/**
 * Created by emily on 5/6/15.
 */
function solve(input) {
    var price ,
        prevPrice,
        trend;

    console.log('<table>');
    console.log('<tr><th>Price</th><th>Trend</th></tr>');

    for (var i in input) {
        price = Number(Number(input[i]).toFixed(2));
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

solve(['50',
    '60']);