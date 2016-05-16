var BookInputModel = (function () {
    function BookInputModel(id, title, isdn) {
        this._id = id;
        this.title = title;
        this.isdn = isdn;
    }

    return BookInputModel;
}());