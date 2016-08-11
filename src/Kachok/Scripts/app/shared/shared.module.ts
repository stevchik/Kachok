import { NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms';
import {HttpModule} from '@angular/http';


import { TagControlComponent} from './tagControl.component';
import { TagComponent} from './tag.component';

@NgModule({
    imports: [CommonModule, FormsModule],
    declarations: [TagControlComponent, TagComponent],
    exports: [TagControlComponent, CommonModule, FormsModule, HttpModule]
})
export class SharedModule {

}

