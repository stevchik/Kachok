/// <reference path="../_all.ts" />
var KachokApp;
(function (KachokApp) {
    var AddExerciseDialogController = (function () {
        function AddExerciseDialogController($mdDialog) {
            this.$mdDialog = $mdDialog;
            //exercise: CreateExercise;
            this.avatars = [
                'svg-1', 'svg-2', 'svg-3', 'svg-4'
            ];
        }
        AddExerciseDialogController.prototype.cancel = function () {
            this.$mdDialog.cancel();
        };
        AddExerciseDialogController.prototype.save = function () {
            this.$mdDialog.hide(new KachokApp.Exercise(1, "s", "s", "s", []));
        };
        AddExerciseDialogController.$inject = ['$mdDialog'];
        return AddExerciseDialogController;
    }());
    KachokApp.AddExerciseDialogController = AddExerciseDialogController;
})(KachokApp || (KachokApp = {}));
//# sourceMappingURL=addexercisedialogcontroller.js.map