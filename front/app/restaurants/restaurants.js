(function () {
    'use strict';

    angular
        .module('app.controllers')
        .controller('RestaurantsController', RestaurantsController);

    RestaurantsController.inject = ['leafletData', '$scope'];

    function RestaurantsController(leafletData, $scope) {
        var vm = this;
        vm.defaults = {
            tileLayer: 'http://{s}.tile.opencyclemap.org/cycle/{z}/{x}/{y}.png',
            maxZoom: 14,
            path: {
                weight: 10,
                color: '#800000',
                opacity: 1
            }
        }

        vm.center = {
            lat: 18.467989,
            lng: -69.957300,
            zoom: 14
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
            leafletData.getMap().then(function (map) {
                vm.map = map;
            });
        }

        function addMarker(e) {
            // Add marker to map at click location; add popup window
            console.log(e)
            var newMarker = new L.marker(e.latlng, {
                icon: vm.customPin
            }).addTo(vm.map);
            newMarker.bindPopup("<b>New Room</b><br>Adventures await");
        }


        $scope.$on('leafletDirectiveMap.click', function (event) {
            addMarker(event);
            console.log("clicked");
        });
    }
})();