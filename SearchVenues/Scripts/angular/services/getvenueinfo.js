/// <reference path="../mainApp.js" />
mainApp.factory("getvenueinfo", function ($http) {
    return {
        getByID: function (id, callback) {
            $http({
                url: "/api/Venues/" + id,
                method: "GET"
            }).success(callback);
        }
    }
})