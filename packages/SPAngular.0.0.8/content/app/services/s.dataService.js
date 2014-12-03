spAngular.factory('dataService', function ($http, $log, $q, blockUI) {
  return {
    getData: function () {

      blockUI.start();

      var deferred = $q.defer();

      $http.get('/api/someprefix/items')
        .success(function (data) {
          blockUI.stop();
          deferred.resolve(data);
        }).error(function (msg, code) {
          blockUI.stop();
          deferred.reject(msg);
          $log.error(msg, code);
        });


      return deferred.promise;
    }
  }
});