(function () {
    angular.module('app.controllers')
        .controller('AppCtrl', AppController);

    AppController.$inject = ['$log', '$state', '$rootScope', '$scope', '$location'];

    function AppController($log, $state, $rootScope, $scope, $location) {

        vm = this;
        vm.pageTitle ='Home';

        $rootScope.$on('$stateChangeStart', function (event, toState, toParams, fromState, fromParams) {
            console.log('Cambio')
            if (angular.isDefined(toState.data.pageTitle)) {
                vm.pageTitle = toState.data.pageTitle ;
                
            }
        });
    };
})();

