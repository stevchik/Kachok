"use strict";
var router_1 = require('@angular/router');
var exercise_list_component_1 = require('./exercise-list.component');
var exercise_detail_component_1 = require('./exercise-detail.component');
var routes = [
    { path: 'Site/Exercise', component: exercise_list_component_1.ExerciseListCompoenent },
    { path: 'Site/Exercise/exercise/:name', component: exercise_detail_component_1.ExerciseDetailCompoenent }
];
exports.exerciseRouterProviders = [
    router_1.provideRouter(routes)
];
//# sourceMappingURL=exercise.routes.js.map