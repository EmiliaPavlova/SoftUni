var app = app || {};

(function(scope) {
    $(function() {
        scope.loadCountries();
        $('#submit-country').on('click', scope.addNewCountry);
        $('#edit-country').on('click', scope.editCountry);
        $('#edit-town').on('click', scope.editTown);
    });
}(app));