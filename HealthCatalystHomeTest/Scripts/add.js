app.directive('fileModel', ['$parse', function ($parse) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            var model = $parse(attrs.fileModel);
            var modelSetter = model.assign;
            element.bind('change', function () {
                scope.$apply(function () {
                    modelSetter(scope, element[0].file[0]);
                });
            });
        }
    };
}]);

app.controller('addcontroller', function ($scope, $http) {
    $scope.addFail = "";
    // result
    var onSucess = function (response) {
        alert("Complete to add data!");
        $scope.postClient = "";
    };
    var onFailure = function (reason) {
        $scope.addFail = "Add data to database has failed";
    }
    // search function
    $scope.add = function () {
        $scope.adding = "adding data....";
        var fd = new FormData();
        fd.append('file', $scope.myFile);
        $scope.postClient.Image = fd;
        var url = "http://localhost:54266//main/add/";
        $http.post(url, $scope.postClient).then(onSucess)
    };
})

