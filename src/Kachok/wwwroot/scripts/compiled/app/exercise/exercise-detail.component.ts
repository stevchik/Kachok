import {Component, OnInit, OnDestroy} from '@angular/core';
import {ROUTER_DIRECTIVES, ActivatedRoute, Router} from '@angular/router';
import { NgForm } from "@angular/common";

import { Exercise, ExerciseUom} from "./Exercise";

@Component({
    templateUrl: './scripts/compiled/app/exercise/exercise-detail.component.html',
    directives: [ROUTER_DIRECTIVES]
})

export class ExerciseDetailCompoenent implements OnInit, OnDestroy {
    private sub: any;
    exercise: Exercise;

    uomOptions: Array<string>;

    submitted = false;
    active = true;

    constructor(
        private route: ActivatedRoute,
        private router: Router
    )
    {
        let temp: Array<string> = Object.keys(ExerciseUom);
        this.uomOptions = temp.slice(temp.length/2);
    }

    ngOnInit() {
        this.sub = this.route.params.subscribe(params => {
            let name = params['name'];
        });
        this.exercise = new Exercise(-1, "", "", "", ExerciseUom[ExerciseUom.Unknown], "", "", "", null, null, null, "", new Date(), "", new Date());
    }

    ngOnDestroy() {
        this.sub.unsubscribe();
    }

    newExercise() {
        this.exercise = new Exercise(-1, "", "", "", ExerciseUom[ExerciseUom.Unknown], "", "", "", null, null, null, "", new Date(), "", new Date());
        this.active = false;
        setTimeout(() => this.active = true, 0);
    };

    onSubmit() {
        this.submitted = true;
    }

    gotoExercises() { this.router.navigate(['/Site/Exercise']); }

    // TODO: Remove this when we're done
    get diagnostic() { return JSON.stringify(this.exercise); }
}