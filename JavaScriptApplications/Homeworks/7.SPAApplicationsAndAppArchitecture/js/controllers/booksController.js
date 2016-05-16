var app = app || {};

app.booksController = (function() {
    function BooksController(model, viewBag) {
        this._model = model;
        this._viewBag = viewBag;
    }

    BooksController.prototype.loadAllBooks = function(selector) {
        var _this = this;
        this._model.getAllBooks()
            .then(function(successData) {
                var result = {
                    books: []
                };

                successData.forEach(function(book) {
                    result.books.push({title: book.title, bookId: book._id});
                });

                _this._viewBag.showAllBooks(selector, result);
            })
    };

    BooksController.prototype.loadAddBookPage = function(selector) {
        this._viewBag.showAddNewBook(selector);
    };

    BooksController.prototype.addNewBook = function(data) {
        var _this = this;
        this._model.addNewBook(data)
            .then(function() {
                Sammy(function() {
                    this.trigger('redirectUrl', {url:'#/books'})
                })
            })
    };

    return {
        load: function(model, viewBag) {
            return new BooksController(model, viewBag);
        }
    }
}());