export class Exercise {

    constructor() {}

    public id: number;
    public name: string;
    public description: string;
    public status: Status = Status.Unknown;
    public uom: ExerciseUom = ExerciseUom.Unknown;;
    public muscle: string;
    public experience: Experience = Experience.Unknown;
    public target: ExerciseTarget = ExerciseTarget.Unknown;

    public exerciseEquipments: ExerciseEquipment[];
    public exerciseTags: ExerciceTag[];
    public exerciseImages: ExerciseImage[];

    public createdBy: string;
    public createdDate: Date;
    public updatedBy: string;
    public updatedDate: Date;
};

export enum Status {
    Unknown = 0,
    Active = 1,
    Incomplete = 2,
    AdHoc = 3
}

export enum ExerciseUom {
    Unknown = 0,
    Reps = 1,
    RepsAndWeight = 2,
    Minutes = 3
}

export enum ExerciseTarget {
    Unknown = 0,
    Compound = 1,
    Isolation = 2,
    Cardio = 3
}

export enum Experience {
    Unknown = 0,
    Beginner = 1,
    Intermediate = 2,
    Expert = 3
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