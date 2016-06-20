/// <reference path="../typings/index.d.ts" />
/// <reference path="controllers/exercisecontroller.ts" />
var ExerciseManagerApp;
(function (ExerciseManagerApp) {
    angular.module('exerciseManagerApp', ['ngMaterial'])
        .controller("exerciseController", ExerciseManagerApp.ExerciseController);
})(ExerciseManagerApp || (ExerciseManagerApp = {}));
