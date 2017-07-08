(function () {
    'use strict';

    angular
        .module('app.controllers')
        .controller('RestaurantTypesController', RestaurantTypesController);

    RestaurantTypesController.inject = ['RestaurantTypesService',  '$mdDialog', '$scope'];
    function RestaurantTypesController(RestaurantTypesService, $mdDialog, $scope) {
        var vm = this;
        vm.restaurantTypes = [];
        vm.restaurantType = {};
        vm.add = add;
        vm.edit = edit;
        vm.remove = remove;
        vm.openAddModal = openAddModal;
        vm.states = ['Activo', 'Inactivo'];
        activate();

        ////////////////

        function activate() {
            RestaurantTypesService.get().then(function (restaurantTypes) {
                vm.restaurantTypes = restaurantTypes;
                console.log(restaurantTypes);
            });
        }

        function add() {
            RestaurantTypesService.add(vm.restaurantType);
        }

        function edit(account, event) {
            console.log("editing", account);
            vm.currentRestaurantType = account;
            showAdvanced();

            event.stopPropagation();
        }

        function remove(restaurantType, event) {

            var confirm = $mdDialog.confirm()
                .title('Esta seguro de eliminar la cuenta ' + restaurantType.description + '?')
                .targetEvent(event)
                .ok('Aceptar')
                .cancel('Cancelar');

            $mdDialog.show(confirm).then(function () {
                var id = restaurantType.id;
                RestaurantTypesService.remove(id).then(function () {
                    var index = vm.restaurantTypes.indexOf(restaurantType);
                    vm.restaurantTypes.splice(index, 1);
                });
            }, function () {
            });

            event.stopPropagation();

        }

        function openAddModal(size, parentSelector) {
            showAdvanced();

        }

        function showAdvanced(ev) {
            $mdDialog.show({
                controller: DialogController,
                templateUrl: 'webapp/restaurantsTypes/addrestaurantType.html',
                parent: angular.element(document.body),
                targetEvent: ev,
                clickOutsideToClose: true,
            })
                .then(function () {
                    vm.currentRestaurantType = undefined;
                }, function () {
                    vm.currentRestaurantType = undefined;
                });
        };

        function DialogController($scope) {

            $scope.restaurantType = angular.copy(vm.currentRestaurantType) || {};
            $scope.states = vm.states;
            $scope.cancel = $mdDialog.cancel;
            $scope.save = function () {
                if (vm.currentRestaurantType) {
                    RestaurantTypesService.update($scope.restaurantType).then(function (res) {
                        var index = vm.restaurantTypes.indexOf(vm.currentRestaurantType);
                        vm.restaurantTypes[index] = res;
                        $mdDialog.hide();
                    });
                } else {
                    RestaurantTypesService.add($scope.restaurantType).then(function (restaurantType) {
                        vm.restaurantTypes.push(restaurantType);
                        $mdDialog.hide();
                    });
                }
            }
        }

    }
})();