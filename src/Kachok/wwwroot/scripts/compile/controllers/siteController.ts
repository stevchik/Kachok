/// <reference path="../_all.ts" />

module KachokApp {
    export class SiteController {

        static $inject = ['$mdSidenav'];

        constructor(
            private $mdSidenav: angular.material.ISidenavService) {

            var self = this;
        };

        toggleSideNav(): void {
            this.$mdSidenav('left').toggle();
        }
    }
}