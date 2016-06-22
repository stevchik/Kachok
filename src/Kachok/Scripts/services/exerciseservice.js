/// <reference path="../_all.ts" />
var ExerciseManagerApp;
(function (ExerciseManagerApp) {
    var ExerciseService = (function () {
        function ExerciseService($q) {
            this.$q = $q;
            this.selectedExercise = null;
            this.exercises = [
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
        ExerciseService.prototype.loadAllExercises = function () {
            return this.$q.when(this.exercises);
        };
        ExerciseService.$inject = ['$q'];
        return ExerciseService;
    }());
    ExerciseManagerApp.ExerciseService = ExerciseService;
})(ExerciseManagerApp || (ExerciseManagerApp = {}));
