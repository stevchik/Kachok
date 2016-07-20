/// <reference path="../../../typings/globals/core-js/index.d.ts" />
"use strict";
var platform_browser_dynamic_1 = require('@angular/platform-browser-dynamic');
var exercise_component_1 = require('./exercise.component');
var exercise_routes_1 = require('./exercise.routes');
platform_browser_dynamic_1.bootstrap(exercise_component_1.ExerciseComponent, [
    exercise_routes_1.exerciseRouterProviders
])
    .catch(function (err) { return console.error(err); });
//# sourceMappingURL=main-exercise.js.map