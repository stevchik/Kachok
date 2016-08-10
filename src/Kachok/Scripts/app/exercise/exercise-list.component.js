System.register(['@angular/core', '@angular/router', './exercise.service'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, router_1, exercise_service_1;
    var ExerciseListCompoenent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (exercise_service_1_1) {
                exercise_service_1 = exercise_service_1_1;
            }],
        execute: function() {
            ExerciseListCompoenent = (function () {
                function ExerciseListCompoenent(exerciseService, route, router) {
                    this.exerciseService = exerciseService;
                    this.route = route;
                    this.router = router;
                }
                ExerciseListCompoenent.prototype.ngOnInit = function () {
                    this.getExercises();
                };
                ExerciseListCompoenent.prototype.getExercises = function () {
                    var _this = this;
                    this.exerciseService.getExercises()
                        .subscribe(function (exercises) { return _this.showData(exercises); }, function (error) { return _this.errorMessage = error; });
                };
                ExerciseListCompoenent.prototype.showData = function (data) {
                    this.exercises = data;
                    console.debug(data.toString());
                };
                ExerciseListCompoenent = __decorate([
                    core_1.Component({
                        templateUrl: './scripts/compiled/app/exercise/exercise-list.component.html',
                        directives: [router_1.ROUTER_DIRECTIVES]
                    }), 
                    __metadata('design:paramtypes', [exercise_service_1.ExerciseService, router_1.ActivatedRoute, router_1.Router])
                ], ExerciseListCompoenent);
                return ExerciseListCompoenent;
            }());
            exports_1("ExerciseListCompoenent", ExerciseListCompoenent);
        }
    }
});
//# sourceMappingURL=exercise-list.component.js.map