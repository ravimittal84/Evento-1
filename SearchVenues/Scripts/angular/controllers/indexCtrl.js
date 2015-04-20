/// <reference path="../mainApp.js" />
mainApp.controller("indexCtrl", ["$scope", "getCities", "$http", function ($scope, getCities, $http) {
    $scope.getLocation = function (text) {
        $scope.Request = new Request();
        $scope.Request.Criteria = "[{Key: 'SearchText', Value: '" + text + "'}]";
        return $http({
            url: "/api/Cities",
            method: "GET",
            params: $scope.Request.get()
        }).then(function (data) {
            return data.data.Data.map(function (item) {
                return item;
            })
        })
    }
    $scope.Search = function (data) {
        window.location.href = "/Home/Venues/" + data.originalObject.value;
    }
}])
//(function () {
//    'use strict';
//    mainApp
//        .controller('DemoCtrl', DemoCtrl);

//    function DemoCtrl($timeout, $q, $http, getCities, $scope) {
//        var self = this;

//        // list of `state` value/display objects
//        self.states = null;
//        self.selectedItem = null;
//        self.searchText = null;
//        self.querySearch = querySearch;
//        self.simulateQuery = false;
//        self.isDisabled = false;

//        // ******************************
//        // Internal methods
//        // ******************************

//        /**
//         * Search for states... use $timeout to simulate
//         * remote dataservice call.
//         */

//        $scope.GetCityList = function () {
//            //To make request synchronous.
//            var differed = $q.defer();
//            $http({
//                url: "/api/Cities",
//                method: "GET"
//            }).success(function (data) {
//                self.states = data.Data;
//                differed.resolve(self.states);
//            })
//            return differed.promise;
//        }

//        function querySearch(query) {
//            $scope.result;
//            var results;
//            var promise = $scope.GetCityList();
//            promise.then(function (resolve) {
//                $scope.result = resolve;
//            })
//            if (typeof ($scope.result !== "undefined")) {
//                    results = query ? self.states.filter(createFilterFor(query)) : [];
//                    var deferred;
//                    if (self.simulateQuery) {
//                        deferred = $q.defer();
//                        $timeout(function () { deferred.resolve(results); }, Math.random() * 1000, false);
//                        return deferred.promise;
//                    } else {
//                        return results;
//                    }
                
               
//            }
//        }
//        $scope.Search = function (e) {
//            if (e != null) {
//                window.location.href = "/Home/Venues/" + e.value;
//            }
//        }
//            /**
//             * Create filter function for a query string
//             */
//            function createFilterFor(query) {
//                //var lowercaseQuery = angular.lowercase(query);

//                return function filterFn(state) {
//                    return (state.display.indexOf(query) === 0);
//                };

//            }
//        }
//    })();
