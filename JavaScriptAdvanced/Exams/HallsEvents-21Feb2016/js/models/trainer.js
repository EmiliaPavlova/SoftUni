var events = events || {};

(function(scope) {
    function Trainer(courses, feedbacks) {
        scope._Employee.call(this, courses, feedbacks);
        this.courses = [];
        this.feedbacks = [];
    }

    Trainer.prototype.addFeedback = function(feedback) {
        if(/^[a-zA-Z\s+]+/.test(name.toString())) {
            this.feedbacks.push(feedback);
        } else {
            throw new Error('Not a string!');
        }
    };

    Trainer.prototype.addCourse = function(course) {
        if(course instanceof scope._Course) {
            this.courses.push(course);
        } else {
            throw new Error('Not an instance of Course!');
        }
    };

    Trainer.extend(scope._Employee)
    scope._Trainer = Trainer;
    scope.trainer = function() {
        return new Trainer();
    }
}(events));