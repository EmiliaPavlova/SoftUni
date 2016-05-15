var events = events || {};

(function(scope) {
    var Course = (function() {
        function Course() {
            this._name = name;
            this._numberOfLectures = numberOfLectures;
        }

        Course.prototype.getName = function getName() {
            return this._name;
        };

        Course.prototype.setName = function setName(name) {
            if (!/^[a-zA-Z\s+]+$/.test(name.toString())) {
                throw new Error('Name should be string!');
            }

            this._name = name;
        };

        Course.prototype.getNumberOfLectures = function getNumberOfLectures() {
            return this._numberOfLectures;
        };

        Course.prototype.setNumberOfLectures = function setNumberOfLectures(numberOfLectures) {
            if (!/^[0-9]+$/.test(numberOfLectures.toString())) {
                throw new Error('NumberOfLectures should be a number!');
            }

            this._numberOfLectures = numberOfLectures;
        };

        scope._Course = Course;
        scope.course = function () {
            return new Course();
        }
    }());
}(events));