var app = app || {};

app.userViews = (function() {
    function showLoginPage(selector) {
        $.get('templates/login.html', function (templ) {
            $(selector).html(templ);
            $('#login').on('click', function () {
                var username = $('#username').val(),
                    password = $('#password').val();

                $.sammy(function() {
                    this.trigger('login', {username: username, password: password});
                });
            })
        })
    }

    return {
        load: function() {
            return {
                showLoginPage: showLoginPage
            }
        }
    }
}());