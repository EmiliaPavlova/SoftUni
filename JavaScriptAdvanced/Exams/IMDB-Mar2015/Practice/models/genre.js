var imdb = imdb || {};

(function (scope) {
    var id = 0;

    function Genre(name) {
        this._id = ++id;
        this.name = name;
        this._movies = [];
    }

    Genre.prototype.addMovie = function(movie) {
        this._movies.push(movie);
    };

    Genre.prototype.deleteMovie = function(movie) {
        this._movies = this._movies.filter(function(currentMovie) {
            return currentMovie !== movie;
        })
    };

    Genre.prototype.deleteMovieById = function(id) {
        this._movies = this._movies.filter(function(movie) {
            return movie._id !== id;
        })
    };

    Genre.prototype.getMovies = function() {
        return this._movies;
    };

    scope.getGenre = function(name) {
        return new Genre(name);
    }
}(imdb));