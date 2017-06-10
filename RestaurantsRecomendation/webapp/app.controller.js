(function () {
    angular.module('app.controllers')
        .controller('AppCtrl', AppController);

    AppController.$inject = ['$log', '$state', '$rootScope', '$scope', '$location'];

    function AppController($log, $state, $rootScope, $scope, $location) {

        vm = this;
        vm.pageTitle ='styled app';

        $scope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {
            if (angular.isDefined(toState.data.pageTitle)) {
                vm.pageTitle = toState.data.pageTitle + ' | ' + 'styled app';
               // console.log(vm.pageTitle);
            }
        });
    };
})();

