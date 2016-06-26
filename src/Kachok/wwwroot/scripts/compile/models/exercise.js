/// <reference path="../_all.ts" />
var KachokApp;
(function (KachokApp) {
    var Exercise = (function () {
        function Exercise(id, name, description, 
            //public Status: string,
            //public DefaultExerciseUom: string,
            targetMuscleGroupName, 
            //public Experience: string,
            //public ExerciseTarget: string,
            //public ExerciseEquipments: ExerciseEquipment[],
            exerciseTags //,
            ) {
            this.id = id;
            this.name = name;
            this.description = description;
            this.targetMuscleGroupName = targetMuscleGroupName;
            this.exerciseTags = exerciseTags;
        }
        return Exercise;
    }());
    KachokApp.Exercise = Exercise;
    var ExerciseEquipment = (function () {
        function ExerciseEquipment(id, equipmentName) {
            this.id = id;
            this.equipmentName = equipmentName;
        }
        return ExerciseEquipment;
    }());
    KachokApp.ExerciseEquipment = ExerciseEquipment;
    var ExerciseTag = (function () {
        function ExerciseTag(id, tagName) {
            this.id = id;
            this.tagName = tagName;
        }
        return ExerciseTag;
    }());
    KachokApp.ExerciseTag = ExerciseTag;
    var ExerciseImage = (function () {
        function ExerciseImage(id, imageUrl, caption, sequence) {
            this.id = id;
            this.imageUrl = imageUrl;
            this.caption = caption;
            this.sequence = sequence;
        }
        return ExerciseImage;
    }());
    KachokApp.ExerciseImage = ExerciseImage;
    var MuscleGroup = (function () {
        function MuscleGroup(id, name) {
            this.id = id;
            this.name = name;
        }
        return MuscleGroup;
    }());
    KachokApp.MuscleGroup = MuscleGroup;
})(KachokApp || (KachokApp = {}));
//# sourceMappingURL=exercise.js.map