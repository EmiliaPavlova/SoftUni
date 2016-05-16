readInput();

function readInput() {
    var input = [
        '17.8',
        '19.4',
        '13',
        '55.8',
        '126.96541651',
        '3'
    ];
    solve(input);
}

function solve(input) {
    var output = '<table border="1"'

    for (var index = 0; index < input.length; index++) {
        var number = parseInt(input[index]);
        console.log(number);

        if (number > 10) {
            //var type = number > 40 ? 'sword' : 'dagger';
            var type = 'dagger';
            if (number > 40) {
                type = 'sword';
            }
            var applicationIndex = number % 5;
            if (applicationIndex === 0) {
                applicationIndex = 5;
            }
            var application;
            switch (applicationIndex) {
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
                case 5:
                    application = '*rap-poker';
                    break;
                default :
                    break;
            }
        }

    }
}
