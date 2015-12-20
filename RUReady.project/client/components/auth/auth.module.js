'use strict';

angular.module('rureadyProjectApp.auth', [
  'rureadyProjectApp.constants',
  'rureadyProjectApp.util',
  'ngCookies',
  'ui.router'
])
  .config(function($httpProvider) {
    $httpProvider.interceptors.push('authInterceptor');
  });
