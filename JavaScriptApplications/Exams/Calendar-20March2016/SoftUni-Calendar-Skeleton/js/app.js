var app = app || {};

(function() {
    var router = Sammy(function() {
        var selector = '#container';
        var requester = app.requester.load('kid_byaZDsNTJZ', '45d745d3f60a48439bfa253b6fd4c7a9', 'https://baas.kinvey.com/');

        var userViewBag = app.userViewBag.load();
        var homeViewBag = app.homeViewBag.load();
        var lecturesViewBag = app.lecturesViewBag.load();

        var userModel = app.userModel.load(requester);
        var lecturesModel = app.lecturesModel.load(requester);

        var userController = app.userController.load(userViewBag, userModel);
        var homeController = app.homeController.load(homeViewBag);
        var lecturesController = app.lecturesController.load(lecturesViewBag, lecturesModel);

        this.before({except:{path:'#\/(login\/|register\/)?'}}, function() {
            if(!sessionStorage['sessionId']) {
                this.redirect('#/');
                return false;
            }
        });

        this.before(function() {
            if(!sessionStorage['sessionId']) {
                $("#menu").load("templates/menu-login.html");
            } else {
                $("#menu").load("templates/menu-home.html");
            }
        });

        this.get('#/', function() {
            homeController.loadWelcomePage(selector);
        });

        this.get('#/home/', function() {
            homeController.loadHomePage(selector);
        });

        this.get('#/login/', function() {
            userController.loadLoginPage(selector);
        });

        this.get('#/register/', function() {
            userController.loadRegisterPage(selector);
        });

        this.get('#/logout/', function() {
            userController.logout();
        });

        this.get('#/calendar/list/', function() {
            lecturesController.loadLectures(selector);
        });

        this.get('#/calendar/my/', function() {
            lecturesController.loadMyLectures(selector);
        });

        this.get('#/calendar/add/', function() {
            lecturesController.loadAddLecture(selector);
        });

        this.bind('redirectUrl', function(ev, data) {
            this.redirect(data.url);
        });

        this.bind('login', function(ev, data) {
            userController.login(data);
        });

        this.bind('register', function(ev, data) {
            userController.register(data);
        });

        this.bind('addLecture', function(ev, data) {
            lecturesController.addLecture(data);
        });

        this.bind('showEditLecture', function(ev, data) {
            lecturesController.loadEditLecture(selector, data);
        });

        this.bind('editLecture', function(ev, data) {
            lecturesController.editLecture(data);
        });

        this.bind('showDeleteLecture', function(ev, data) {
            lecturesController.loadDeleteLecture(selector, data);
        });

        this.bind('deleteLecture', function(ev, data) {
            lecturesController.deleteLecture(data._id);
        })
    });

    router.run('#/');
}());