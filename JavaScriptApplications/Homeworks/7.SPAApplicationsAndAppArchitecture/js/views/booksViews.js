var app = app || {};

app.booksViews = (function() {
    function showAllBooks(selector, data) {
        $.get('templates/books.html', function(templ) {
            var rendered = Mustache.render(templ, data);
            $(selector).html(rendered);
            $('#addNewBook').on('click', function(e) {
                Sammy(function() {
                    this.trigger('redirect', {url:'#/addNewBook'});
                })
            })
        })
    }

    function showAddNewBook(selector) {
        $.get('templates/addNewBook.html', function(templ) {
            $(selector).html(templ);
            $('#addNewBook').on('click', function() {
                var title = $('#title').val();
                Sammy(function() {
                    this.trigger('add-new-book', {title: title});
                });
            })
        })
    }

    return {
        load: function() {
            return {
                showAllBooks: showAllBooks,
                showAddNewBook: showAddNewBook
            }
        }
    }
}());