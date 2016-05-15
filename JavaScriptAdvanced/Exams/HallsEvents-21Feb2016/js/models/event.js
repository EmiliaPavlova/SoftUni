var events = events || {};

(function (scope) {
    var Event = (function() {
        //function Event(title, type, duration, date) {
        function Event(options) {

            if (this.constructor === Event) {
                throw new Error('Cannot instantiate this class!');
            }

            this.options = {
                title: this.setTitle(title),
                type: this.setType(type),
                duration: this.setDuration(duration),
                date: this.setDate(date)
            }

            //this.setTitle(title);
            //this.setType(type);
            //this.setDuration(duration);
            //this.setDate(date);
        }

        Event.prototype.getTitle = function getTitle() {
            return this._title;
        };

        Event.prototype.setTitle = function setTitle(title) {
            if (!/^[a-zA-Z\s+]+/.test(title.toString())) {
                throw new Error('Title should be string!');
            }

            this._title = title;
        };

        Event.prototype.getType = function getType() {
            return this._type;
        };

        Event.prototype.setType = function setType(type) {
            if (!/^[a-zA-Z\s+]+/.test(type.toString())) {
                throw new Error('Type should be string!');
            }

            this._type = type;
        };

        Event.prototype.getDuration = function getDuration() {
            return this._duration;
        };

        Event.prototype.setDuration = function setDuration(duration) {
            if (!/^[0-9]+/.test(duration.toString())) {
                throw new Error('Duration should be a number!');
            }

            this._duration = duration;
        };

        Event.prototype.getDate = function getDate() {
            return this._date;
        };

        Event.prototype.setDate = function setDate(date) {
            if (!date instanceof Date) {
                throw new Error('Invalid date!');
            }

            this._date = date;
        };

        scope._Event = Event;
        return Event;
    }());
}(events));