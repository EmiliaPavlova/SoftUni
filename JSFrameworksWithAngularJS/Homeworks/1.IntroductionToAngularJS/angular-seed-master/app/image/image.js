'use strict';

angular.module('myApp.image', ['ngRoute'])

.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/image', {
    templateUrl: 'image/image.html',
    controller: 'ImageCtrl'
  });
}])

.controller('ImageCtrl', [function() {

}]);