import { Component, Input, OnInit } from '@angular/core';

@Component({
    selector: 'tag',
    template: `
{{tagList}}
    `,
    styleUrls: ['css/tag.css']
})
export class TagCompoenent implements OnInit {
    @Input()
    ngModel: string[];

    tag: string = '';
    tagList: Array<string>;

    ngOnInit() {
        if (this.ngModel)
            this.tagList = this.ngModel;

    }

}