/// <reference path="../../typings/index.d.ts" />
var ExerciseManagerApp;
(function (ExerciseManagerApp) {
    var ExerciseController = (function () {
        //static $inject = [];
        function ExerciseController() {
            this.Message = "Hello from our controller";
        }
        return ExerciseController;
    }());
    ExerciseManagerApp.ExerciseController = ExerciseController;
})(ExerciseManagerApp || (ExerciseManagerApp = {}));
