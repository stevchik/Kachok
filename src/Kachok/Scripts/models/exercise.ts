/// <reference path="../_all.ts" />

module KachokApp {

    export class Exercise {
        constructor(
            public Id: number,
            public Name: string,
            public Description: string//,
            //public Status: string,
            //public DefaultExerciseUom: string,
            //public TargetMuscleGroupName: string,
            //public Experience: string,
            //public ExerciseTarget: string,
            //public ExerciseEquipments: ExerciseEquipment[],
            //public ExerciseTags: ExerciseTag[],
            //public ExerciseImages: ExerciseImage[],
            //public CreatedBy: string,
            //public CreatedDate: Date,
            //public UpdatedBy: string,
            //public UpdatedDate: Date
        ) {
        }
    }

    export class ExerciseEquipment {
        constructor(
            public Id: number,
            public EquipmentName: string) {
        }
    }

    export class ExerciseTag {
        constructor(
            public Id: number,
            public TagName: string) {
        }
    }

    export class ExerciseImage {
        constructor(
            public Id: number,
            public ImageUrl: string,
            public Caption: string,
            public Sequence: number) {
        }
    }
}