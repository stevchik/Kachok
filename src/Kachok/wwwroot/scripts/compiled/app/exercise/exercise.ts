export class Exercise {

    constructor(
        public id: number,
        public name: string,
        public description: string,
        public status: string,
        public uom: string,
        public muscle: string,
        public experience: string,
        public target: string,

        public exerciseEquipments: ExerciseEquipment[],
        public exerciseTags: ExerciceTag[],
        public exerciseImages: ExerciseImage[],

        public createdBy: string,
        public createdDate: Date,
        public updatedBy: string,
        public updatedDate: Date
    ) { }
};

export enum ExerciseUom {
    Unknown = 0,
    Reps = 1,
    RepsAndWeight = 2,
    Minutes = 3
}

export class ExerciceTag {
    constructor(
        public id: number,
        public name: string
    ) { };
}

export class ExerciseImage {
    constructor(
        public id: number,
        public imageUrl: string,
        public caption: string,
        public sequence: number
    ) { };
}

export class ExerciseEquipment {
    constructor(
        public id: number,
        public equipmentName: string
    ) { }
}