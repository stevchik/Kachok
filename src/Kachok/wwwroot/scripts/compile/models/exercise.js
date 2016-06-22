/// <reference path="../_all.ts" />
var KachokApp;
(function (KachokApp) {
    var Exercise = (function () {
        function Exercise(Id, Name, Description //,
            ) {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
        }
        return Exercise;
    }());
    KachokApp.Exercise = Exercise;
    var ExerciseEquipment = (function () {
        function ExerciseEquipment(Id, EquipmentName) {
            this.Id = Id;
            this.EquipmentName = EquipmentName;
        }
        return ExerciseEquipment;
    }());
    KachokApp.ExerciseEquipment = ExerciseEquipment;
    var ExerciseTag = (function () {
        function ExerciseTag(Id, TagName) {
            this.Id = Id;
            this.TagName = TagName;
        }
        return ExerciseTag;
    }());
    KachokApp.ExerciseTag = ExerciseTag;
    var ExerciseImage = (function () {
        function ExerciseImage(Id, ImageUrl, Caption, Sequence) {
            this.Id = Id;
            this.ImageUrl = ImageUrl;
            this.Caption = Caption;
            this.Sequence = Sequence;
        }
        return ExerciseImage;
    }());
    KachokApp.ExerciseImage = ExerciseImage;
})(KachokApp || (KachokApp = {}));
//# sourceMappingURL=exercise.js.map