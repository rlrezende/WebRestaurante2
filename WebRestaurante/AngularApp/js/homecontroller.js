(function (app) {

    var homeController = function ($scope, $http) {
        $scope.messagem = "agora deu"
    };

    app.controller("homeController", homeController)

}(angular.module("webrest")));