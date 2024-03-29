﻿spAngular.config(function ($stateProvider, $urlRouterProvider) {
  //
  // For any unmatched url, redirect to /state1
  $urlRouterProvider.otherwise("/state1");
  //
  // Now set up the states
  $stateProvider
    .state('state1', {
      url: "/state1",
      templateUrl: "app/partials/state1.html",
      controller: 'dataCtrl'
    })
    .state('state2', {
      url: "/state2",
      templateUrl: "app/partials/state2.html"
    })
    .state('state2.list', {
      url: "/list",
      templateUrl: "app/partials/state2.list.html",
      controller: function ($scope) {
        $scope.things = ["A", "Set", "Of", "Things"];
      }
    });
}); 