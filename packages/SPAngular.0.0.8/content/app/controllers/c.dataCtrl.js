spAngular.controller('dataCtrl', ['$scope', '$log', 'dataService', function ($scope, $log, dataService) {
	$scope.welcomeMessage = "Hello SPAngular";
	$scope.items = [];

	$scope.doSomething = function () {

		var promise = dataService.getData();
		promise.then(
		   function (payload) {
		   	$scope.items = payload;
		   },
		   function (errorPayload) {
		   	$log.error('failure loading data', errorPayload);
		   });

	}
}]);