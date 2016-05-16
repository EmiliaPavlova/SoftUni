var app = app || {};

app.bookModel = (function () {
    function BookModel(requester) {
        this.requester = requester;
        this.serviceUrl = this.requester.baseUrl + 'appdata/' + this.requester.appId + '/books';
    }

    BookModel.prototype.getAllBooks = function () {
        return this.requester.get(this.serviceUrl, true);
    };

    BookModel.prototype.addBook = function(data) {
        return this.requester.post(this.serviceUrl, data, true);
    };

    BookModel.prototype.editBook = function(data) {
        return this.requester.put(this.serviceUrl, data, true);
    };

    BookModel.prototype.deleteBook = function(data) {
        return this.requester.delete(this.serviceUrl, data, true);
    };

    return {
        load: function(requester) {
            return new BookModel(requester);
        }
    }
}());