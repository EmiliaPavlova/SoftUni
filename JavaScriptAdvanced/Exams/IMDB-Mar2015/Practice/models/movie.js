var imdb = imdb || {};

(function(scope) {
    var id = 0;

    function Movie(title, length, rating, country) {
        this._id = ++id;
        this.title = title;
        this.length = length;
        this.rating = rating;
        this.country = country;
        this._actors = [];
        this._reviews = [];
    }

    Movie.prototype.addActor = function(actor) {
        this._actors.push(actor);
    };

    Movie.prototype.getActors = function() {
        return this._actors;
    };

    Movie.prototype.addReview = function(review) {
        this._reviews.push(review);
    };

    Movie.prototype.getReviews = function() {
        return this._reviews;
    };

    Movie.prototype.deleteReview = function(review) {
        this._reviews = this._reviews.filter(function(currentReview) {
            return currentReview !== review;
        })
    };

    Movie.prototype.deleteReviewById = function(id) {
        this._reviews = this._reviews.filter(function(review) {
            return review._id !== id;
        })
    };

    //adding Movie constructor to scope. Otherwise it's unreachable in Theatre
    scope._Movie = Movie;
    scope.getMovie = function(title, length, rating, country) {
        return new Movie(title, length, rating, country);
    }
}(imdb));