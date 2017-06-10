(function () {
    angular.module('app')
        .config(['$stateProvider', '$urlRouterProvider', function appConfig($stateProvider, $urlRouterProvider) {
               $stateProvider.state('home', {
                url: '/restaurants',
                views: {
                    "main": {
                        controller: 'RestaurantsController as vm',
                        templateUrl: 'restaurants/restaurants.html'
                    }
                },
                data: {pageTitle: 'Home'}
            });
 
            $urlRouterProvider.otherwise('/restaurants');
        }])
})();

