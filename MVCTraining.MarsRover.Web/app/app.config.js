spAngular.config(function ($stateProvider, $urlRouterProvider) {
  //
  // For any unmatched url, redirect to /state1
  $urlRouterProvider.otherwise("/mars");
  //
  // Now set up the states
  $stateProvider
    .state('mars', {
      url: "/mars",
      templateUrl: "app/partials/mars.html",
      controller: 'roverCtrl'
    })
}); 