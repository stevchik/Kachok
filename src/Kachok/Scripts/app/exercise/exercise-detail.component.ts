import {Component, OnInit, OnDestroy} from '@angular/core';
import {ROUTER_DIRECTIVES, ActivatedRoute, Router} from '@angular/router';
import { NgForm } from "@angular/common";

import { Exercise} from "./Exercise";
import { Equipment, MuscleGroup, Status } from "../admin/admin";
import { ExerciseService} from "./exercise.service";
import { AdminService, EnumValue } from "../admin/admin.service";

@Component({
    templateUrl: './scripts/compiled/app/exercise/exercise-detail.component.html',
    directives: [ROUTER_DIRECTIVES]
})

export class ExerciseDetailCompoenent implements OnInit, OnDestroy {
    private sub: any;
    errorMessage: string;
    exercise: Exercise;

    submitted = false;
    active = true;

    statusOptions: Array<EnumValue>;
    uomOptions: Array<EnumValue>;
    experienceOptions: Array<EnumValue>;
    targetOptions: Array<EnumValue>;


    equipmentOptions: Array<Equipment>;
    muscleOptions: Array<MuscleGroup>;

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private exerciseService: ExerciseService,
        private adminService: AdminService
    ) {}

    ngOnInit() {
        this.sub = this.route.params.subscribe(params => {
            let name = params['name'];
        });
        this.exercise = new Exercise();

        if (!this.statusOptions) {
            this.statusOptions = this.adminService.statusOptions;
        }

        if (!this.equipmentOptions) {
            this.equipmentOptions = this.adminService.equipment;
        }

        if (!this.muscleOptions) {
            this.muscleOptions = this.adminService.muscleGroup;
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
        setTimeout(() => this.active = true, 0);
    };

    onSubmit() {
        this.submitted = true;
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





    // TODO: Remove this when we're done
    getdiagnostic() { return JSON.stringify(this.exercise); }
}