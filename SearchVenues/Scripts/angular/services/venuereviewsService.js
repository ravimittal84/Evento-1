/// <reference path="../mainApp.js" />
mainApp.factory("venuereviewService", function ($http) {
    return {
        get: function (request, callback) {
            $http({
                url: "/api/VenueReview",
                method: "GET",
                params: request
            }).success(callback);
        },
        save: function (data, callback) {
            $http({
                url: "/api/VenueReview",
                method: "POST",
                data: data
            }).success(callback);
        }
    }
})