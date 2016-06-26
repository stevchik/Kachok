/// <reference path="_all.ts" />
var KachokApp;
(function (KachokApp) {
    angular.module('kachokApp')
        .service('exerciseService', KachokApp.ExerciseService)
        .controller("exerciseController", KachokApp.ExerciseController);
})(KachokApp || (KachokApp = {}));
//# sourceMappingURL=bootexercise.js.map