// add controller
app.controller("addcontroller", function ($scope, $http) {
    $scope.postClient = {};
    $scope.adding = "";

    var onSucess = function (response) {
        alert("Added!");
        // initialize
        $scope.adding = "";
        $scope.postClient = {};
        $scope.postClient.Image = null;
    };

    // change image format to byte array
    $scope.uploadFile = function (input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {                

                var canvas = document.createElement("canvas");
                var imageElement = document.createElement("img");

                imageElement.setAttribute('src', e.target.result);
                canvas.width = imageElement.width;
                canvas.height = imageElement.height;
                var context = canvas.getContext("2d");
                context.drawImage(imageElement, 0, 0);
                var base64Image = canvas.toDataURL("image/jpeg");

                $scope.postClient.Image = base64Image.replace(/data:image\/jpeg;base64,/g, '');
            }

            reader.readAsDataURL(input.files[0]);
        }
    }
    // post data to server
    $scope.add = function () {
        $scope.adding = "adding...";
        var url = "http://localhost:54266//main/add";
        $http.post(url, $scope.postClient).then(onSucess)
    }
});