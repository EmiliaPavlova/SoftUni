Object.prototype.extends = function(parent) {
    this.prototype = Object.create(parent.prototype);
    this.prototype.constructor = this;
};

var popups = (function() {
    function Popup(title, message) {
        if (this.constructor === Popup) {
            throw new Error("Can't instantiate abstract class!");
        }
        this.title = title;
        this.message = message;
        this.timeout = 5000;
    }

    function Success(title, message) {
        Popup.call(this, title, message);
        this.position = 'bottomLeft';
        this.type = 'success';
        this.autoHide = true;
    }
    Success.extends(Popup);

    function Info(title, message) {
        Popup.call(this, title, message);
        this.position = 'topLeft';
        this.type = 'info';
        this.closeButton = true;
    }
    Info.extends(Popup);

    function Error(title, message) {
        Popup.call(this, title, message);
        this.position = 'topRight';
        this.type = 'error';
    }
    Error.extends(Popup);

    function Warning(title, message, callback) {
        Popup.call(this, title, message);
        this.position = 'bottomRight';
        this.type = 'warning';
        this.callback = callback;
    }
    Warning.extends(Popup);

    return {
        createSuccess: function(title, message) {
            return {
                _popupData: new Success(title, message)
            }
        },
        createInfo: function(title, message) {
            return {
                _popupData: new Info(title, message)
            }
        },
        createError: function(title, message) {
            return {
                _popupData: new Error(title, message)
            }
        },
        createWarning: function(title, message, callback) {
            return {
                _popupData: new Warning(title, message, callback)
            }
        }
    }
}());