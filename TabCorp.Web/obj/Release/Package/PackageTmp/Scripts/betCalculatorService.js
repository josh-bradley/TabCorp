(function(){
    var betCalculatorService = function($http) {
        var calculateBets = function (betDetails, callback) {
            $http.post("/api/Dividend", betDetails)
            .success(callback);
        };

        return {
            calculateBets: calculateBets
        }
    };

    var module = angular.module("tabcorp");

    module.factory("betCalculatorService", betCalculatorService);
})();