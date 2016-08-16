import { Status, ExerciseUom, Experience, ExerciseTarget, Equipment } from '../admin/admin';

export class Exercise {

    constructor() {
        this.id = 0;
        this.exerciseEquipments = new Array<ExerciseEquipment>();
        this.exerciseTags = new Array<string>();
        this.exerciseImages = new Array<ExerciseImage>();
    }

    public id: number;
    public name: string;
    public description: string;
    public status: Status = Status.Unknown;
    public uom: ExerciseUom = ExerciseUom.Unknown;;
    public muscle: string;
    public experience: Experience = Experience.Unknown;
    public target: ExerciseTarget = ExerciseTarget.Unknown;

    public exerciseEquipments: ExerciseEquipment[];
    public exerciseTags: string[];
    public exerciseImages: ExerciseImage[];

    public createdBy: string;
    public createdDate: Date;
    public updatedBy: string;
    public updatedDate: Date;
};


//export class ExerciceTag {
//    constructor(
//        public id: number,
//        public name: string
//    ) { };
//}

export class ExerciseImage {
    constructor(
        public id: number,
        public imageUrl: string,
        public caption: string,
        public sequence: number
    ) { };
}

export class ExerciseEquipment {
    constructor(equipment?: Equipment) {
        //super();
        if (equipment) {
            this.id = equipment.id;
            this.equipmentName = equipment.name;
            this.selected = false;
        }
    };
    id: number;
    equipmentName: string;
    selected: boolean;
}

//export class ExerciseEquipment {
//    constructor(
//        public id: number,
//        public equipmentName: string
//    ) { }
//}