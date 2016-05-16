$(document).ready(function () {
    var counter;

    function saveData() {
        if (!localStorage.saved && localStorage.length) {
            localStorage.saved = true;
            localStorage.dies = $("input[name=dies]:checked").val();
            localStorage.google = $("input[name=google]:checked").val();
            localStorage.mouse = $("input[name=mouse]:checked").val();
            localStorage.diesCorrect = 'Octothorpe';
            localStorage.googleCorrect = 'A misspelt mathematical term for 10 to the power of one hundred - "googol"';
            localStorage.mouseCorrect = 'Xerox Alto';
        }
    }

    function loadSavedData() {
        switch (localStorage.dies) {
            case 'Hash':
                $('#hash').attr('checked', true);
                break;
            case 'Octothorpe':
                $('#octothorpe').attr('checked', true);
                break;
            case 'Number sign':
                $('#number').attr('checked', true);
                break;
            case 'Sharp sign':
                $('#sharp').attr('checked', true);
                break;
        }

        switch (localStorage.google) {
            case 'Global Organization of Oriented Group Language of Earth':
                $('#global').attr('checked', true);
                break;
            case 'Government Owned Operated Global Lookup Engine':
                $('#government').attr('checked', true);
                break;
            case 'A misspelt mathematical term for 10 to the power of one hundred - "googol"':
                $('#googol').attr('checked', true);
                break;
            case 'Go Online Or Go Look Everywhere':
                $('#online').attr('checked', true);
                break;
        }

        switch (localStorage.mouse) {
            case 'Lilith':
                $('#lilith').attr('checked', true);
                break;
            case 'Xerox 8010':
                $('#xerox').attr('checked', true);
                break;
            case 'Apple Lisa':
                $('#apple').attr('checked', true);
                break;
            case 'Xerox Alto':
                $('#alto').attr('checked', true);
                break;
        }
    }

    function countDown() {
        var minutes,
            seconds;

        localStorage.count--;

        if (localStorage.count < 0) {
            clearInterval(counter);
            return;
        }

        minutes = Math.floor(localStorage.count / 60);
        if (minutes < 10) {
            minutes = '0' + minutes;
        }

        seconds = Math.floor(localStorage.count % 60);
        if (seconds < 10) {
            seconds = '0' + seconds;
        }

        $('#timer').text(minutes + ':' + seconds);
    }

    function timeExpired() {
        $('#timer').css('color', 'red');
        $('button').attr('disabled', true);
    }

    function showResults() {
        var timeElapsed = 5 * 60 - localStorage.count,
            minutes,
            seconds;

        clearInterval(counter);
        $('form').hide();
        $('#timer').hide();

        if (!localStorage.submitted) {
            saveData();
        }

        $('#dies-answer').prepend('Your answer: ' + localStorage.dies);
        $('#dies-answer-correct').text('Correct answer: ' + localStorage.diesCorrect);

        if (localStorage.dies === localStorage.diesCorrect) {
            $('#dies-answer').find('.correct-msg').show();
            $('#dies-answer').css('color', 'green');
        } else {
            $('#dies-answer').find('.incorrect-msg').show();
            $('#dies-answer').css('color', 'red');
        }

        $('#google-answer').prepend('Your answer: ' + localStorage.google);
        $('#google-answer-correct').text('Correct answer: ' + localStorage.googleCorrect);

        if (localStorage.google === localStorage.googleCorrect) {
            $('#google-answer').find('.correct-msg').show();
            $('#google-answer').css('color', 'green');
        } else {
            $('#google-answer').find('.incorrect-msg').show();
            $('#google-answer').css('color', 'red');
        }

        $('#mouse-answer').prepend('Your answer: ' + localStorage.mouse);
        $('#mouse-answer-correct').text('Correct answer: ' + localStorage.mouseCorrect);

        if (localStorage.mouse === localStorage.mouseCorrect) {
            $('#mouse-answer').find('.correct-msg').show();
            $('#mouse-answer').css('color', 'green');
        } else {
            $('#mouse-answer').find('.incorrect-msg').show();
            $('#mouse-answer').css('color', 'red');
        }

        $('section').show();

        minutes = Math.floor(timeElapsed / 60);
        if (minutes < 10) {
            minutes = '0' + minutes;
        }

        seconds = Math.floor(timeElapsed % 60);
        if (seconds < 10) {
            seconds = '0' + seconds;
        }

        $('#time-elapsed').text('Elapsed time: ');
        $('#time-elapsed').append(minutes + ':' + seconds);

        localStorage.submitted = true;
    }

    if (!localStorage.submitted) {
        if (!localStorage.count) {
            localStorage.count = 5 * 60;
        } else if (localStorage.count < 0) {
            timeExpired();
        }

        counter = setInterval(countDown, 1000);

        if (localStorage.saved) {
            loadSavedData();
        }
    } else {
        showResults();
    }

    $('button').click(saveData, showResults);

    window.onbeforeunload = saveData;
});
//localStorage.clear();