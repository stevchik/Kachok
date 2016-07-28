System.register([], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var Equipment, MuscleGroup, Status, ExerciseUom, ExerciseTarget, Experience;
    return {
        setters:[],
        execute: function() {
            Equipment = (function () {
                function Equipment() {
                }
                return Equipment;
            }());
            exports_1("Equipment", Equipment);
            MuscleGroup = (function () {
                function MuscleGroup() {
                }
                return MuscleGroup;
            }());
            exports_1("MuscleGroup", MuscleGroup);
            (function (Status) {
                Status[Status["Unknown"] = 0] = "Unknown";
                Status[Status["Active"] = 1] = "Active";
                Status[Status["Incomplete"] = 2] = "Incomplete";
                Status[Status["AdHoc"] = 3] = "AdHoc";
            })(Status || (Status = {}));
            exports_1("Status", Status);
            (function (ExerciseUom) {
                ExerciseUom[ExerciseUom["Unknown"] = 0] = "Unknown";
                ExerciseUom[ExerciseUom["Reps"] = 1] = "Reps";
                ExerciseUom[ExerciseUom["RepsAndWeight"] = 2] = "RepsAndWeight";
                ExerciseUom[ExerciseUom["Minutes"] = 3] = "Minutes";
            })(ExerciseUom || (ExerciseUom = {}));
            exports_1("ExerciseUom", ExerciseUom);
            (function (ExerciseTarget) {
                ExerciseTarget[ExerciseTarget["Unknown"] = 0] = "Unknown";
                ExerciseTarget[ExerciseTarget["Compound"] = 1] = "Compound";
                ExerciseTarget[ExerciseTarget["Isolation"] = 2] = "Isolation";
                ExerciseTarget[ExerciseTarget["Cardio"] = 3] = "Cardio";
            })(ExerciseTarget || (ExerciseTarget = {}));
            exports_1("ExerciseTarget", ExerciseTarget);
            (function (Experience) {
                Experience[Experience["Unknown"] = 0] = "Unknown";
                Experience[Experience["Beginner"] = 1] = "Beginner";
                Experience[Experience["Intermediate"] = 2] = "Intermediate";
                Experience[Experience["Expert"] = 3] = "Expert";
            })(Experience || (Experience = {}));
            exports_1("Experience", Experience);
        }
    }
});
//# sourceMappingURL=admin.js.map