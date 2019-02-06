app.controller("DocumentsController", ["$scope", "documentsService", function ($scope, documentsService) {
    documentsService.then(function (data) {
        $scope.documents = data.data;
    });

    /*$scope.uploadFile = function() {
		var file = $scope.myFile;

		console.log("File is ");
		console.dir(file);

		var uploadUrl = "/fileUpload";
		fileUpload.uploadFileToUrl(file, uploadUrl);
	};*/

}]);