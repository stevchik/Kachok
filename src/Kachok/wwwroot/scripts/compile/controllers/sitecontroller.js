/// <reference path="../_all.ts" />
var KachokApp;
(function (KachokApp) {
    var SiteController = (function () {
        function SiteController($mdSidenav) {
            this.$mdSidenav = $mdSidenav;
            var self = this;
        }
        ;
        SiteController.prototype.toggleSideNav = function () {
            this.$mdSidenav('left').toggle();
        };
        SiteController.$inject = ['$mdSidenav'];
        return SiteController;
    }());
    KachokApp.SiteController = SiteController;
})(KachokApp || (KachokApp = {}));
//# sourceMappingURL=sitecontroller.js.map