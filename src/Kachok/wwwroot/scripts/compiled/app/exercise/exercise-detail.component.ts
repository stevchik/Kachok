import {Component, OnInit, OnDestroy} from '@angular/core';
import {ROUTER_DIRECTIVES, ActivatedRoute, Router} from '@angular/router';
import { NgForm } from "@angular/common";

import { Exercise} from "./Exercise";
import { ExerciseService} from "./exercise.service";


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

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private exerciseService: ExerciseService
    ){}

    ngOnInit() {
        this.sub = this.route.params.subscribe(params => {
            let name = params['name'];
        });
        this.exercise = new Exercise();
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