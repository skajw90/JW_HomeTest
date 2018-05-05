// auto generate seed controller
app.controller("generateDBcontroller", function ($scope, $http) {

    $scope.isDone = "false";
    var onSucess = function (response) {
        alert("Generated");
        $scope.isDone = "true";
    };

    $scope.generateDB = function () {
        var url = "http://localhost:54266//main/autogen";
        $http.post(url).then(onSucess)
    };
})