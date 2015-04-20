mainApp.controller('venuesCtrl', ['$timeout', '$scope', '$http', 'getCities', function ($timeout, $scope, $http, getCities) {
    $scope.SelectedTypes = new Array();
    $scope.ChangeSelection = true;
    $scope.Init = function () {
      var url = document.URL;
      var id = url.substring(url.lastIndexOf('/') + 1);
      if (id == "Venues") {
          $scope.CurrentCity = "Everywhere";
      }
      else {
          getCities.getByID(id, function (data) {
              $scope.CurrentCity = data.Data.CityName;
          })
      }
      id = id == "Venues" ? 0 : id;
      $scope.Request = new Request();
      $scope.Request.Criteria = "[{Key: 'LocationID', Value: '" + id + "'}]";
      $http({
          method: "GET",
          url: "/api/Venues",
          params: $scope.Request.get()
      }).success(function (callback) {
          $scope.Venues = callback.Data;
      });
    };

    $scope.Reset = function () {
        $scope.Init();
    }

    $scope.Change = function () {
        $scope.ChangeSelection = false;
    }

    $scope.GetCities = function () {
        getCities.get(null, function (data) {
            $scope.Cities = data.Data;
        })
    }

    $scope.GetCities();

    $scope.selectFacility = function (id, model) {
        if (model) {
            $scope.SelectedTypes.push(id);
        }
        else {
            var index = $scope.SelectedTypes.indexOf(id);
            $scope.SelectedTypes.splice(index, 1);
        }
        console.log($scope.SelectedTypes);
    }

    $scope.Inquiry = function (ID) {
        window.location.href = "/Home/VenueInfo/" + ID;
    }

    $scope.Search = function (SearchText) {
        if (SearchText != null)
        {
            window.location.href = "/Home/Venues/" + SearchText;
        }
        else {
            return false;
        }
    }

    $scope.ApplyFilter = function (filter) {
        var url = document.URL;
        var id = url.substring(url.lastIndexOf('/') + 1);
        id = id == "Venues" ? 0 : id;
        var budget = filter.Budget != null || typeof (filter.Budget) !== "undefined" ? filter.Budget : 0;
        var capacity = filter.Capacity != null || typeof (filter.Capacity) !== "undefined" ? filter.Capacity : 0;
        if (budget == 0 && capacity == 0 && $scope.SelectedTypes.length < 1) {
            $scope.Init();
        }
        else {
            $scope.Request = new Request();
            $scope.Request.Criteria = "[{Key: 'LocationID', Value: '" + id + "'}, {Key: 'Capacity', Value: '" + capacity + "'}, {Key: 'Cost', Value: '" + budget + "'}, {Key: 'VanueFacilities', Value: '" + $scope.SelectedTypes + "'}]";
            $http({
                method: "GET",
                url: "/api/Venues",
                params: $scope.Request.get()
            }).success(function (callback) {
                $scope.Venues = callback.Data;
                console.log($scope.Venues);
            });
        }
    }

  $scope.Init();

}]);
