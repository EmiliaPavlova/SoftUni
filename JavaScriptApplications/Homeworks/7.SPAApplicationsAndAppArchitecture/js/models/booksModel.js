var app = app || {};

app.booksModel = (function() {
    function BooksModel(requester) {
        this._requester = requester;
        this.serviceUrl = requester.baseUrl + 'appdata/' + requester.appId + '/books/';
    }

    BooksModel.prototype.getAllBooks = function() {
        return this._requester.get(this.serviceUrl, true);
    };

    BooksModel.prototype.addBook = function(data) {
        return this._requester.post(this.serviceUrl, data, true);
    };

    BooksModel.prototype.editBook = function(data) {
        return this.requester.put(this.serviceUrl, data, true);
    };

    BooksModel.prototype.deleteBook = function() {
        return this.requester.delete(this.serviceUrl, null, true);
    };

    return {
        load: function (requester) {
            return new BooksModel(requester);
        }
    }
}());