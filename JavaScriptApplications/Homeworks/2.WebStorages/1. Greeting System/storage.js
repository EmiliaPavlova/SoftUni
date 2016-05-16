function keepName() {
    $('input').keypress(function(event) {
        var keycode = (event.keyCode ? event.keyCode : event.which);
        if(keycode == '13'){
            localStorage.setItem('name', $('input').val());
        }
    });

    $("#text").text(localStorage.getItem('name'));

    if (localStorage.name) {
        $('input').remove();
    }
};

keepName();

function visits() {
    if (!sessionStorage.counter) {
        sessionStorage.setItem('counter', 0);
    }

    var currentCount = parseInt(sessionStorage.getItem('counter'));
    currentCount++;
    sessionStorage.setItem('counter', currentCount);
    $("#sessionVisits").text('Session visits: ' + currentCount);

    if (!localStorage.counter) {
        localStorage.setItem('counter', 0);
    }

    var currentLocalCount = parseInt(localStorage.getItem('counter'));
    currentLocalCount++;
    localStorage.setItem('counter', currentLocalCount);
    $("#localVisits").text('Total visits: ' + currentLocalCount);
}

visits();

//localStorage.clear();