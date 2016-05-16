;
(function ($, window, undefined) {

    var defaults = {
        baseURL: 'https://baas.kinvey.com',
        appID: 'kid_W1vaK0Pby-',
        username: 'admin',
        pass: 'adminadmin',
        showCountriesButton: '#show-countries',
        addCountryButton: '#add-country',
        deleteCountry: '#delete-country',
        dataContainer: '#dataContainer',
        userInputCountryName: '#country-name'
    };

    function GeographyApp(options) {
        this.settings = $.extend({}, defaults, options);

        this.$showCountriesButton = $(this.settings.showCountriesButton);
        this.$addCountryButton = $(this.settings.addCountryButton);
        this.$deleteCountry = $(this.settings.deleteCountry);
        this.$dataContainer = $(this.settings.dataContainer);
    }

    GeographyApp.prototype.init = function () {
        this.$showCountriesButton.on('click', $.proxy(this.getCountries, this));
        this.$deleteCountry.on('click', $.proxy(this.renderDeleteCountry, this));
        this.$addCountryButton.on('click', $.proxy(this.renderAddCountryView, this));
    };

    GeographyApp.prototype.getCountries = function () {
        var _this = this;
        $.ajax({
            method: 'GET',
            url: _this.settings.baseURL + '/appdata/' + _this.settings.appID + '/Countries',
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', 'Basic ' + btoa(_this.settings.username + ':' + _this.settings.pass));
            }
        }).done(_this.renderCountriesView)
            .error(function (data) {
                console.log(data);
            });
    };

    GeographyApp.prototype.addCountry = function () {
        var _this = this;
        var countryName = $('#country-name').val();

        if (countryName !== '') {
            $.ajax({
                    method: 'POST',
                    url: _this.settings.baseURL + '/appdata/' + _this.settings.appID + '/Countries',
                    beforeSend: function (xhr) {
                        xhr.setRequestHeader('Authorization', 'Basic ' + btoa(_this.settings.username + ':' + _this.settings.pass));
                    },
                    contentType: 'application/json',
                    data: JSON.stringify({'Name': countryName})
                }
            ).done(function () {
                _this.getCountries();
            });
        }
    };


    GeographyApp.prototype.deleteCountry = function () {
        var _this = this;
        var countryName = $('#country-name').val();
        var query = '{"Name":"' + countryName + '"}';

        if (countryName !== '') {
            $.ajax({
                method: 'DELETE',
                url: _this.settings.baseURL + '/appdata/' + _this.settings.appID + '/Countries/?query=' + query,
                beforeSend: function (xhr) {
                    xhr.setRequestHeader('Authorization', 'Basic ' + btoa(_this.settings.username + ':' + _this.settings.pass));
                }
            }).done(function () {
                _this.getCountries();
            });
        }
    };

    GeographyApp.prototype.renderAddCountryView = function () {
        var section = $('<section>')
            .addClass('add-country')
            .append('<h3>Add country</h3>');

        var label = $('<label>Name: </label>');
        var input = $('<input>').attr({'type': 'text', id: 'country-name'});
        var btn = $('<button>Add country</button>').addClass('add-country-btn').attr('id', 'add-country');
        btn.on('click', $.proxy(this.addCountry, this));
        label.append(input);
        section.append(label);
        section.append(btn);
        this.$dataContainer.html(section);
    };

    GeographyApp.prototype.renderCountriesView = function (data) {
        var countriesUl = $('<ul>').addClass('countries-list');
        for (var country in data) {
            var li = $('<li>');
            li.text(data[country].Name);
            countriesUl.append(li);
        }
        $('#dataContainer').html(countriesUl);
    };

    GeographyApp.prototype.renderDeleteCountry = function () {
        console.log('render delete');
        var section = $('<section>')
            .addClass('add-country')
            .append('<h3>Delete country</h3>');

        var label = $('<label>Name: </label>');
        var input = $('<input>').attr({'type': 'text', id: 'country-name'});
        var btn = $('<button>Delete country</button>').addClass('add-country-btn').attr('id', 'delete-country');
        btn.on('click', $.proxy(this.deleteCountry, this));
        label.append(input);
        section.append(label);
        section.append(btn);
        this.$dataContainer.html(section);
    };

    window.GeographyApp = GeographyApp;

})
(jQuery, window);