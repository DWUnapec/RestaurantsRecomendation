(function () {
    'use strict';

    angular
        .module('app.services')
        .factory('RestaurantTypesService', RestaurantTypesService);

    RestaurantTypesService.inject = ['$q', '$http'];

    function RestaurantTypesService($q, $http) {
        var IDENTIFIER = 'restaurantTypes';
        var END_POINT = 'api/restaurantTypes/';

        var service = {
            get: get,
            add: add,
            update: update,
            remove: remove
        };


        return service;

        ////////////////
        function get() {
            var defer = $q.defer();
            $http.get(END_POINT).then(function (res) {
                defer.resolve(res.data);
            })

            return defer.promise;
        }

        function add(item) {
            var defer = $q.defer();
            $http.post(END_POINT, item).then(function (res) {
                defer.resolve(res.data);
            })
            return defer.promise;
        }

        function update(item) {
            var defer = $q.defer();
            $http.put(END_POINT+item.id, item).then(function (res) {
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