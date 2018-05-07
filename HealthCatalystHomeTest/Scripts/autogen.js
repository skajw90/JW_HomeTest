// auto generate seed controller
app.controller("generateDBcontroller", function ($scope, $http) {
    
    var onSucess = function (response) {
        alert("Generated");
        $scope.generating = "";
    };

    $scope.generateDB = function () {
        $scope.generating = "Generating...";
        var url = "http://localhost:54266//main/autogen";
        $http.post(url).then(onSucess)
    };
})