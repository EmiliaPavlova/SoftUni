var app = app || {};

app.lecturesController = (function() {
    function LecturesController(viewBag, model) {
        this.model = model;
        this.viewBag = viewBag;
    }

    LecturesController.prototype.loadLectures = function(selector) {
        var _this = this;
        var date = new Date().toISOString();
        this.model.getLectures(date)
            .then(function(successData) {
                var result = {
                    lectures: []
                };

                successData.forEach(function(lecture) {
                    result.lectures.push({
                        title: lecture.title,
                        start: lecture.start,
                        end: lecture.end,
                        lecturer: lecture.lecturer,
                        id: lecture._id});
                });

                _this.viewBag.showLectures(selector, result.lectures);
            })
    };

    LecturesController.prototype.loadMyLectures = function (selector) {
        var _this = this;
        var userId = sessionStorage['userId'];
        this.model.getLecturesByCreatorId(userId)
            .then(function (data) {
                var result = {
                    lectures: []
                };

                data.forEach(function (lecture) {
                    result.lectures.push({
                        title: lecture.title,
                        start: lecture.start,
                        end: lecture.end,
                        lecturer: lecture.lecturer,
                        id: lecture._id});
                });

                _this.viewBag.showMyLectures(selector, result);
            })
    };

    LecturesController.prototype.loadAddLecture = function(selector) {
        this.viewBag.showAddLecture(selector);
    };

    LecturesController.prototype.addLecture = function (data) {
        var result = {
            title: data.title,
            start: data.start,
            end: data.end
        };

        this.model.addLecture(result)
            .then(function () {
                Sammy(function() {
                    this.trigger('redirectUrl', {url:'#/calendar/my/'})
                })
            });
    };

    LecturesController.prototype.loadEditLecture = function (selector, data) {
        this.viewBag.showEditLecture(selector, data);
    };

    LecturesController.prototype.editLecture = function (data) {
        data.author = sessionStorage['username'];
        this.model.editLecture(data._id, data)
            .then(function (success) {
                console.log(success);
            })
    };

    LecturesController.prototype.loadDeleteLecture = function (selector, data) {
        this.viewBag.showDeleteLecture(selector, data);
    };

    LecturesController.prototype.deleteLecture = function (lectureId) {
        this.model.deleteLecture(lectureId)
            .then(function (success) {
                window.location.reload();
            });
    };

    return {
        load: function (viewBag, model) {
            return new LecturesController(viewBag, model);
        }
    };
}());