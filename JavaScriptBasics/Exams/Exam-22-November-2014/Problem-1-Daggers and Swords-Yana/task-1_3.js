/**
 * Created by emily on 5/7/15.
 */
function solve(input) {
    console.log('<table border="1">');
    console.log('<thead>');
    console.log('<tr><th colspan="3">Blades</th></tr>');
    console.log('<tr><th>Length [cm]</th><th>Type</th><th>Application</th></tr>');
    console.log('</thead>');
    console.log('<tbody>');

    for (var i in input) {
        var blade = parseInt(input[i]);
        var bladeIndex = blade % 5;

        if (blade > 10) {
            var type = 'dagger';
            if (blade > 40) {
                type = 'sword';
            }

            var application = '';
            switch (bladeIndex) {
                case 1:
                    application = 'blade';
                    break;
                case 2:
                    application = 'quite a blade';
                    break;
                case 3:
                    application = 'pants-scraper';
                    break;
                case 4:
                    application = 'frog-butcher';
                    break;
                case 0:
                    application = '*rap-poker';
                    break;
                default:
                    break;
            }
            console.log('<tr><td>' + blade + '</td><td>' + type + '</td><td>' + application + '</td></tr>');
        }
    }

    console.log('</tbody>');
    console.log('</table>');
}

solve(['22.0',
    '23.2555',
    '24.368',
    '202.87',
    '203.99999',
    '204.785']);