(function () {
    'use strict';

    angular
        .module('app.controllers')
        .controller('RestaurantsController', RestaurantsController);

    RestaurantsController.inject = ['leafletData', '$scope', 'RestaurantsService', '$timeout'];

    function RestaurantsController(leafletData, $scope, RestaurantsService) {
        var vm = this;
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
        vm.customPin = L.divIcon({
            className: 'location-pin',
            html: '<img src="https://static.robinpowered.com/roadshow/robin-avatar.png"><div class="pin"></div><div class="pulse"></div>',
            iconSize: [30, 30],
            iconAnchor: [18, 30]
        });

        activate();

        ////////////////

        function activate() {
            console.log(componentHandler)
            leafletData.getMap().then(function (map) {
                vm.map = map;
                RestaurantsService.get().then(function (restaurants) {
                    restaurants.forEach(function(restaurant) {
                        addMarker(restaurant);
                    }, this);
            });
            });
        }

        function addMarker(restaurant) {
            // Add marker to map at click location; add popup window
            var newMarker = new L.marker(restaurant.latlng, {
                icon: vm.customPin
            }).addTo(vm.map);

            var popUpTemplate = "<b>"+restaurant.name + "</b><br>Rating :" + restaurant.rating +"<br><a href = '#!/restaurant/" +restaurant.id+"'>Detalles</a>";
            newMarker.bindPopup(popUpTemplate);
        }


        $scope.$on('leafletDirectiveMap.click', function (event, args) {
            addMarker(args.leafletEvent.latlng);
            console.log("clicked");
        });
    }
})();