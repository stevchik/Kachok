System.register(['@angular/router', './exercise-list.component', './exercise-detail.component'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var router_1, exercise_list_component_1, exercise_detail_component_1;
    var routes, exerciseRouterProviders;
    return {
        setters:[
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (exercise_list_component_1_1) {
                exercise_list_component_1 = exercise_list_component_1_1;
            },
            function (exercise_detail_component_1_1) {
                exercise_detail_component_1 = exercise_detail_component_1_1;
            }],
        execute: function() {
            routes = [
                { path: 'Site/Exercise', component: exercise_list_component_1.ExerciseListCompoenent },
                { path: 'Site/Exercise/:name', component: exercise_detail_component_1.ExerciseDetailCompoenent }
            ];
            exports_1("exerciseRouterProviders", exerciseRouterProviders = [
                router_1.provideRouter(routes)
            ]);
        }
    }
});
//# sourceMappingURL=exercise.routes.js.map