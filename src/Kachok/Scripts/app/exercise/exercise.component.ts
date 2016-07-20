import {Component, OnInit} from '@angular/core';
import {ROUTER_DIRECTIVES, Router} from '@angular/router';



@Component({
    selector: 'kcc-exercise',
    templateUrl: './scripts/compiled/app/exercise/exercise.component.html',
    directives: [ROUTER_DIRECTIVES]
})
export class ExerciseComponent implements OnInit {

    constructor(private router: Router) { }

    ngOnInit() {
        //this.router.navigate(['/exercises']);
    }

}