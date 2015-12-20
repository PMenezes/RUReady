'use strict';

angular.module('rureadyProjectApp', [
  'rureadyProjectApp.auth',
  'rureadyProjectApp.admin',
  'rureadyProjectApp.constants',
  'ngCookies',
  'ngResource',
  'ngSanitize',
  'btford.socket-io',
  'ui.router',
  'ui.bootstrap',
  'validation.match'
])
  .config(function($urlRouterProvider, $locationProvider) {
    $urlRouterProvider
      .otherwise('/');

    $locationProvider.html5Mode(true);
  });
