/**
 * Created by emily on 3/31/15.
 */

function solve(input) {
    var start = parseInt(input[0]),
        end = parseInt(input[1]);

    console.log('<ul>');
    for (; start <= end; start++) {
        if (doubleRakiya(start)) {
            console.log('<li><span class=\'rakiya\'>' + start + '</span><a href="view.php?id=' + start + '>View</a></li>');
        } else {
            console.log('<li><span class=\'num\'>' + start + '</span></li>');
        }
    }
    console.log('</ul>');



    function doubleRakiya(num) {
        num = String(num);
        var i,
            temp,
            regex,
            searchField;
        if (num.length >= 4) {
            for ( i = 0; i < num.length - 2; i++) {
                temp = num.substring(i, i + 2);
                searchField = num.substring(i + 2);
                regex = new RegExp(temp, 'g');
                if (regex.test(searchField)) {
                    return true;
                }
            }
            return false;
        }
        return false;
    }
}