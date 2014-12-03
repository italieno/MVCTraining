spAngular.factory('roverApiService', function ($http, $log, $q, blockUI) {
  return {
    getPosition: function (commands) {

      blockUI.start();

      var deferred = $q.defer();

      $http.post('/api/rover/position', commands).
        success(function (data) {
          blockUI.stop();
          deferred.resolve(data);
        }).
        error(function (data, status, headers, config) {
          blockUI.stop();
          $log.error('error calling rover api', data);
        });

      return deferred.promise;
    },
    reset: function () {

      blockUI.start();

      var deferred = $q.defer();

      $http.post('/api/rover/reset').
        success(function (data) {
          blockUI.stop();
          deferred.resolve(data);
        }).
        error(function (data, status, headers, config) {
          blockUI.stop();
          $log.error('error calling rover api', data);
        });

      return deferred.promise;
    },
    getGrid: function() {
      
      blockUI.start();

      var deferred = $q.defer();


      setTimeout(function() {
        blockUI.stop();

        var fakeGrid = [
          [{ row: 0, col: 0 }, { row: 0, col: 1 }, { row: 0, col: 2 }, { row: 0, col: 3 }],
          [{ row: 1, col: 0 }, { row: 1, col: 1 }, { row: 1, col: 2 }, { row: 1, col: 3 }],
          [{ row: 2, col: 0 }, { row: 2, col: 1 }, { row: 2, col: 2 }, { row: 2, col: 3 }],
          [{ row: 3, col: 0 }, { row: 3, col: 1 }, { row: 3, col: 2 }, { row: 3, col: 3 }]
        ];

        deferred.resolve(fakeGrid);
      }, 500);


      //$http.get('/api/someprefix/items')
      //  .success(function (data) {
      //    blockUI.stop();
      //    deferred.resolve(data);
      //  }).error(function (msg, code) {
      //    blockUI.stop();
      //    deferred.reject(msg);
      //    $log.error(msg, code);
      //  });

      return deferred.promise;
    }
  }
});