var events = events || {};

(function(scope) {
    function Party(options) {
        scope._Event.call(this);
        this.options = {
            isCatered: this._isCatered(isCatered || false),
            isBirthday: this._isBirthday(isBirthday || false),
            organiser: this._organiser(organiser)
        }
    }

    Party.prototype.getOrganiser = function getOrganiser() {
        return this._organiser;
    };

    Party.prototype.setOrganiser = function setOrganiser(organiser) {
        if (!organiser instanceof scope._Employee) {
            throw new Error('Not an Employee instance!');
        }

        this._organiser = organiser;
    };

    Party.extend(scope._Event)

    scope.party = function() {
        return new Party();
    }
}(events));