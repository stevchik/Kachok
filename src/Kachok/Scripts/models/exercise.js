/// <reference path="../_all.ts" />
var ExerciseManagerApp;
(function (ExerciseManagerApp) {
    var Exercise = (function () {
        function Exercise(Id, Name, Description //,
            ) {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
        }
        return Exercise;
    }());
    ExerciseManagerApp.Exercise = Exercise;
    var ExerciseEquipment = (function () {
        function ExerciseEquipment(Id, EquipmentName) {
            this.Id = Id;
            this.EquipmentName = EquipmentName;
        }
        return ExerciseEquipment;
    }());
    ExerciseManagerApp.ExerciseEquipment = ExerciseEquipment;
    var ExerciseTag = (function () {
        function ExerciseTag(Id, TagName) {
            this.Id = Id;
            this.TagName = TagName;
        }
        return ExerciseTag;
    }());
    ExerciseManagerApp.ExerciseTag = ExerciseTag;
    var ExerciseImage = (function () {
        function ExerciseImage(Id, ImageUrl, Caption, Sequence) {
            this.Id = Id;
            this.ImageUrl = ImageUrl;
            this.Caption = Caption;
            this.Sequence = Sequence;
        }
        return ExerciseImage;
    }());
    ExerciseManagerApp.ExerciseImage = ExerciseImage;
})(ExerciseManagerApp || (ExerciseManagerApp = {}));
