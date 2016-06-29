/// <reference path="../_all.ts" />

module KachokApp {
    export class ExercisePanelController {
        static $inject = ['exerciseService', '$mdBottomSheet'];

        constructor(
            private exerciseService: IExerciseService,
            private $mdButtomService: angular.material.IBottomSheetService) {

            this.exercise = exerciseService.selectedExercise;
        }

        exercise: Exercise;
    }
}