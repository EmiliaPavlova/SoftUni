var app = app || {};

app.userViews = (function () {
    function showLoginPage(selector) {
        $.get('templates/login.html', function(templ) {
            $(selector).html(templ);
            $('#login').on('click', function(e) {
                var username = $('#username').val(),
                    password = $('#password').val();
                Sammy(function() {
                    this.trigger('login', {username:username, password:password});
                })
            })
        })
    }

    function showRegisterPage(selector) {
        $.get('templates/register.html', function(templ) {
            $(selector).html(templ);
            $('#register').on('click', function(e) {
                var username = $('#username').val(),
                    password = $('#password').val(),
                    repeatPass = $('#repeatPassword').val();

                if (password === repeatPass) {
                    Sammy(function() {
                        this.trigger('register', {username:username, password:password});
                    })
                }
            })
        })
    }

    return {
        load: function() {
            return {
                showLoginPage: showLoginPage,
                showRegisterPage: showRegisterPage
            }
        }
    }
}());