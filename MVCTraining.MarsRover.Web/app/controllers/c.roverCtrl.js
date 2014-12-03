spAngular.controller('roverCtrl', ['$rootScope', '$scope', '$log', 'roverApiService', function ($rootScope, $scope, $log, roverApiService) {

  $scope.command = '';
  

	$scope.rover = {
	  coordinates: { x: 0, y: 0 },
	  orientation: 2
	};


	$scope.DrawRover = function () {
	  $log.info($scope.command);
	  $scope.mirroredCommand = $scope.MirrorCommands($scope.command);
	  var promise = roverApiService.getPosition({ 'Text': $scope.MirrorCommands($scope.command) });
		promise.then(
		   function (payload) {
		     $scope.rover = payload;
		   },
		   function (errorPayload) {
		   	$log.error('failure loading data', errorPayload);
		   });


	}

	$scope.Reset = function () {
	 
	  var promise = roverApiService.reset();
	  promise.then(
		   function (payload) {
		     $scope.rover = payload;
		   },
		   function (errorPayload) {
		     $log.error('failure loading data', errorPayload);
		   });

	}

	$scope.GetGrid = function () {

	  var promise = roverApiService.getGrid();
	  promise.then(
		   function (payload) {
		     $scope.grid = payload;
		   },
		   function (errorPayload) {
		     $log.error('failure loading data', errorPayload);
		   });

	}


  $scope.MirrorCommands = function(commands) {

    //coordinates commands

    //switch ($scope.rover.orientation) {
    //case CASE1:
      
    //default:
    //}
    var mirroredCommands = commands.replace(new RegExp("F", 'g'), "X");
    mirroredCommands = mirroredCommands.replace(new RegExp("B", 'g'), "F");
    mirroredCommands = mirroredCommands.replace(new RegExp("X", 'g'), "B");

    //orientation commands
    mirroredCommands = mirroredCommands.replace(new RegExp("R", 'g'), "X");
    mirroredCommands = mirroredCommands.replace(new RegExp("L", 'g'), "R");
    mirroredCommands = mirroredCommands.replace(new RegExp("X", 'g'), "L");

    return commands;
  };

  

  $scope.grid = $scope.GetGrid();
	$scope.rover = $scope.DrawRover();
}]);