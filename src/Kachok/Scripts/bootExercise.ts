/// <reference path="_all.ts" />

module KachokApp {
    angular.module('kachokApp', ['ngMaterial'])
        .service('exerciseService', ExerciseService)
        .controller("exerciseController", ExerciseController);
}