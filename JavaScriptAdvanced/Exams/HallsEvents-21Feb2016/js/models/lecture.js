var events = events || {};

(function(scope) {
    function Lecture(options) {
        scope._Event.call(this);
        this.options = {
            trainer: this._trainer(trainer),
            course: this._course(course)
        }
    }

    Lecture.prototype.getTrainer = function getTrainer() {
        return this._trainer;
    };

    Lecture.prototype.setTrainer = function setTrainer(trainer) {
        if (!trainer instanceof scope._Trainer) {
            throw new Error('Not a Trainer instance!');
        }

        this._trainer = trainer;
    };

    Lecture.prototype.getCourse = function getCourse() {
        return this._course;
    };

    Lecture.prototype.setCourse = function setCourse(course) {
        if (!course instanceof scope._Course) {
            throw new Error('Not a Course instance!');
        }

        this._course = course;
    };

    Lecture.extend(scope._Event)

    scope.course = function() {
        return new Course();
    }
}(events));