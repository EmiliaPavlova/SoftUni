var app = app || {};

(function () {
    app.router = $.sammy(function () {
        var requester = app.requester.config('kid_WkuqWJxYyW', '407430ee06284920bd0ce940726b621f');
        var selector = '#list-books';


        var userModel = app.userModel.load(requester);
        var bookModel = app.bookModel.load(requester);

        var userViewBag = app.userViews.load();
        var bookViewBag = app.bookViews.load();

        var userController = app.userController.load(userModel, userViewBag);
        var bookController = app.bookControler.load(bookModel, bookViewBag);

        this.before({except: {path: '#\/(register|login)?'}}, function () {
            var sessionId = sessionStorage['sessionAuth'];
            if (!sessionId) {
                this.redirect('#/login');
                return false;
            } else {
                this.redirect('#/books');
            }
        });

        this.get('#/', function () {
            this.redirect('#/books');
        });

        this.get('#/login', function () {
            userController.loadLoginPage(selector);
        });

        this.get('#/books', function () {
            bookController.getAllBooks(selector);
        });

        this.get('#/logout', function () {
            var _this = this;
            userController.logout()
                .then(function() {
                    _this.redirect('#/books');
                })
        });

        this.bind('redirectUrl', function(e, data) {
            this.redirect(data.url);
        });

        this.bind('login', function(e, data) {
            userController.login(data)
        });
    })

    app.router.run('#/');
}());