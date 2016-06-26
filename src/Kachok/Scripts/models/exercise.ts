/// <reference path="../_all.ts" />

module KachokApp {

    export class Exercise {
        constructor(
            public id: number,
            public name: string,
            public description: string,
            //public Status: string,
            //public DefaultExerciseUom: string,
            public targetMuscleGroupName: string,
            //public Experience: string,
            //public ExerciseTarget: string,
            //public ExerciseEquipments: ExerciseEquipment[],
            public exerciseTags: ExerciseTag[]//,
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
            public id: number,
            public equipmentName: string) {
        }
    }

    export class ExerciseTag {
        constructor(
            public id: number,
            public tagName: string) {
        }
    }

    export class ExerciseImage {
        constructor(
            public id: number,
            public imageUrl: string,
            public caption: string,
            public sequence: number) {
        }
    }

    export class MuscleGroup {
        constructor(
            public id: number,
            public name: string) {
        }
    }
}