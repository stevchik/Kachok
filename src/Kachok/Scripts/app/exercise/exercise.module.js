System.register(['@angular/core', '@angular/platform-browser', '@angular/forms', '@angular/http', './exercise.routes', './exercise.component', './exercise-list.component', './exercise-detail.component', './exercise.service', '../admin/admin.service', '../rxjs-operators'], function(exports_1, context_1) {
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
    var core_1, platform_browser_1, forms_1, http_1, exercise_routes_1, exercise_component_1, exercise_list_component_1, exercise_detail_component_1, exercise_service_1, admin_service_1;
    var ExerciseModule;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (platform_browser_1_1) {
                platform_browser_1 = platform_browser_1_1;
            },
            function (forms_1_1) {
                forms_1 = forms_1_1;
            },
            function (http_1_1) {
                http_1 = http_1_1;
            },
            function (exercise_routes_1_1) {
                exercise_routes_1 = exercise_routes_1_1;
            },
            function (exercise_component_1_1) {
                exercise_component_1 = exercise_component_1_1;
            },
            function (exercise_list_component_1_1) {
                exercise_list_component_1 = exercise_list_component_1_1;
            },
            function (exercise_detail_component_1_1) {
                exercise_detail_component_1 = exercise_detail_component_1_1;
            },
            function (exercise_service_1_1) {
                exercise_service_1 = exercise_service_1_1;
            },
            function (admin_service_1_1) {
                admin_service_1 = admin_service_1_1;
            },
            function (_1) {}],
        execute: function() {
            ExerciseModule = (function () {
                function ExerciseModule() {
                }
                ExerciseModule = __decorate([
                    core_1.NgModule({
                        imports: [platform_browser_1.BrowserModule, forms_1.FormsModule, http_1.HttpModule, exercise_routes_1.routing],
                        declarations: [exercise_component_1.ExerciseComponent, exercise_list_component_1.ExerciseListCompoenent, exercise_detail_component_1.ExerciseDetailCompoenent],
                        providers: [exercise_routes_1.exerciseRoutingProviders, exercise_service_1.ExerciseService, admin_service_1.AdminService],
                        bootstrap: [exercise_component_1.ExerciseComponent]
                    }), 
                    __metadata('design:paramtypes', [])
                ], ExerciseModule);
                return ExerciseModule;
            }());
            exports_1("ExerciseModule", ExerciseModule);
        }
    }
});
//# sourceMappingURL=exercise.module.js.map