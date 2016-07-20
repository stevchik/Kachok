/// <reference path="../../../typings/globals/core-js/index.d.ts" />

import { bootstrap } from '@angular/platform-browser-dynamic';

import { ExerciseComponent } from './exercise.component';
import { exerciseRouterProviders } from './exercise.routes';

bootstrap(ExerciseComponent, [
    exerciseRouterProviders
])
    .catch(err => console.error(err));

