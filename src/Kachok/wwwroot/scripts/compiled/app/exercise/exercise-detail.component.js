System.register(['@angular/core', '@angular/router', "./Exercise"], function(exports_1, context_1) {
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
    var core_1, router_1, Exercise_1;
    var ExerciseDetailCompoenent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (Exercise_1_1) {
                Exercise_1 = Exercise_1_1;
            }],
        execute: function() {
            ExerciseDetailCompoenent = (function () {
                function ExerciseDetailCompoenent(route, router) {
                    this.route = route;
                    this.router = router;
                    this.submitted = false;
                    this.active = true;
                    var temp = Object.keys(Exercise_1.ExerciseUom);
                    this.uomOptions = temp.slice(temp.length / 2);
                }
                ExerciseDetailCompoenent.prototype.ngOnInit = function () {
                    this.sub = this.route.params.subscribe(function (params) {
                        var name = params['name'];
                    });
                    this.exercise = new Exercise_1.Exercise(-1, "", "", "", Exercise_1.ExerciseUom[Exercise_1.ExerciseUom.Unknown], "", "", "", null, null, null, "", new Date(), "", new Date());
                };
                ExerciseDetailCompoenent.prototype.ngOnDestroy = function () {
                    this.sub.unsubscribe();
                };
                ExerciseDetailCompoenent.prototype.newExercise = function () {
                    var _this = this;
                    this.exercise = new Exercise_1.Exercise(-1, "", "", "", Exercise_1.ExerciseUom[Exercise_1.ExerciseUom.Unknown], "", "", "", null, null, null, "", new Date(), "", new Date());
                    this.active = false;
                    setTimeout(function () { return _this.active = true; }, 0);
                };
                ;
                ExerciseDetailCompoenent.prototype.onSubmit = function () {
                    this.submitted = true;
                };
                ExerciseDetailCompoenent.prototype.gotoExercises = function () { this.router.navigate(['/Site/Exercise']); };
                Object.defineProperty(ExerciseDetailCompoenent.prototype, "diagnostic", {
                    // TODO: Remove this when we're done
                    get: function () { return JSON.stringify(this.exercise); },
                    enumerable: true,
                    configurable: true
                });
                ExerciseDetailCompoenent = __decorate([
                    core_1.Component({
                        templateUrl: './scripts/compiled/app/exercise/exercise-detail.component.html',
                        directives: [router_1.ROUTER_DIRECTIVES]
                    }), 
                    __metadata('design:paramtypes', [router_1.ActivatedRoute, router_1.Router])
                ], ExerciseDetailCompoenent);
                return ExerciseDetailCompoenent;
            }());
            exports_1("ExerciseDetailCompoenent", ExerciseDetailCompoenent);
        }
    }
});
//# sourceMappingURL=exercise-detail.component.js.map