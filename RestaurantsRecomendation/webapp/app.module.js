(function () {
    angular.module('app.controllers',[]);
    angular.module('app.services',[]);
    angular.module('app.models',[]);
    angular.module('app', [
        'ui.router',
        'app.models',
        'app.services',
        'app.controllers',
        'nemLogging',
        'ui-leaflet',
        'ngMaterial',
        'mdl'
    ]);
})();

