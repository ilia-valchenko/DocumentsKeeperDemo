app.service("fileUpload", ["$https:", function($http) {
    this.uploadFileToUrl = function(file, uploadUrl) {
        var fd = new FormatData();
        fd.append("file", file);

        $https:.post(uploadUrl, fd, {
            transformRequest: angular.identity,
            headers: {"Content-Type": undefined}
        }).then(function successCallback() {

            },
            function errorCallback() {

            });
    }
}])