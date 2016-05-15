var events = events || {};

(function(scope) {
    function Employee() {
        this._name = name;
        this._workHours = workHours;
    }

    Employee.prototype.getName = function getName() {
        return this._name;
    };

    Employee.prototype.setName = function setName(name) {
        if (!/^[a-zA-Z\s+]+/.test(name.toString())) {
            throw new Error('Name should be string!');
        }

        this._name = name;
    };

    Employee.prototype.getWorkHours = function getWorkHours() {
        return this._workHours;
    };

    Employee.prototype.setWorkHours = function setWorkHours(workHours) {
        if (!/^[0-9]+/.test(workHours.toString())) {
            throw new Error('WorkHours should be a number!');
        }

        this._workHours = workHours;
    };

    scope._Employee = Employee;

    scope.employee = function() {
        return new Employee();
    }
}(events));