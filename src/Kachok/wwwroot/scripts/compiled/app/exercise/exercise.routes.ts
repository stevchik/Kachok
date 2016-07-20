import { provideRouter, RouterConfig } from '@angular/router';

import { ExerciseListCompoenent } from './exercise-list.component';
import { ExerciseDetailCompoenent } from './exercise-detail.component';

const routes: RouterConfig = [
    { path: 'Site/Exercise', component: ExerciseListCompoenent },
    { path: 'Site/Exercise/exercise/:name', component: ExerciseDetailCompoenent }
];

export const exerciseRouterProviders = [
    provideRouter(routes)
];