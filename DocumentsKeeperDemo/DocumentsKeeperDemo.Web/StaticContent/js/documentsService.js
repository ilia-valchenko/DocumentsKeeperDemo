app.factory("documentsService", ["$http", function ($http) {
    return $http.get("http://localhost:56238/api/documents")
        .then(function successCallback(data) {
                return data;
            },
            function errorCallback(err) {
                return err;
            });
}]);