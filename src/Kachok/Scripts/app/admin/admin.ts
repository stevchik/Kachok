export class MuscleGroup {
    id: number;
    name: string;
}

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

export class Equipment {
    id: number;
    name: string;
}
