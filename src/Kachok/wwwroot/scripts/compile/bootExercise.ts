/// <reference path="_all.ts" />

module KachokApp {
    angular.module('kachokApp')
        .service('exerciseService', ExerciseService)
        .controller("exerciseController", ExerciseController);
}