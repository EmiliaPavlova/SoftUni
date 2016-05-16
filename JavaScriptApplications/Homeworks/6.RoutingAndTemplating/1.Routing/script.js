var app = app || {};

(function() {
    app.router = Sammy(function() {
        var selector = '#wrapper',
            hello = 'Hello, ';

        this.get('#/Pesho', function() {
            $(selector).html(hello + 'Pesho');
        });

        this.get('#/Gosho', function() {
            $(selector).html(hello + 'Gosho');
        });

        this.get('#/Ani', function() {
            $(selector).html(hello + 'Ani');
        });
    });

    app.router.run('#/');
}());