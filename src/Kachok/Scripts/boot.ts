/// <reference path="_all.ts" />

module KachokApp {
    angular.module('kachokApp', ['ngMaterial', 'ngMdIcons'])
        .controller("siteController", SiteController)
        .config(($mdIconProvider: angular.material.IIconProvider,
            $mdThemingProvider: angular.material.IThemingProvider) => {

            $mdIconProvider.icon('menu', './svg/menu.svg', 24);

            $mdThemingProvider.theme('default')
                .primaryPalette('blue')
                .accentPalette('amber');
        });
}
