import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
    selector: 'tag',
    template:
    `{{text}}
  <span
  class="tag-select"
  (click)="removeTag()">&times;</span>`,

    styles: [`
    :host {
         display: inline-block;
        background: #fff;
        padding: 7px;
        margin-right: 10px;
        border: #ccc 1px solid;
        border-radius: 4px;
        margin-bottom: 10px !important;
    }

    :host.tag-control-selected {
      color: white;
      background: #a94442;
    }

    .tag-select {
      cursor: pointer;
      display: inline-block;
      padding: 0 3px;
    }
  `],
    host: {
        '[class.tag-control-selected]': 'selected'
    }
})
export class TagComponent {
    @Input() selected: boolean;
    @Input() text: string;
    @Input() index: number;
    @Output() tagRemoved: EventEmitter<number> = new EventEmitter<number>();

    constructor() { }

    removeTag() {
        this.tagRemoved.emit(this.index);
    }
}