/// <reference path="_all.ts" />
var ExerciseManagerApp;
(function (ExerciseManagerApp) {
    angular.module('exerciseManagerApp', ['ngMaterial'])
        .service('exerciseService', ExerciseManagerApp.ExerciseService)
        .controller("exerciseController", ExerciseManagerApp.ExerciseController);
})(ExerciseManagerApp || (ExerciseManagerApp = {}));
