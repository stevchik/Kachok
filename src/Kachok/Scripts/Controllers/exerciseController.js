/// <reference path="../_all.ts" />
var KachokApp;
(function (KachokApp) {
    var ExerciseController = (function () {
        function ExerciseController(exerciseService, $mdToast) {
            this.exerciseService = exerciseService;
            this.$mdToast = $mdToast;
            this.Message = "Hello from our controller";
            this.exercises = [];
            this.muscleGroups = [];
            this.selectedMuscleGroup = null;
            this.selectedExercise = null;
            this.searchText = '';
            this.filteredExercises = [];
            this.tabIndex = 0;
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
        ExerciseController.prototype.selectExercise = function (exercise) {
            this.selectedExercise = exercise;
            this.tabIndex = 0;
        };
        ExerciseController.prototype.removeTag = function (tag) {
            var foundIndex = this.selectedExercise.exerciseTags.indexOf(tag);
            this.selectedExercise.exerciseTags.splice(foundIndex, 1);
            this.openToast("Tag was removed");
        };
        ExerciseController.prototype.openToast = function (message) {
            this.$mdToast.show(this.$mdToast.simple()
                .textContent(message)
                .position('top right')
                .hideDelay(3000));
        };
        ExerciseController.$inject = ['exerciseService', '$mdToast'];
        return ExerciseController;
    }());
    KachokApp.ExerciseController = ExerciseController;
})(KachokApp || (KachokApp = {}));
//# sourceMappingURL=exercisecontroller.js.map