System.register(['@angular/platform-browser-dynamic', './exercise.module'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var platform_browser_dynamic_1, exercise_module_1;
    return {
        setters:[
            function (platform_browser_dynamic_1_1) {
                platform_browser_dynamic_1 = platform_browser_dynamic_1_1;
            },
            function (exercise_module_1_1) {
                exercise_module_1 = exercise_module_1_1;
            }],
        execute: function() {
            platform_browser_dynamic_1.platformBrowserDynamic().bootstrapModule(exercise_module_1.ExerciseModule)
                .catch(function (err) { return console.error(err); });
        }
    }
});
//# sourceMappingURL=main-exercise.js.map