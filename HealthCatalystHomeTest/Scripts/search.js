var app = angular.module('myApp', []);
// search controller
app.controller("searchcontroller", function ($scope, $http) {
    $scope.searchFail = "";
    // result
    var onSucess = function (response) {
        $scope.clients = response.data;
        // initialize
        $scope.name = "";
        $scope.searching = "";
        $scope.searchFail = "";
    };
    var onFailure = function (reason) {
        $scope.searchFail = "There is no matching data";
    }
    // search function
    $scope.search = function () {
        $scope.searching = "Searching data....";
        var url = "http://localhost:54266//main/search/" + $scope.name;
        $http.get(url).then(onSucess)
    };

    $scope.setSelect = function (client) {
        $scope.selected = client;

    }
})

