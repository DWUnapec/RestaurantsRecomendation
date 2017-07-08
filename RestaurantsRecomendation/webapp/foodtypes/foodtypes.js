(function () {
    'use strict';

    angular
        .module('app.controllers')
        .controller('FoodTypesController', FoodTypesController);

    FoodTypesController.inject = ['FoodTypesService', '$mdDialog', '$scope'];
    function FoodTypesController(FoodTypesService, $mdDialog, $scope) {
        var vm = this;
        vm.foodTypes = [];
        vm.foodType = {};
        vm.add = add;
        vm.edit = edit;
        vm.remove = remove;
        vm.openAddModal = openAddModal;
        vm.states = ['Activo', 'Inactivo'];
        activate();

        ////////////////

        function activate() {
            FoodTypesService.get().then(function (foodTypes) {
                vm.foodTypes = foodTypes;
                console.log(foodTypes);
            });
        }

        function add() {
            FoodTypesService.add(vm.foodType);
        }

        function edit(account, event) {
            console.log("editing", account);
            vm.currentFoodType = account;
            showAdvanced();

            event.stopPropagation();
        }

        function remove(foodType, event) {

            var confirm = $mdDialog.confirm()
                .title('Esta seguro de eliminar la cuenta ' + foodType.description + '?')
                .targetEvent(event)
                .ok('Aceptar')
                .cancel('Cancelar');

            $mdDialog.show(confirm).then(function () {
                var id = foodType.id;
                FoodTypesService.remove(id).then(function () {
                    var index = vm.foodTypes.indexOf(foodType);
                    vm.foodTypes.splice(index, 1);
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
                templateUrl: 'webapp/foodTypes/addfoodType.html',
                parent: angular.element(document.body),
                targetEvent: ev,
                clickOutsideToClose: true,
            })
                .then(function () {
                    vm.currentFoodType = undefined;
                }, function () {
                    vm.currentFoodType = undefined;
                });
        };

        function DialogController($scope) {

            $scope.foodType = angular.copy(vm.currentFoodType) || {};
            $scope.states = vm.states;
            $scope.cancel = $mdDialog.cancel;
            $scope.save = function () {
                if (vm.currentFoodType) {
                    FoodTypesService.update($scope.foodType).then(function (res) {
                        var index = vm.foodTypes.indexOf(vm.currentFoodType);
                        vm.foodTypes[index] = res;
                        $mdDialog.hide();
                    });
                } else {
                    FoodTypesService.add($scope.foodType).then(function (foodType) {
                        vm.foodTypes.push(foodType);
                        $mdDialog.hide();
                    });
                }
            }
        }

    }
})();