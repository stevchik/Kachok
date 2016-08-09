System.register(['@angular/core', '@angular/router', "./Exercise", "../admin/admin", "./exercise.service", "../admin/admin.service"], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __extends = (this && this.__extends) || function (d, b) {
        for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, router_1, Exercise_1, admin_1, exercise_service_1, admin_service_1;
    var ExerciseDetailCompoenent, ExerciseEquipment;
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
            },
            function (admin_1_1) {
                admin_1 = admin_1_1;
            },
            function (exercise_service_1_1) {
                exercise_service_1 = exercise_service_1_1;
            },
            function (admin_service_1_1) {
                admin_service_1 = admin_service_1_1;
            }],
        execute: function() {
            ExerciseDetailCompoenent = (function () {
                function ExerciseDetailCompoenent(route, router, exerciseService, adminService) {
                    this.route = route;
                    this.router = router;
                    this.exerciseService = exerciseService;
                    this.adminService = adminService;
                    this.submitted = false;
                    this.active = true;
                }
                ExerciseDetailCompoenent.prototype.ngOnInit = function () {
                    var _this = this;
                    this.sub = this.route.params.subscribe(function (params) {
                        var name = params['name'];
                    });
                    this.exercise = new Exercise_1.Exercise();
                    if (!this.statusOptions) {
                        this.statusOptions = this.adminService.statusOptions;
                    }
                    if (!this.equipmentOptions) {
                        this.adminService.getEquipment()
                            .subscribe(function (equipment) { return _this.equipmentOptions = equipment.map(function (e) { return new ExerciseEquipment(e); }); }, function (error) { return _this.errorMessage = error; });
                    }
                    if (!this.muscleOptions) {
                        this.adminService.getMuscleGroup()
                            .subscribe(function (muslceGroup) { return _this.muscleOptions = muslceGroup; }, function (error) { return _this.errorMessage = error; });
                    }
                    if (!this.uomOptions) {
                        this.uomOptions = this.adminService.uomOptions;
                    }
                    if (!this.experienceOptions) {
                        this.experienceOptions = this.adminService.experienceOptions;
                    }
                    if (!this.targetOptions) {
                        this.targetOptions = this.adminService.targetOption;
                    }
                };
                ExerciseDetailCompoenent.prototype.ngOnDestroy = function () {
                    this.sub.unsubscribe();
                };
                ExerciseDetailCompoenent.prototype.newExercise = function () {
                    var _this = this;
                    this.exercise = new Exercise_1.Exercise();
                    this.active = false;
                    setTimeout(function () { return _this.active = true; }, 0);
                };
                ;
                ExerciseDetailCompoenent.prototype.onSubmit = function () {
                    this.submitted = true;
                };
                ExerciseDetailCompoenent.prototype.gotoExercises = function () { this.router.navigate(['/Site/Exercise']); };
                ExerciseDetailCompoenent.prototype.getExercise = function () {
                    var _this = this;
                    this.exerciseService.getExercise()
                        .subscribe(function (exercise) { return _this.exercise = exercise; }, function (error) { return _this.errorMessage = error; });
                };
                ExerciseDetailCompoenent.prototype.saveExercise = function () {
                    var _this = this;
                    this.exerciseService.saveExercise(this.exercise)
                        .subscribe(function (exercise) { return _this.exercise = exercise; }, function (error) { return _this.errorMessage = error; });
                };
                ;
                ExerciseDetailCompoenent.prototype.selectEquipment = function (equipment) {
                    equipment.selected = (equipment.selected) ? false : true;
                };
                // TODO: Remove this when we're done
                ExerciseDetailCompoenent.prototype.getdiagnostic = function () { return JSON.stringify(this.exercise); };
                ExerciseDetailCompoenent = __decorate([
                    core_1.Component({
                        templateUrl: './scripts/compiled/app/exercise/exercise-detail.component.html',
                        directives: [router_1.ROUTER_DIRECTIVES]
                    }), 
                    __metadata('design:paramtypes', [router_1.ActivatedRoute, router_1.Router, exercise_service_1.ExerciseService, admin_service_1.AdminService])
                ], ExerciseDetailCompoenent);
                return ExerciseDetailCompoenent;
            }());
            exports_1("ExerciseDetailCompoenent", ExerciseDetailCompoenent);
            ExerciseEquipment = (function (_super) {
                __extends(ExerciseEquipment, _super);
                function ExerciseEquipment(equipment) {
                    _super.call(this);
                    if (equipment) {
                        this.id = equipment.id;
                        this.name = equipment.name;
                        this.selected = false;
                    }
                }
                ;
                return ExerciseEquipment;
            }(admin_1.Equipment));
        }
    }
});
//# sourceMappingURL=exercise-detail.component.js.map