/// <reference path="../_all.ts" />
var KachokApp;
(function (KachokApp) {
    var ExerciseService = (function () {
        function ExerciseService($q, $http) {
            this.$q = $q;
            this.$http = $http;
            this.selectedExercise = null;
            this.muscleGroups = [];
            this.exercises = [];
            this.exercisesTmp = [
                {
                    id: 1,
                    name: "Exercise 1",
                    description: "Description 1",
                    targetMuscleGroupName: "Neck"
                },
                {
                    id: 2,
                    name: "Exercise 2",
                    description: "Description 2",
                    targetMuscleGroupName: "Neck"
                }
            ];
            var self = this;
        }
        ExerciseService.prototype.loadAllExercises2 = function () {
            return this.$q.when(this.exercises);
        };
        ExerciseService.prototype.loadAllMuscleGroups = function () {
            var _this = this;
            return this.$http.get("/api/Admin/MuscleGroups")
                .then(function (response) {
                if (response) {
                    angular.copy(response.data, _this.muscleGroups);
                }
                return _this.muscleGroups;
            });
        };
        ;
        ExerciseService.prototype.loadAllExercises = function () {
            var _this = this;
            return this.$http.get("/api/Exercises")
                .then(function (response) {
                //if (response) {
                //    angular.copy(response.data, this.exercises);
                //}
                return _this.exercisesTmp;
            });
        };
        ;
        ExerciseService.$inject = ['$q', '$http'];
        return ExerciseService;
    }());
    KachokApp.ExerciseService = ExerciseService;
})(KachokApp || (KachokApp = {}));
//# sourceMappingURL=exerciseservice.js.map