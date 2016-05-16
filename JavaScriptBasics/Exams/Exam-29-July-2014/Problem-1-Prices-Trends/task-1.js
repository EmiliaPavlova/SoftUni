/**
 * Created by emily on 3/26/15.
 */

function solve(input) {
    var prices = input.map(Number);
    console.log("<table>");
    console.log("<tr><th>Price</th><th>Trend</th></tr>");

    var prevPrice;
    for (var i = 0; i < prices.length; i++) {
        var price = parseFloat(parseFloat(prices[i]).toFixed(2));
        if (prevPrice == undefined || price == prevPrice) {
            var trend = "fixed.png";
        } else if (price < prevPrice) {
            var trend = "down.png";
        } else {
            var trend = "up.png";
        }
        price = price.toFixed(2);
        console.log("<tr><td>" + price + "</td><td><img src=\"" + trend + "\"/></td></tr>");
        prevPrice = price;
    }
    console.log("</table>");
}

solve([36.333, 36.3334, 36.5, 37.019, 37.024, 35.4, 35, 35.001, 35, 36.225, 37.001, 37.000, 37.0, 38, 39, 40, 0, 0.00]);