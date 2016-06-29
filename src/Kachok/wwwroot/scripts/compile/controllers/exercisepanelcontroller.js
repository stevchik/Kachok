/// <reference path="../_all.ts" />
var KachokApp;
(function (KachokApp) {
    var ExercisePanelController = (function () {
        function ExercisePanelController(exerciseService, $mdButtomService) {
            this.exerciseService = exerciseService;
            this.$mdButtomService = $mdButtomService;
            this.exercise = exerciseService.selectedExercise;
        }
        ExercisePanelController.$inject = ['exerciseService', '$mdBottomSheet'];
        return ExercisePanelController;
    }());
    KachokApp.ExercisePanelController = ExercisePanelController;
})(KachokApp || (KachokApp = {}));
//# sourceMappingURL=exercisepanelcontroller.js.map