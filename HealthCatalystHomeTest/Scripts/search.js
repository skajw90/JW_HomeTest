var app = angular.module('myApp', []);
// search controller
app.controller("searchcontroller", function ($scope, $http) {
    // initialize all variables
    $scope.clearing = "";
    $scope.searching = "";
    $scope.searchFail = "";
    $scope.selected = {};
    $scope.selected.Image = null;
    $scope.clients = {};
    // result
    var onSucess = function (response) {
        $scope.clients = response.data;
        if ($scope.clients.length == 0)
            $scope.searchFail = "There is no matching data";
        else
            $scope.searchFail = "";
        // initialize
        $scope.name = "";
        $scope.searching = "";      
    };
    var clearSucess = function (response) {
        alert("Cleared!");
        $scope.clients = {};
        $scope.selected = {};
        $scope.selected.Image = null;
        $scope.name = "";
        $scope.clearing = "";
    }
    // search function
    $scope.search = function () {
        $scope.searching = "Searching data....";
        var url = "http://localhost:54266//main/search/" + $scope.name;
        $http.get(url).then(onSucess)
    };

    $scope.clear = function () {
        $scope.clearing = "Clearing...";
        var url = "http://localhost:54266//main/clear";
        $http.delete(url).then(clearSucess)
    }

    $scope.setSelect = function (client, index) {
        $scope.selectedIndex = index;
        $scope.selected = client;

    }
})

