// clear controller
app.controller("clearcontroller", function ($scope, $http) {
    
    $scope.clearing = "";
    var onSucess = function (response) {
        alert("Cleared");
        $scope.clearing = "";
    };
    var onFailure = function (reason) {
        alert("Clear Failed :" + reason);
        $scope.clearing = "";
    }

    $scope.clear = function () {
        $scope.clearing = "Clearing...";
        var url = "http://localhost:54266//main/clear";
        $http.delete(url).then(onSucess, onFailure)
    };
})