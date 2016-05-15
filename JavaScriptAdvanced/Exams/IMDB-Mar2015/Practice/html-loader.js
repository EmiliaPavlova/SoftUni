var imdb = imdb || {};

(function (scope) {
    function loadHtml(selector, data) {
        var container = document.querySelector(selector),
            moviesContainer = document.getElementById('movies'),
            detailsContainer = document.getElementById('details'),
            genresUl = loadGenres(data);

        container.appendChild(genresUl);

        genresUl.addEventListener('click', function (ev) {
            if (ev.target.tagName === 'LI') {
                var genreId,
                    genre,
                    moviesHtml;

                genreId = parseInt(ev.target.getAttribute('data-id'));
                genre = data.filter(function (genre) {
                    return genre._id === genreId;
                })[0];

                moviesHtml = loadMovies(genre.getMovies());
                moviesContainer.innerHTML = moviesHtml.outerHTML;
                moviesContainer.setAttribute('data-genre-id', genreId);

                // Task 2 - Add event listener for movies boxes
                var movieNodes = Array.prototype.slice.call(moviesContainer.firstElementChild.childNodes);
                movieNodes.forEach(function (node) {
                    node.addEventListener('click', function () {
                        while(detailsContainer.firstChild) {
                            detailsContainer.removeChild(detailsContainer.firstChild);
                        }
                        //detailsContainer.firstChild = '';

                        var id = this.getAttribute('data-id'),
                            movie = genre.getMovies().filter(function (movie) {
                                return movie._id == id;
                            })[0],
                            actors = movie.getActors(),
                            revies = movie.getReviews();

                        var actorsFragment = document.createDocumentFragment();
                        var actorsH3 = document.createElement('actorsH3');
                        actorsH3.innerHTML = 'Actors';
                        var actorsUl = document.createElement('ul');
                        actors.forEach(function (actor) {
                            var li = document.createElement('li');
                            var h4 = document.createElement('h4');
                            h4.innerHTML = actor.name;
                            var p = document.createElement('p');
                            p.innerHTML = '<strong>Bio: </strong>' + actor.bio + '<br/>' + '<strong>Born: </strong>' + actor.born;
                            li.appendChild(h4);
                            li.appendChild(p);
                            actorsUl.appendChild(li);
                        });
                        actorsFragment.appendChild(actorsH3);
                        actorsFragment.appendChild(actorsUl);

                        var reviewsFragment = document.createDocumentFragment();
                        var reviewsH3 = document.createElement('actorsH3');
                        reviewsH3.innerHTML = 'Reviews';
                        var reviewsUl = document.createElement('ul');
                        revies.forEach(function (review) {
                            var li = document.createElement('li');
                            var h4 = document.createElement('h4');
                            h4.innerHTML = review.author;
                            var p = document.createElement('p');
                            p.innerHTML = '<strong>Bio: </strong>' + review.content + '<br/>' + '<strong>Born: </strong>' + review.date;

                            // delete button
                            var button = document.createElement('button');
                            button.value = 'Delete';
                            button.innerHTML = 'Delete review';

                            button.addEventListener('click', function() {
                                movie.deleteReviewById(review._id);
                                reviewsUl.removeChild(li);
                            });

                            li.appendChild(h4);
                            li.appendChild(p);
                            li.appendChild(button);
                            reviewsUl.appendChild(li);
                        });
                        reviewsFragment.appendChild(reviewsH3);
                        reviewsFragment.appendChild(reviewsUl);

                        detailsContainer.appendChild(actorsFragment);
                        detailsContainer.appendChild(reviewsFragment);

                    })
                })
            }
        });
        // Task 3 - Add event listener for delete button (delete movie button or delete review button)
    }

    function loadGenres(genres) {
        var genresUl = document.createElement('ul');
        genresUl.setAttribute('class', 'nav navbar-nav');
        genres.forEach(function (genre) {
            var liGenre = document.createElement('li');
            liGenre.innerHTML = genre.name;
            liGenre.setAttribute('data-id', genre._id);
            genresUl.appendChild(liGenre);
        });

        return genresUl;
    }

    function loadMovies(movies) {
        var moviesUl = document.createElement('ul');
        movies.forEach(function (movie) {
            var liMovie = document.createElement('li');
            liMovie.setAttribute('data-id', movie._id);

            liMovie.innerHTML = '<actorsH3>' + movie.title + '</actorsH3>';
            liMovie.innerHTML += '<div>Country: ' + movie.country + '</div>';
            liMovie.innerHTML += '<div>Time: ' + movie.length + '</div>';
            liMovie.innerHTML += '<div>Rating: ' + movie.rating + '</div>';
            liMovie.innerHTML += '<div>Actors: ' + movie._actors.length + '</div>';
            liMovie.innerHTML += '<div>Reviews: ' + movie._reviews.length + '</div>';

            moviesUl.appendChild(liMovie);
        });

        return moviesUl;
    }

    scope.loadHtml = loadHtml;
}(imdb));