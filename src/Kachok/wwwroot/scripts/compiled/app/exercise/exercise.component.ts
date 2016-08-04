import {Component, OnInit} from '@angular/core';
import {ROUTER_DIRECTIVES, Router} from '@angular/router';
import { HTTP_PROVIDERS } from '@angular/http';
// Add the RxJS Observable operators we need in this app.
import '../rxjs-operators';

import { ExerciseService } from './exercise.service';
import { AdminService } from '../admin/admin.service';

@Component({
    selector: 'kcc-exercise',
    templateUrl: './scripts/compiled/app/exercise/exercise.component.html',
    directives: [ROUTER_DIRECTIVES],
    providers: [HTTP_PROVIDERS, ExerciseService, AdminService]
})
export class ExerciseComponent implements OnInit {

    constructor(private router: Router
        , private _adminService: AdminService) { }

    ngOnInit() {
        //this.router.navigate(['/exercises']);
        this._adminService.Init();
    }

}