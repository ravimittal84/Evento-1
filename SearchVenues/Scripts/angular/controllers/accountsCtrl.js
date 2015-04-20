mainApp
  .controller('accountsCtrl', function($scope) {
    $scope.user = {
      email: '',
      password: '',
    };

  })

  .config( function($mdThemingProvider){

    // Configure a dark theme with primary foreground yellow

    $mdThemingProvider.theme('docs-dark', 'default')
        .primaryPalette('yellow')
        .dark();

  });
