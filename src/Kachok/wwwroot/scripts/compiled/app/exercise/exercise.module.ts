import { NgModule} from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import {SharedModule} from '../shared/shared.module';

import {routing, exerciseRoutingProviders} from './exercise.routes';
import { ExerciseComponent} from './exercise.component';
import { ExerciseListCompoenent } from './exercise-list.component';
import { ExerciseDetailCompoenent} from './exercise-detail.component';



import { ExerciseService } from './exercise.service';
import { AdminService } from '../admin/admin.service';

// Add the RxJS Observable operators we need in this app.
import '../rxjs-operators';

@NgModule({
    imports: [BrowserModule, routing, SharedModule],
    declarations: [ExerciseComponent, ExerciseListCompoenent, ExerciseDetailCompoenent],
    providers: [exerciseRoutingProviders, ExerciseService, AdminService],
    bootstrap: [ExerciseComponent]
})

export class ExerciseModule { }