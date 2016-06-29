/// <reference path="../_all.ts" />
var KachokApp;
(function (KachokApp) {
    var ExerciseController = (function () {
        function ExerciseController(exerciseService, $mdToast, $mdDialog, $mdMedia, $mdBottomSheet) {
            this.exerciseService = exerciseService;
            this.$mdToast = $mdToast;
            this.$mdDialog = $mdDialog;
            this.$mdMedia = $mdMedia;
            this.$mdBottomSheet = $mdBottomSheet;
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
            this.exerciseService.selectedExercise = exercise;
        };
        ExerciseController.prototype.removeTag = function (tag) {
            var foundIndex = this.selectedExercise.exerciseTags.indexOf(tag);
            this.selectedExercise.exerciseTags.splice(foundIndex, 1);
            this.openToast("Tag was removed");
        };
        ExerciseController.prototype.clearTags = function ($event) {
            var confirm = this.$mdDialog.confirm()
                .title('Are you sure you want to delete all tags?')
                .textContent('All notes will be deleted, you can\'t undo this action')
                .targetEvent($event)
                .ok('Yes')
                .cancel('No');
            var self = this;
            this.$mdDialog.show(confirm).then(function () {
                self.selectedExercise.exerciseTags = [];
                self.openToast('Cleared tags');
            });
        };
        ExerciseController.prototype.addExercise = function ($event) {
            var self = this;
            var useFullScreen = (this.$mdMedia('sm') || this.$mdMedia('xs'));
            this.$mdDialog.show({
                templateUrl: './../view/newExerciseDialog.html',
                parent: angular.element(document.body),
                targetEvent: $event,
                controller: KachokApp.AddExerciseDialogController,
                controllerAs: 'ctrl',
                clickOutsideToClose: true,
                fullscreen: useFullScreen
            }).then(function (exercise) {
                //    var newUser: User = User.fromCreate(user);
                //    self.users.push(newUser);
                //    self.selectUser(newUser);
                self.openToast("Exercise added");
            }, function () {
                console.log('You cancelled the dialog.');
            });
        };
        ExerciseController.prototype.showExerciseOptions = function ($event) {
            this.$mdBottomSheet.show({
                parent: angular.element(document.getElementById('content')),
                templateUrl: './../view/exerciseSheet.html',
                controller: KachokApp.ExercisePanelController,
                controllerAs: "ep",
                bindToController: true,
                targetEvent: $event
            }).then(function (clickedItem) {
                clickedItem && console.log(clickedItem.name + ' clicked!');
            });
        };
        ExerciseController.prototype.openToast = function (message) {
            this.$mdToast.show(this.$mdToast.simple()
                .textContent(message)
                .position('top right')
                .hideDelay(3000));
        };
        ExerciseController.$inject = ['exerciseService', '$mdToast', '$mdDialog', '$mdMedia',
            '$mdBottomSheet'];
        return ExerciseController;
    }());
    KachokApp.ExerciseController = ExerciseController;
})(KachokApp || (KachokApp = {}));
//# sourceMappingURL=exercisecontroller.js.map