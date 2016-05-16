var app = app || {};

app.bookControler = (function () {
    function BookController(model, viewBag) {
        this._model = model;
        this._viewBag = viewBag;
    }

    BookController.prototype.getAllBooks = function(selector) {
        var _this = this;

        this._model.getAllBooks()
            .then(function(books) {
                var result = {
                    books: []
                };

                books.forEach(function (book) {
                    result.books.push(new BookInputModel(book._id, book.title, book.isdn));
                });

                _this._viewBag.showBooks(selector, result);
            }).done();
    };

    BookController.prototype.addBook = function(selector, title, author, isdn) {
        var _this = this;

        var bookOutputModel = {
            title: title,
            author: author,
            isdn: isdn
        };

        this._model.addBook(bookOutputModel)
            .then(function() {
                _this.getAllBooks();
            })
    };

    return {
        load: function(model, viewBag) {
            return new BookController(model, viewBag);
        }
    };
}());