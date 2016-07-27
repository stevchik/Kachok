import {Component, OnInit} from '@angular/core';
import {ROUTER_DIRECTIVES, Router} from '@angular/router';
import { HTTP_PROVIDERS } from '@angular/http';
// Add the RxJS Observable operators we need in this app.
import '../rxjs-operators';

import { ExerciseService } from './exercise.service';

@Component({
    selector: 'kcc-exercise',
    templateUrl: './scripts/compiled/app/exercise/exercise.component.html',
    directives: [ROUTER_DIRECTIVES],
    providers: [HTTP_PROVIDERS, ExerciseService]
})
export class ExerciseComponent implements OnInit {

    constructor(private router: Router) { }

    ngOnInit() {
        //this.router.navigate(['/exercises']);
    }

}