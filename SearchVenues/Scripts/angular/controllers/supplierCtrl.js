/// <reference path="../mainApp.js" />
mainApp.controller("supplierCtrl", ["$scope", "supplierService", "supplierTypeService", function ($scope, supplierService, supplierTypeService) {

    $scope.Init = function () {
        var url = document.URL;
        var id = url.substring(url.lastIndexOf('/') + 1);
        id = id == "Suppliers" ? 0 : id;
        $scope.Request = new Request();
        $scope.Request.Criteria = "[{Key: 'LocationID', Value: '" + id + "'}]";
        supplierService.get($scope.Request.get(), function (data) {
            $scope.Suppliers = data.Data;
        })
    }

    $scope.LoadSupplierTypes = function () {
        supplierTypeService.get(null, function (data) {
            $scope.SupplierTypes = data.Data;
            var defaultValue = {
                SupplierTypeID: 0,
                SupplierTypeName: "Select"
            }
            $scope.SupplierTypes.unshift(defaultValue);
            $scope.SupplierType = defaultValue.SupplierTypeID;
        })
    }

    $scope.LoadSupplierTypes();

    $scope.Search = function (SearchText) {
        if (SearchText != null) {
            window.location.href = "/Home/Suppliers/" + SearchText.originalObject.value;
        }
        else {
            return false;
        }
    }

    $scope.ApplyFilter = function (filter) {
        var url = document.URL;
        var id = url.substring(url.lastIndexOf('/') + 1);
        id = id == "Suppliers" ? 0 : id;
        if (filter != 0) {
            $scope.Request.Criteria = "[{Key: 'LocationID', Value: '" + id + "'}, {Key: 'SupplierTypeID', Value: '" + filter + "'}]";
            supplierService.get($scope.Request.get(), function (data) {
                $scope.Suppliers = data.Data;
            })
        }
    }

    $scope.Init();
}])