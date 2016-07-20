export interface IExercise {
    id: number;
    name: string;
    description: string;
    status: string;
    uom: string;
    muscle: string;
    experience: string;
    target: string;

    exerciseEquipments: IExerciseEquipment[];
    exerciseTags: IExerciceTag[];
    exerciseImages: IExerciseImage[];

    createdBy: string;
    createdDate: Date;
    updatedBy: string;
    updatedDate: Date;
};

export interface IExerciceTag {
    id: number;
    name: string;
}

export interface IExerciseImage {
    id: number;
    imageUrl: string;
    caption: string;
    sequence: number;
}

export interface IExerciseEquipment {
    id: number;
    equipmentName: string;
}