import {Component, OnInit} from '@angular/core';
import { AdminService } from '../admin/admin.service';

@Component({
    selector: 'kcc-exercise',
    templateUrl: './scripts/compiled/app/exercise/exercise.component.html'
})
export class ExerciseComponent implements OnInit {

    constructor(private _adminService: AdminService) { }

    ngOnInit() {
        //this.router.navigate(['/exercises']);
        this._adminService.Init();
    }

}