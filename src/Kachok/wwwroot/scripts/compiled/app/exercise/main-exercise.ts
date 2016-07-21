/// <reference path="../../../typings/globals/core-js/index.d.ts" />

import { bootstrap } from '@angular/platform-browser-dynamic';
import { disableDeprecatedForms, provideForms } from '@angular/forms';

import { ExerciseComponent } from './exercise.component';
import { exerciseRouterProviders } from './exercise.routes';

bootstrap(ExerciseComponent, [
    exerciseRouterProviders,
    disableDeprecatedForms,
    provideForms
])
    .catch(err => console.error(err));

