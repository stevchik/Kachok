/// <reference path="_all.ts" />
var KachokApp;
(function (KachokApp) {
    angular.module('kachokApp', ['ngMaterial', 'ngMdIcons'])
        .controller("siteController", KachokApp.SiteController)
        .config(function ($mdIconProvider, $mdThemingProvider) {
        $mdIconProvider.icon('menu', './svg/menu.svg', 24);
        $mdThemingProvider.theme('default')
            .primaryPalette('blue')
            .accentPalette('amber');
    });
})(KachokApp || (KachokApp = {}));
//# sourceMappingURL=boot.js.map