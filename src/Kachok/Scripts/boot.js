/// <reference path="_all.ts" />
var KachokApp;
(function (KachokApp) {
    angular.module('kachokApp', ['ngMaterial']);
})(KachokApp || (KachokApp = {}));
var ExerciseManagerApp;
(function (ExerciseManagerApp) {
    angular.module('exerciseManagerApp', ['ngMaterial'])
        .service('exerciseService', ExerciseManagerApp.ExerciseService)
        .controller("exerciseController", ExerciseManagerApp.ExerciseController);
})(ExerciseManagerApp || (ExerciseManagerApp = {}));