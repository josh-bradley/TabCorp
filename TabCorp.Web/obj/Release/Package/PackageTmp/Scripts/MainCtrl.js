(function(){
    var app = angular.module("tabcorp");

    var MainCtrl = function($scope, betCalculatorService) {
        console.log("controller constructor");
        $scope.bets = "W:1:3;W:2:4;W:3:5;W:4:5;W:1:16;W:2:8;W:3:22;W:4:57;W:1:42;W:2:98;W:3:63;W:4:15;P:1:31;P:2:89;P:3:28;P:4:72;P:1:40;P:2:16;P:3:82;P:4:52;P:1:18;P:2:74;P:3:39;P:4:105;E:1,2:13;E:2,3:98;E:1,3:82;E:3,2:27;E:1,2:5;E:2,3:61;E:1,3:28;E:3,2:25;E:1,2:81;E:2,3:47;E:1,3:93;E:3,2:51;Q:1,2:19;Q:2,3:77;Q:1,3:26;Q:2,4:63;Q:1,2:66;Q:2,3:82;Q:1,3:90;Q:2,4:48;Q:1,2:18;Q:2,3:93;Q:1,3:62;Q:2,4:25;";
        $scope.raceResults = "R:2:3:1:4";
        $scope.calculateBets = function () {
            betCalculatorService.calculateBets({ betString: $scope.bets, resultsString: $scope.raceResults }, populateResults);
        };
        $scope.dividendResults = "";

        var populateResults = function(data) {
            $scope.dividendResults = data;
        };
    };

    app.controller("MainCtrl", MainCtrl);
})();