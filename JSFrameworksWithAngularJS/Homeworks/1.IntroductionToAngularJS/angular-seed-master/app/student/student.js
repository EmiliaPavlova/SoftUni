'use strict';

angular.module('myApp.student', ['ngRoute'])

.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/student', {
    templateUrl: 'student/student.html',
    controller: 'StudentCtrl'
  });
}])

.controller('StudentCtrl', ['$scope', function($scope) {
  $scope.name = 'Pesho',
  $scope.photo = 'http://img.bg.sof.cmestatic.com/media/images/600x/Jan2016/2110980897.jpg',
  $scope.grade = 5,
  $scope.school = 'High School of Mathematics',
  $scope.teacher = 'Gichka Pesheva';
}]);