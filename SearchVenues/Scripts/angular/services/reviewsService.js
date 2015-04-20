/// <reference path="../mainApp.js" />
mainApp.factory("reviewsService", function ($http) {
    return {
        save: function (review, callback) {
            $http({
                url: "/api/Reviews",
                method: "POST",
                data: review
            }).success(callback);
        },
        get: function (request, callback) {
            $http({
                url: "/api/Reviews",
                method: "GET",
                params: request
            }).success(callback);
        }
    }
})