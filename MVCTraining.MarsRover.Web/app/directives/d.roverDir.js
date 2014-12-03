spAngular.directive('ngRover', function () {

 
  return {
    restrict: 'E',
    scope: {
      coordinates: '=coordinates',
      orientation: '=orientation',
      grid: '=grid'
    },
    templateUrl: 'app/directives/d.roverDir.html',

    link: function (scope) {

      var getClassByOrientation = function (orientation) {

        var direction;

        switch (orientation) {
          case 0:
            direction = 'up';
            break;

          case 1:
            direction = 'right';
            break;

          case 2:
            direction = 'down';
            break;

          case 3:
            direction = 'left';
            break;

          default:
            direction = 'up';
            break;
        }

        return 'glyphicon glyphicon glyphicon-circle-arrow-' + direction + ' glyphicon-align-left';
      }

      var getClassByPosition = function (coordinates) {

        if (typeof coordinates == 'undefined' || coordinates == null)
          return 'rover grid-row-0 grid-column-0';
        
        return 'rover grid-row-' + coordinates.y + ' grid-column-' + coordinates.x;
      }

      scope.$watch('coordinates', function () {
        scope.roverPositionClassName = getClassByPosition(scope.coordinates);
      });

      scope.$watch('orientation', function(){
        scope.roverOrientationClassName = getClassByOrientation(scope.orientation);
      });
      
      scope.gridRow = function(index) {
        return 'grid-row grid-row-' + index;
      }

      scope.gridColumn = function (index) {
        return 'grid-cell grid-column grid-column-' + index;
      }

    
    }
  }
});