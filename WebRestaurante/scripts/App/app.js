(function () {

    var app = angular.module("webrestaurante", ["ngRoute"]);

    var config = function ($routeProvider) {

        $routeProvider
        .when("/",
               { templateUrl: "/Cliente/html/teste.html", controller: "homerController" })
        .otherwise(
               { redirecTo: "/" });
        $locationProvider.html5Mode(true);
    };
    app.config(config);
}());
