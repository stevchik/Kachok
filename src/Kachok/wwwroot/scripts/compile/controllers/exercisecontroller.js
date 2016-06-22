/// <reference path="../_all.ts" />
var KachokApp;
(function (KachokApp) {
    var ExerciseController = (function () {
        function ExerciseController(exerciseService) {
            this.exerciseService = exerciseService;
            this.Message = "Hello from our controller";
            this.exercises = [];
            var self = this;
            this.exerciseService
                .loadAllExercises()
                .then(function (exercises) {
                self.exercises = exercises;
                console.log(self.exercises);
            });
        }
        ExerciseController.$inject = ['exerciseService'];
        return ExerciseController;
    }());
    KachokApp.ExerciseController = ExerciseController;
})(KachokApp || (KachokApp = {}));
//# sourceMappingURL=exercisecontroller.js.map