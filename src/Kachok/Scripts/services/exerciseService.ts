/// <reference path="../_all.ts" />


module KachokApp {
    export interface IExerciseService {
        loadAllExercises(): ng.IPromise<Exercise[]>;
        selectedExercise: Exercise;
    }

    export class ExerciseService implements IExerciseService {
        static $inject = ['$q'];

        constructor(private $q: ng.IQService) {
        }

        selectedExercise: Exercise = null;

        loadAllExercises(): ng.IPromise<Exercise[]> {
            return this.$q.when(this.exercises);
        }

        private exercises: Exercise[] = [
            {
                Id: 1,
                Name: "Exercise 1",
                Description: "Description 1"
            },
            {
                Id: 2,
                Name: "Exercise 2",
                Description: "Description 2"
            }
        ];
    }
}