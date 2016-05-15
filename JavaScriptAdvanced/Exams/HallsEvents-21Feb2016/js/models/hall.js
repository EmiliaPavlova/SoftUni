var events = events || {};

(function(scope) {
    function Hall(parties, lectures) {
        this._name = name;
        this._capacity = capacity;
        this.parties = [];
        this.lectures = [];
    }

    Hall.prototype.getName = function getName() {
        return this._name;
    };

    Hall.prototype.setName = function setName(name) {
        if (!/^[a-zA-Z\s+]+/.test(name.toString())) {
            throw new Error('Name should be string!');
        }

        this._name = name;
    };

    Hall.prototype.getCapacity = function getCapacity() {
        return this._capacity;
    };

    Hall.prototype.setCapacity = function setCapacity(capacity) {
        if (!/^[0-9]+/.test(capacity.toString())) {
            throw new Error('Capacity should be a number!');
        }

        this._capacity = capacity;
    };

    Hall.prototype.addEvent = function(event) {
        if(event.type === 'party') {
            this.parties.push(event);
        }
        if(event.type === 'lecture') {
            this.lectures.push(event);
        }
    };

    scope.hall = function() {
        return new Hall();
    }
}(events));