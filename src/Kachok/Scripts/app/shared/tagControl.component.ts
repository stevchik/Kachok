import { Component, Input, OnInit, HostBinding } from '@angular/core';

@Component({
    selector: 'tagControl',
    template: `
<tag
    [text]="tag"
    [index]="index"
    [selected]="selectedTag === index"
    (tagRemoved)="_removeTag($event)"
    *ngFor="let tag of tagList; let index = index">
  </tag>

<input
class="tag-control"
    type="text"
   [(ngModel)]="tag"
    
    [placeholder]="placeholder"
    
    (paste)="inputPaste($event)"
    (keydown)="inputChanged($event)"
    (blur)="inputBlurred($event)"
    (focus)="inputFocused()"
    name="tag_tag"
 id="tag_tag"
>

    `,
    styles: [`
    :host {
      display: block;
      box-shadow: 0 1px #ccc;
      padding: 5px 0;
    }

  
    .tag-control {
      box-shadow: none;
      border: 0;
    }

label {
  display: block;
}
input {
  padding: 5px;
  border: 0;
  
}

input:focus {
  border: 0;
  outline: 0;
}

  `],
})
export class TagControlComponent implements OnInit {
    @Input() ngModel: string[];
    @Input() placeholder: string = 'Add a tag';
    @Input() delimiterCode: string = '188';
    @Input() allowedTagsPattern: RegExp = /.+/;

    @Input() addOnBlur: boolean = true;
    @Input() addOnEnter: boolean = true;
    @Input() addOnPaste: boolean = true;
    @HostBinding('class.ng2-tag-input-focus') isFocussed: boolean=false;

    tag: string = '';
    tagList: Array<string> = [];
    delimiter: number;
    selectedTag: number;
   
    ngOnInit() {
        if (this.ngModel)
            this.tagList = this.ngModel;
        this.onChange(this.tagList);
        this.delimiter = parseInt(this.delimiterCode);
    }

    private _addTags(tags: string[]) {
        let validTags = tags.filter((tag) => this._isTagValid(tag));
        this.tagList = this.tagList.concat(validTags);
        this._resetSelected();
        this._resetInput();
        this.onChange(this.tagList);
    }

    private _removeTag(tagIndexToRemove: number) {
        this.tagList.splice(tagIndexToRemove, 1);
        this._resetSelected();
        this.onChange(this.tagList);
    }


    inputChanged(event: KeyboardEvent) {
        let key = event.keyCode;
        switch (key) {
            case 8: // Backspace
                this._handleBackspace();
                break;
            case 13: //Enter
                this.addOnEnter && this._addTags([this.tag]);
                event.preventDefault();
                break;

            case this.delimiter:
                this._addTags([this.tag]);
                event.preventDefault();
                break;

            default:
                this._resetSelected();
                break;
        }
    }

    inputBlurred(event: any) {
        this.addOnBlur && this._addTags([this.tag]);
        this.isFocussed = false;
    }

    inputFocused(event: any) {
        this.isFocussed = true;
    }

    inputPaste(event: any) {
        let clipboardData = event.clipboardData || (event.originalEvent && event.originalEvent.clipboardData);
        let pastedString = clipboardData.getData('text/plain');
        let tags = this._splitString(pastedString);
        let tagsToAdd = tags.filter((tag: string) => this._isTagValid(tag));
        this._addTags(tagsToAdd);
        setTimeout(() => this.tag = '', 3000);
    }

    private _handleBackspace() {
        if (!this.tag.length && this.tagList.length) {
            if (!this.isBlank(this.selectedTag)) {
                this._removeTag(this.selectedTag);
            }
            else {
                this.selectedTag = this.tagList.length - 1;
            }
        }
    }

    private _resetSelected() {
        this.selectedTag = null;
    }

    private _resetInput() {
        this.tag = '';
    }

    private _splitString(tagString: string) {
        tagString = tagString.trim();
        let tags = tagString.split(String.fromCharCode(this.delimiter));
        return tags.filter((tag) => !!tag);
    }

    private _isTagValid(tagString: string) {
        return this.allowedTagsPattern.test(tagString);
    }

    private isBlank(obj: any) {
    return obj === undefined || obj === null;
}

    onChange: (value: any) => any = () => { };
}