(function () {
    angular.module('app')
        .config(['$stateProvider', '$urlRouterProvider', function appConfig($stateProvider, $urlRouterProvider) {
            console.log("router")
               $stateProvider.state('restaurants', {
                url: '/restaurants',
                views: {
                    "main": {
                        controller: 'RestaurantsController as vm',
                        templateUrl: 'webapp/restaurants/restaurants.html'
                    }
                },
                data: {pageTitle: 'Home'}
            });
                $stateProvider.state('restaurant', {
                url: '/restaurant/:id',
                views: {
                    "main": {
                        controller: 'RestaurantController as vm',
                        templateUrl: 'webapp/restaurant/restaurant.html'
                    }
                },
                data: {pageTitle: 'Home'}
                });

                $urlRouterProvider.otherwise('/restaurants');

        }])


})();

