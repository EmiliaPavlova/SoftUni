var app = app || {};

(function(scope) {
    scope.data = {};
    var BASE_URL = 'http://baas.kinvey.com';
    var APP_KEY = 'kid_W1vaK0Pby-';
    var APP_SECRET = 'df086ebfe84849fbbc9797a226e28b9b';

    var CRUD = function(crudMethod, crudUrl, crudData, crudSuccessCallback, crudErrorCallback, contentType) {
        var USER_AUTH = 'YWRtaW46YWRtaW5hZG1pbg==';

        $.ajax({
            method: crudMethod,
            headers: {
                'Authorization' : 'Basic ' + USER_AUTH,
                'X-Kinvey-API-Version' : '3',
                'Content-Type' : contentType
            },
            url: crudUrl,
            data: JSON.stringify(crudData)
        }).success(crudSuccessCallback).error(crudErrorCallback);
    };

    scope.loadCountries = function() {
        var allPath = BASE_URL + '/appdata/' + APP_KEY + '/Countries';
        CRUD('GET', allPath, null, scope.successfulCountriesLoad, scope.showAJAXError, 'application/json');
    };

    scope.loadCountryTowns = function(e){
        var countryId = $(this).parent().attr('data-id');
        var query = '?query={"country._id":"' + countryId + '"}';
        var getCountryTownsUrl = BASE_URL + '/appdata/' + APP_KEY + '/towns' + query;

        scope.data.countryId = countryId;
        CRUD('GET', getCountryTownsUrl, null, scope.successfulTownsLoad, scope.showAJAXError);

        e.preventDefault();
    };


    scope.editCountry = function(e){
        var countryId = $('#edit-country').attr('data');
        var country = $('#edit-country-value').val();
        var editData = {'name': country};

        CRUD('PUT', BASE_URL + '/appdata/' + APP_KEY + '/countries/' + countryId, editData, scope.reloadCountries, scope.showAJAXError, 'application/json');

        e.preventDefault();
    };

    scope.editTown = function(e){
        var townId = $('#edit-town-value').attr('data');
        var town = $('#edit-town-value').val();
        //var editData = {'name' : town};
        var countryId = $('#new-town-value').attr('data');
        var newTownData = {
            'country': {
                "__type": "KinveyRef",
                "_collection": "countries",
                "_id": countryId
            },
            'name': town
        };


        CRUD('PUT', BASE_URL + '/appdata/' + APP_KEY + '/towns/' + townId, newTownData, scope.reloadCountries, scope.showAJAXError, 'application/json');

        e.preventDefault();
    };

    scope.addNewCountry = function(e){
        var newCountryValue = $('#add-country').val();
        var newCountryData = {'name': newCountryValue};

        var allPath = BASE_URL + '/appdata/' + APP_KEY + '/countries';
        CRUD('POST', allPath, newCountryData, scope.reloadCountries, scope.showAJAXError, 'application/json');

        $('#add-country').val('');
        e.preventDefault();
    };

    scope.addNewTown = function(e){
        var newTownValue = $('#new-town-value').val();
        var countryId = $('#new-town-value').attr('data');
        var newTownData = {
            'country': {
                "__type": "KinveyRef",
                "_collection": "countries",
                "_id": countryId
            },
            'name': newTownValue
        };

        var allPath = BASE_URL + '/appdata/' + APP_KEY + '/towns';
        CRUD('POST', allPath, newTownData, scope.reloadCountries, scope.showAJAXError, 'application/json');

        e.preventDefault();
    };

    scope.deleteCountry = function(e){
        var countryId = $(this).parent().attr('data-id');

        CRUD('DELETE', BASE_URL + '/appdata/' + APP_KEY + '/countries/' + countryId, null, scope.reloadCountries, scope.showAJAXError);

        e.preventDefault();
    };

    scope.deleteTown = function(e){
        var townId = $(this).parent().attr('data-id');

        CRUD('DELETE', BASE_URL + '/appdata/' + APP_KEY + '/towns/' + townId, null, scope.reloadCountries, scope.showAJAXError);

        e.preventDefault();
    };
}(app));