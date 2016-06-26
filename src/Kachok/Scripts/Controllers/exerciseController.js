/// <reference path="../_all.ts" />
var KachokApp;
(function (KachokApp) {
    var ExerciseController = (function () {
        function ExerciseController(exerciseService) {
            this.exerciseService = exerciseService;
            this.Message = "Hello from our controller";
            this.exercises = [];
            this.muscleGroups = [];
            this.selectedMuscleGroup = null;
            this.selectedExercise = null;
            this.searchText = '';
            this.filteredExercises = [];
            var self = this;
            this.exerciseService
                .loadAllMuscleGroups()
                .then(function (muscleGroups) {
                self.muscleGroups = muscleGroups;
                self.selectedMuscleGroup = muscleGroups[0];
                console.log(self.muscleGroups);
            })
                .catch(function (reason) {
                console.log(reason);
            })
                .finally(function () {
                console.log('we are done');
            });
            this.exerciseService
                .loadAllExercises()
                .then(function (exercises) {
                self.exercises = exercises;
            });
        }
        ExerciseController.prototype.selectMuscleGroup = function (muscleGroup) {
            this.selectedMuscleGroup = muscleGroup;
            if (this.filteredExercises && this.filteredExercises.length > 0) {
                this.filteredExercises.length = 0;
            }
            angular.forEach(this.exercises, function (exercise) {
                if (angular.lowercase(exercise.targetMuscleGroupName).indexOf(angular.lowercase(muscleGroup.name)) != -1) {
                    this.filteredExercises.push(exercise);
                }
            }, this);
        };
        ExerciseController.$inject = ['exerciseService'];
        return ExerciseController;
    }());
    KachokApp.ExerciseController = ExerciseController;
})(KachokApp || (KachokApp = {}));
//# sourceMappingURL=exercisecontroller.js.map