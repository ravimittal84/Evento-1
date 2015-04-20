/// <reference path="../mainApp.js" />
mainApp.factory("supplierTypeService", function ($http) {
    return {
        get: function (request, callback) {
            $http({
                url: "/api/SupplierType",
                method: "GET",
                params: request
            }).success(callback);
        }
    }
})