/// <reference path="../_all.ts" />


module KachokApp {
    export class ExerciseController {

        static $inject = ['exerciseService', '$mdToast'];

        constructor(private exerciseService: IExerciseService,
            private $mdToast: angular.material.IToastService) {
            var self = this;

            this.exerciseService
                .loadAllMuscleGroups()
                .then((muscleGroups: MuscleGroup[]) => {
                    self.muscleGroups = muscleGroups;
                    self.selectedMuscleGroup = muscleGroups[0];
                    console.log(self.muscleGroups);
                })
                .catch((reason: string) => {
                    console.log(reason);
                })
                .finally(() => {
                    console.log('we are done');
                });


            this.exerciseService
                .loadAllExercises()
                .then((exercises: Exercise[]) => {
                    self.exercises = exercises;
                });
        }

        selectMuscleGroup(muscleGroup: MuscleGroup): void {
            this.selectedMuscleGroup = muscleGroup;

            if (this.filteredExercises && this.filteredExercises.length > 0) {
                this.filteredExercises.length = 0;
            }

            angular.forEach(this.exercises, function (exercise) {

                if (angular.lowercase(exercise.targetMuscleGroupName).indexOf(angular.lowercase(muscleGroup.name)) != -1) {
                    this.filteredExercises.push(exercise);
                }

            }, this);
        }

        selectExercise(exercise: Exercise): void {
            this.selectedExercise = exercise;
            this.tabIndex = 0;
        }

        removeTag(tag: ExerciseTag): void {
            var foundIndex = this.selectedExercise.exerciseTags.indexOf(tag);
            this.selectedExercise.exerciseTags.splice(foundIndex, 1);
            this.openToast("Tag was removed");
        }

        openToast(message: string): void {
            this.$mdToast.show(
                this.$mdToast.simple()
                    .textContent(message)
                    .position('top right')
                    .hideDelay(3000)
            );
        }

        Message: string = "Hello from our controller";
        exercises: Exercise[] = [];
        muscleGroups: MuscleGroup[] = [];
        selectedMuscleGroup: MuscleGroup = null;
        selectedExercise: Exercise = null;
        searchText: string = '';
        filteredExercises: Exercise[] = [];
        tabIndex: number = 0;
    }
}