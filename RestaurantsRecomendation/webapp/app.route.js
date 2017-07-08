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
                data: {pageTitle: 'Restaurantes'}
            });
                $stateProvider.state('restaurant', {
                url: '/restaurant/:id',
                views: {
                    "main": {
                        controller: 'RestaurantController as vm',
                        templateUrl: 'webapp/restaurant/restaurant.html'
                    }
                },
                data: {pageTitle: 'Restaurante'}
                });
                $stateProvider.state('restauranttypes', {
                    url: '/restauranttypes',
                    views: {
                        "main": {
                            controller: 'RestaurantTypesController as vm',
                            templateUrl: 'webapp/restaurantstypes/restauranttypes.html'
                        }
                    },
                    data: { pageTitle: 'Tipo de Restaurantes' }
                });

                $stateProvider.state('foodtypes', {
                    url: '/foodtypes',
                    views: {
                        "main": {
                            controller: 'FoodTypesController as vm',
                            templateUrl: 'webapp/foodtypes/foodtypes.html'
                        }
                    },
                    data: { pageTitle: 'Tipos de Comida' }
                });
                $urlRouterProvider.otherwise('/restaurants');

        }])


})();

