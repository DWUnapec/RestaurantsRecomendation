(function() {
'use strict';

    angular
        .module('app.models')
        .factory('Restaurant', Model);

    Model.inject = [];
    function Model() {
      
        function Restaurant(data){
            this.id = data.id;
            this.name = data.name;
            this.rating = data.rating;
            this.restaurantType = data.restaurantType;
            this.foodType = data.foodType;
            this.address = data.address;
            this.minPrice = data.minPrice;
            this.maxPrice = data.maxPrice;
            this.phoneNumber = data.phoneNumber;
            this.latlng = { lat: data.address.latitude, lng: data.address.longitude };
        }
        return Restaurant;

        
    }
})();