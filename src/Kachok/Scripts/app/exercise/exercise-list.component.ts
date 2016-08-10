import {Component, OnInit, OnDestroy} from '@angular/core';
import { Router, ActivatedRoute, ROUTER_DIRECTIVES } from '@angular/router';
import { Exercise } from './Exercise';
import {ExerciseService  } from './exercise.service';

@Component({
    templateUrl: './scripts/compiled/app/exercise/exercise-list.component.html',
    directives: [ROUTER_DIRECTIVES]
})
export class ExerciseListCompoenent implements OnInit {

    errorMessage: string;
    exercises: Exercise[];

    constructor(private exerciseService: ExerciseService,
        private route: ActivatedRoute,
        private router: Router) {
    }

    ngOnInit() {
        this.getExercises();
    }

    getExercises() {
        this.exerciseService.getExercises()
            .subscribe(
            exercises => this.showData(exercises),
            error => this.errorMessage = error);
    }

    showData(data: Exercise[]) {
        this.exercises = data;
        console.debug(data.toString());
    }
}