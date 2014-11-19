(function () {
    var app = angular.module("tabcorp", ["ngRoute"]);

    app.config(function($routeProvider) {
        $routeProvider
            .when("/main", {
                templateUrl: "/Home/MainCtrl",
                    controller: "MainCtrl"
                }
            )
            .otherwise({ redirectTo: "/main" });
    });
})();