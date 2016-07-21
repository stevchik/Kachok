System.register([], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var Exercise, ExerciseUom, ExerciceTag, ExerciseImage, ExerciseEquipment;
    return {
        setters:[],
        execute: function() {
            Exercise = (function () {
                function Exercise(id, name, description, status, uom, muscle, experience, target, exerciseEquipments, exerciseTags, exerciseImages, createdBy, createdDate, updatedBy, updatedDate) {
                    this.id = id;
                    this.name = name;
                    this.description = description;
                    this.status = status;
                    this.uom = uom;
                    this.muscle = muscle;
                    this.experience = experience;
                    this.target = target;
                    this.exerciseEquipments = exerciseEquipments;
                    this.exerciseTags = exerciseTags;
                    this.exerciseImages = exerciseImages;
                    this.createdBy = createdBy;
                    this.createdDate = createdDate;
                    this.updatedBy = updatedBy;
                    this.updatedDate = updatedDate;
                }
                return Exercise;
            }());
            exports_1("Exercise", Exercise);
            ;
            (function (ExerciseUom) {
                ExerciseUom[ExerciseUom["Unknown"] = 0] = "Unknown";
                ExerciseUom[ExerciseUom["Reps"] = 1] = "Reps";
                ExerciseUom[ExerciseUom["RepsAndWeight"] = 2] = "RepsAndWeight";
                ExerciseUom[ExerciseUom["Minutes"] = 3] = "Minutes";
            })(ExerciseUom || (ExerciseUom = {}));
            exports_1("ExerciseUom", ExerciseUom);
            ExerciceTag = (function () {
                function ExerciceTag(id, name) {
                    this.id = id;
                    this.name = name;
                }
                ;
                return ExerciceTag;
            }());
            exports_1("ExerciceTag", ExerciceTag);
            ExerciseImage = (function () {
                function ExerciseImage(id, imageUrl, caption, sequence) {
                    this.id = id;
                    this.imageUrl = imageUrl;
                    this.caption = caption;
                    this.sequence = sequence;
                }
                ;
                return ExerciseImage;
            }());
            exports_1("ExerciseImage", ExerciseImage);
            ExerciseEquipment = (function () {
                function ExerciseEquipment(id, equipmentName) {
                    this.id = id;
                    this.equipmentName = equipmentName;
                }
                return ExerciseEquipment;
            }());
            exports_1("ExerciseEquipment", ExerciseEquipment);
        }
    }
});
//# sourceMappingURL=Exercise.js.map