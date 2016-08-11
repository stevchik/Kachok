System.register(['../admin/admin'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var admin_1;
    var Exercise, ExerciseImage, ExerciseEquipment;
    return {
        setters:[
            function (admin_1_1) {
                admin_1 = admin_1_1;
            }],
        execute: function() {
            Exercise = (function () {
                function Exercise() {
                    this.status = admin_1.Status.Unknown;
                    this.uom = admin_1.ExerciseUom.Unknown;
                    this.experience = admin_1.Experience.Unknown;
                    this.target = admin_1.ExerciseTarget.Unknown;
                }
                ;
                return Exercise;
            }());
            exports_1("Exercise", Exercise);
            ;
            //export class ExerciceTag {
            //    constructor(
            //        public id: number,
            //        public name: string
            //    ) { };
            //}
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