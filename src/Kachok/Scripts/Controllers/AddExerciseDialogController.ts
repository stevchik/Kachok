/// <reference path="../_all.ts" />

module KachokApp {

    export class AddExerciseDialogController {
        static $inject = ['$mdDialog'];

        constructor(private $mdDialog: angular.material.IDialogService) { }

        //exercise: CreateExercise;

        avatars = [
            'svg-1', 'svg-2', 'svg-3', 'svg-4'
        ];

        cancel(): void {
            this.$mdDialog.cancel();
        }

        save(): void {
            this.$mdDialog.hide(new Exercise(1,"s","s","s",[]));
        }
    }
}