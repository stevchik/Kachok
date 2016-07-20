import {Component, OnInit, OnDestroy} from '@angular/core';
import {ROUTER_DIRECTIVES, ActivatedRoute, Router} from '@angular/router';

@Component({
    templateUrl: './scripts/compiled/app/exercise/exercise-detail.component.html',
    directives: [ROUTER_DIRECTIVES]
})
export class ExerciseDetailCompoenent implements OnInit, OnDestroy {
    private sub: any;
    name: string;
    constructor(
        private route: ActivatedRoute,
        private router: Router
    ) { }

    ngOnInit() {
        this.sub = this.route.params.subscribe(params => {
            name = params['name'];
        });
    }

    ngOnDestroy() {
        this.sub.unsubscribe();
    }

    gotoExercises() { this.router.navigate(['/Site/Exercise']); }
}