/// <reference path="../controllers/venuesCtrl.js" />
mainApp.factory("getFacilities", function ($http) {
    return {
        get: function (callback) {
            $http({
                url: "api/Facilities",
                method: "GET"
            }).success(callback);
        },
        getByRequest: function (request, callback) {
            $http({
                url: "/api/Facilities",
                method: "GET",
                params: request
            }).success(callback);
        }
    }
})