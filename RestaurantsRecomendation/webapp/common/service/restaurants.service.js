(function() {
'use strict';

    angular
        .module('app.services')
        .factory('RestaurantsService', RestaurantsService);

    RestaurantsService.inject = ['Restaurant', '$q','$http'];
    function RestaurantsService(Restaurant, $q, $http) {

        var END_POINT = 'api/restaurants'
        var restaurantTypes = [{id:1, name:"FastFood"},{id:2,name:"Chinese"}];
        var foodTypes = [{id:1,name:"Fried"},{id:2,name:"Burger"},{id:3,name:"Pizza"},{id:3,name:"Traditional"}];
        var addresses= [
            {latitude: 18.464407,longitude: -69.910299, city:"Santo Domingo",street:"Mexico", country:"RD"},
            {latitude: 18.462808,longitude:-69.908812, city:"Santo Domingo",street:"Mexico", country:"RD"},
            {latitude: 18.465876,longitude: -69.910114, city:"Santo Domingo",street:"Mexico", country:"RD"},
            {latitude: 18.462960,longitude: -69.908762, city:"Santo Domingo",street:"Mexico", country:"RD"},
            {latitude: 18.465112,longitude: -69.912363, city:"Santo Domingo",street:"Mexico", country:"RD"},
            {latitude: 18.464948,longitude: -69.908526, city:"Santo Domingo",street:"Mexico", country:"RD"}
        ]
 
        var service = {
            get: get,
            add : add
        };
        
        return service;

        ////////////////
        function get() {
            console.log('get')
            var defer = $q.defer();
            var request = { url: END_POINT, method: 'GET'};
            $http(request).then(function (res) {
                var restaurants = res.data.map(function (x) { return new Restaurant(x) });

                defer.resolve(restaurants);
            });

            
            return defer.promise;
        
        }

        function add(restaurant) {
            var defer = $q.defer();
            var request = {url:END_POINT,method: 'POST', data: restaurant};
            $http(request).then(function (res) {
                defer.resolve(res.data);
            });
             return defer.promise;

        }
    }
})();

 