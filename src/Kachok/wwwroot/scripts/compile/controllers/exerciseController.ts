/// <reference path="../_all.ts" />


module KachokApp {
    export class ExerciseController {

        static $inject = ['exerciseService'];

        constructor(private exerciseService: IExerciseService) {
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

        Message: string = "Hello from our controller";
        exercises: Exercise[] = [];
        muscleGroups: MuscleGroup[] = [];
        selectedMuscleGroup: MuscleGroup = null;
        selectedExercise: Exercise = null;
        searchText: string = '';
        filteredExercises: Exercise[] = [];
    }
}