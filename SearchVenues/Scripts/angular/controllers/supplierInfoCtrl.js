/// <reference path="../mainApp.js" />
mainApp.controller("supplierInfoCtrl", ["$scope", "supplierService", function ($scope, supplierService) {
    $scope.Init = function () {
        var url = document.URL;
        var id = url.substring(url.lastIndexOf('/') + 1);
        supplierService.getByID(id, function (data) {
            $scope.SupplierInfo = data.Data;
            console.log($scope.SupplierInfo);
        });
    }
    $scope.Init();
}])