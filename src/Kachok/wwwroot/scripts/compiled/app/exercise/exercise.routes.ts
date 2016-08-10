import { Routes, RouterModule } from '@angular/router';

import { ExerciseListCompoenent } from './exercise-list.component';
import { ExerciseDetailCompoenent } from './exercise-detail.component';

const exerciseRoutes: Routes = [
    { path: 'Site/Exercise', component: ExerciseListCompoenent },
    { path: 'Site/Exercise/:name', component: ExerciseDetailCompoenent }
];

export const exerciseRoutingProviders: any[] = [];

export const routing = RouterModule.forRoot(exerciseRoutes);