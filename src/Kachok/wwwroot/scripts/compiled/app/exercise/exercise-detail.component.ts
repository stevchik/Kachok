import {Component, OnInit, OnDestroy} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import { NgForm } from "@angular/common";

import { Exercise, ExerciseEquipment} from "./Exercise";
import { Equipment, MuscleGroup, Status } from "../admin/admin";
import { ExerciseService} from "./exercise.service";
import { AdminService, EnumValue } from "../admin/admin.service";

@Component({
    templateUrl: './scripts/compiled/app/exercise/exercise-detail.component.html'
})

export class ExerciseDetailCompoenent implements OnInit, OnDestroy {
    private sub: any;
    errorMessage: string;
    exercise: Exercise;

    active = true;

    statusOptions: Array<EnumValue>;
    uomOptions: Array<EnumValue>;
    experienceOptions: Array<EnumValue>;
    targetOptions: Array<EnumValue>;


    equipmentOptions: Array<ExerciseEquipment>;
    muscleOptions: Array<MuscleGroup>;

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private exerciseService: ExerciseService,
        private adminService: AdminService
    ) { }

    ngOnInit() {
        this.sub = this.route.params.subscribe(params => {
            let name = params['name'];
        });
        this.exercise = new Exercise();
        this.exercise.tags = ["one"];

        if (!this.statusOptions) {
            this.statusOptions = this.adminService.statusOptions;
        }

        if (!this.equipmentOptions) {
            this.adminService.getEquipment()
                .subscribe(
                equipment => this.equipmentOptions = equipment.map(e => new ExerciseEquipment(e)),
                error => this.errorMessage = error);
        }

        if (!this.muscleOptions) {
            this.adminService.getMuscleGroup()
                .subscribe(
                muslceGroup => this.muscleOptions = muslceGroup,
                error => this.errorMessage = error);
        }

        if (!this.uomOptions) {
            this.uomOptions = this.adminService.uomOptions;
        }

        if (!this.experienceOptions) {
            this.experienceOptions = this.adminService.experienceOptions;
        }

        if (!this.targetOptions) {
            this.targetOptions = this.adminService.targetOption;
        }

    }

    ngOnDestroy() {
        this.sub.unsubscribe();
    }

    newExercise() {
        this.exercise = new Exercise();
        this.active = false;
        this.exercise.tags = ['1', '2', '3'];
        setTimeout(() => this.active = true, 0);
    };

    onSubmit() {
        this.saveExercise();
    }

    gotoExercises() { this.router.navigate(['/Site/Exercise']); }

    getExercise() {
        this.exerciseService.getExercise()
            .subscribe(
            exercise => this.exercise = exercise,
            error => this.errorMessage = <any>error);
    }

    saveExercise() {
        this.exerciseService.saveExercise(this.exercise)
            .subscribe(
            exercise => this.exercise = exercise,
            error => this.errorMessage = <any>error);
    };

    selectEquipment(equipment: ExerciseEquipment) {
        equipment.selected = (equipment.selected) ? false : true;

        let index: number = this.exercise.equipments.findIndex(item => item === equipment);
        if (equipment.selected) {
            if (index < 0) {
                this.exercise.equipments.push(equipment);
            }
        } else {
            if (index >= 0) {
                this.exercise.equipments.splice(index);
            }
        }
    }



    // TODO: Remove this when we're done
    get diagnostic() { return JSON.stringify(this.exercise); }
}

