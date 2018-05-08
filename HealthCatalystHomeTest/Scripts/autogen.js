// auto generate seed controller
app.controller("generateDBcontroller", function ($scope, $http) {
    $scope.generating = "Auto Generate";
    var onSucess = function (response) {
        alert("Generated");
        $scope.generating = "Auto Generate";
    };

    $scope.generateDB = function () {
        $scope.generating = "Generating...";
        var url = "http://localhost:54266//main/autogen";
        $http.post(url).then(onSucess)
    };
})