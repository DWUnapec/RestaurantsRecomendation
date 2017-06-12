(function () {
    'use strict';

    angular
        .module('app.controllers')
        .controller('RestaurantController', RestaurantController);

    RestaurantController.inject = ['$stateParams', 'RestaurantsService', 'leafletData', '$scope', '$timeout'];

    function RestaurantController($stateParams, RestaurantsService, leafletData, $scope, $timeout) {
        var vm = this;
        vm.id = $stateParams.id;
        vm.update = update();
        vm.restaurant = {
            address: {}
        };

        vm.defaults = {
            tileLayer: 'http://{s}.tile.opencyclemap.org/cycle/{z}/{x}/{y}.png',
            maxZoom: 18,
            path: {
                weight: 10,
                color: '#800000',
                opacity: 1
            }
        }

        vm.center = {
            lat: 18.463228,
            lng: -69.909083,
            zoom: 16
        };
        vm.markers = {
            main: {
                lat: vm.center.lat,
                lng: vm.center.lng,
                focus: true,
                draggable: false
            }
        }
        vm.customPin = L.divIcon({
            className: 'location-pin',
            html: '<img src="https://static.robinpowered.com/roadshow/robin-avatar.png"><div class="pin"></div><div class="pulse"></div>',
            iconSize: [30, 30],
            iconAnchor: [18, 30]
        });

        activate();

        ////////////////

        function activate() {
            if (vm.id >0) {
                RestaurantsService.get(vm.id).then(function (restaurant) {
                    $timeout(function () {
                        vm.restaurant = restaurant;
                        updateMarker();

                    }, 0)
                });
            }

            leafletData.getMap("detailMap").then(function (map) {
                vm.map = map;

            });
        }

        vm.add = function (restaurant) {

            console.log(restaurant);
        }

        $scope.$on('leafletDirectiveMap.detailMap.click', function (event, args) {
            console.log(args)
            vm.restaurant.address.latitude = args.leafletEvent.latlng.lat;
            vm.restaurant.address.longitude = args.leafletEvent.latlng.lng;
            updateMarker();
            console.log("clicked");
        });

        function updateMarker() {
            vm.markers.main.lat = vm.restaurant.address.latitude;
            vm.markers.main.lng = vm.restaurant.address.longitude;
        }

        function update() {
            setTimeout(function() {
                            componentHandler.upgradeAllRegistered();

            }, 500);
            console.log("mmm")
        }
    }
})();