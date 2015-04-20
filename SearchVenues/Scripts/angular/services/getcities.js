/// <reference path="../../angular.js" />
/// <reference path="../mainApp.js" />
mainApp.factory("getCities", function ($http) {
    return {
        get: function (value, callback) {
            $http({
                url: "/api/Cities",
                method: "GET",
                params: value
            }).success(callback);
        },

        getByID: function (id, callback) {
            $http({
                url: "/api/Cities/" + id,
                method: "GET",
            }).success(callback);
        }
    }
})