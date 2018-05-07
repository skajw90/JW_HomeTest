app.service('multipartForm', ['$http', function ($http) {
    this.post = function (url, data) {
        var fd = new FormData();
        for (var key in data)
            fd.append(key, data[key]);
        $http.post(url, fd, {
            transformRequest: angular.indentity,
            headers: { 'Content-Type': undefined }
        })
    }
}])