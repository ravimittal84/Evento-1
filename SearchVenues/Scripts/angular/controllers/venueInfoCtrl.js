/// <reference path="../mainApp.js" />
mainApp.controller("venueInfoCtrl", ["$scope", "getvenueinfo", "getFacilities", "reviewsService", "venuereviewService", "$modal", "$http", function ($scope, getvenueinfo, getFacilities, reviewsService, venuereviewService, $modal, $http) {
    var url = document.URL;
    $scope.Request = new Request();
    var venueId = url.substring(url.lastIndexOf('/') + 1);
    $scope.Init = function () {
        getvenueinfo.getByID(venueId, function (data) {
            $scope.VenueInfo = data.Data;
        });
    }
    $scope.Init();
    $scope.GetFacilities = function () {
        $scope.Request.Criteria = "[{Key: 'VenueID', Value: '" + venueId + "'}]";
        getFacilities.getByRequest($scope.Request.get(), function (data) {
            $scope.Facilities = data.Data;
        })
    }

    $scope.Inquery = function () {
        var modalInstance = $modal.open({
            templateUrl: "/Home/_Inquery",
            
        })
    }

    $scope.Send = function (inq) {
        $http({
            url: "/api/Inquery",
            method: "POST",
            data: inq
        }).success(function (data) {
            console.log(data.Data);
        });
    }

    $scope.Save = function (review) {
        var url = document.URL;
        var Id = url.substring(url.lastIndexOf('/') + 1);
        review.VenueID = Id;
        venuereviewService.save(review, function (data) {
            if (data.Data == 0) {
                $scope.GetReviews();
            }
        })
    }
    $scope.GetReviews = function () {
        $scope.Request.Criteria = "[{Key: 'VenueID', Value: '" + venueId + "'}]";
        venuereviewService.get($scope.Request.get(), function (data) {
            $scope.VenueReviews = data.Data;
        })
    }
    $scope.GetFacilities();
    $scope.GetReviews();
}])