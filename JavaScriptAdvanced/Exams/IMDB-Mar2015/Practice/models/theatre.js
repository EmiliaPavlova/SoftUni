var imdb = imdb || {};

(function(scope) {
    var id = 0;

    function Theatre(name, length, rating, country, isPuppet) {
        scope._Movie.call(this, name, length, rating, country);
        this._id = ++id;
        this.isPuppet = isPuppet || false;
    }

    Theatre.extend(scope._Movie);

    scope.getTheatre = function(name, length, rating, country, isPuppet) {
        return new Theatre(name, length, rating, country, isPuppet);
    }
}(imdb));