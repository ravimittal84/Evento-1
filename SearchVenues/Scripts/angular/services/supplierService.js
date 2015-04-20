/// <reference path="../mainApp.js" />
mainApp.factory("supplierService", function ($http) {
    return {
        get: function (request, callback) {
            $http({
                url: "/api/Supplier",
                method: "GET",
                params: request
            }).success(callback);
        },

        getByID: function (id, callback) {
            $http({
                url: "/api/Supplier/" + id,
                method: "GET"
            }).success(callback);
        }
    }
})