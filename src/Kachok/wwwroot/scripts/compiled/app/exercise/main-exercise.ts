import {platformBrowserDynamic} from '@angular/platform-browser-dynamic';

import { ExerciseModule } from './exercise.module';


platformBrowserDynamic().bootstrapModule(ExerciseModule)
    .catch(err => console.error(err));

