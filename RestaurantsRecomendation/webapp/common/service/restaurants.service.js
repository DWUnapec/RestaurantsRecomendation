(function() {
'use strict';

    angular
        .module('app.services')
        .factory('RestaurantsService', RestaurantsService);

    RestaurantsService.inject = ['Restaurant', '$q','$http'];
    function RestaurantsService(Restaurant, $q, $http) {

        var END_POINT = 'api/restaurants/'
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
            add: add,
            update: update,
            remove : remove
        };
        
        return service;

        ////////////////
        function get(id) {
            console.log(id)
            console.log('get')
            var defer = $q.defer();
            var url = id ? (END_POINT + id) : END_POINT; 
            var request = { url: url, method: 'GET'};
            $http(request).then(function (res) {
                if (id) { defer.resolve(new Restaurant(res.data)); return;}
                var restaurants = res.data.map(function (x) { return new Restaurant(x) });
                defer.resolve(restaurants);
            });

            
            return defer.promise;
        
        }

        function add(restaurant) {
            var defer = $q.defer();
            var data = angular.copy(restaurant);

            data.foodType = undefined;
            data.restaurantType = undefined;
            data.foodTypeId = restaurant.foodType.id;
            data.restaurantTypeId = restaurant.restaurantType.id;
            var request = {url:END_POINT,method: 'POST', data: data};
            $http(request).then(function (res) {
                defer.resolve(res.data);
            });
             return defer.promise;

        }


        function update(item) {
            var defer = $q.defer();
            var data = angular.copy(item);
     
            data.foodType = undefined;
            data.restaurantType = undefined;
            data.foodTypeId = item.foodType.id;
            data.restaurantTypeId = item.restaurantType.id;
            $http.put(END_POINT + data.id, data).then(function (res) {
                defer.resolve(item);
            })
            return defer.promise;
        }

        function remove(id) {
            var defer = $q.defer();
            $http.delete(END_POINT + id, ).then(function (res) {
                defer.resolve(res.data);
            })
            return defer.promise;
        }

    }
})();

 