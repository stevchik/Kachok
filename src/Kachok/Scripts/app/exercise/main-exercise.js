/// <reference path="../../../typings/globals/core-js/index.d.ts" />
System.register(['@angular/platform-browser-dynamic', '@angular/forms', './exercise.component', './exercise.routes'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var platform_browser_dynamic_1, forms_1, exercise_component_1, exercise_routes_1;
    return {
        setters:[
            function (platform_browser_dynamic_1_1) {
                platform_browser_dynamic_1 = platform_browser_dynamic_1_1;
            },
            function (forms_1_1) {
                forms_1 = forms_1_1;
            },
            function (exercise_component_1_1) {
                exercise_component_1 = exercise_component_1_1;
            },
            function (exercise_routes_1_1) {
                exercise_routes_1 = exercise_routes_1_1;
            }],
        execute: function() {
            platform_browser_dynamic_1.bootstrap(exercise_component_1.ExerciseComponent, [
                exercise_routes_1.exerciseRouterProviders,
                forms_1.disableDeprecatedForms,
                forms_1.provideForms
            ])
                .catch(function (err) { return console.error(err); });
        }
    }
});
//# sourceMappingURL=main-exercise.js.map