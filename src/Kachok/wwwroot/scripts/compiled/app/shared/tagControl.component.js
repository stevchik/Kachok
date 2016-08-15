System.register(['@angular/core'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1;
    var TagControlComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            }],
        execute: function() {
            TagControlComponent = (function () {
                function TagControlComponent() {
                    this.placeholder = 'Add a tag';
                    this.delimiterCode = '188';
                    this.allowedTagsPattern = /.+/;
                    this.addOnBlur = true;
                    this.addOnEnter = true;
                    this.addOnPaste = true;
                    this.isFocussed = false;
                    this.tag = '';
                    this.tagList = [];
                    this.onChange = function () { };
                }
                TagControlComponent.prototype.ngOnInit = function () {
                    if (this.ngModel)
                        this.tagList = this.ngModel;
                    this.onChange(this.tagList);
                    this.delimiter = parseInt(this.delimiterCode);
                };
                TagControlComponent.prototype._addTags = function (tags) {
                    var _this = this;
                    var validTags = tags.filter(function (tag) { return _this._isTagValid(tag); });
                    this.tagList = this.tagList.concat(validTags);
                    this._resetSelected();
                    this._resetInput();
                    this.onChange(this.tagList);
                };
                TagControlComponent.prototype._removeTag = function (tagIndexToRemove) {
                    this.tagList.splice(tagIndexToRemove, 1);
                    this._resetSelected();
                    this.onChange(this.tagList);
                };
                TagControlComponent.prototype.inputChanged = function (event) {
                    var key = event.keyCode;
                    switch (key) {
                        case 8:
                            this._handleBackspace();
                            break;
                        case 13:
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
                };
                TagControlComponent.prototype.inputBlurred = function (event) {
                    this.addOnBlur && this._addTags([this.tag]);
                    this.isFocussed = false;
                };
                TagControlComponent.prototype.inputFocused = function (event) {
                    this.isFocussed = true;
                };
                TagControlComponent.prototype.inputPaste = function (event) {
                    var _this = this;
                    var clipboardData = event.clipboardData || (event.originalEvent && event.originalEvent.clipboardData);
                    var pastedString = clipboardData.getData('text/plain');
                    var tags = this._splitString(pastedString);
                    var tagsToAdd = tags.filter(function (tag) { return _this._isTagValid(tag); });
                    this._addTags(tagsToAdd);
                    setTimeout(function () { return _this.tag = ''; }, 3000);
                };
                TagControlComponent.prototype._handleBackspace = function () {
                    if (!this.tag.length && this.tagList.length) {
                        if (!this.isBlank(this.selectedTag)) {
                            this._removeTag(this.selectedTag);
                        }
                        else {
                            this.selectedTag = this.tagList.length - 1;
                        }
                    }
                };
                TagControlComponent.prototype._resetSelected = function () {
                    this.selectedTag = null;
                };
                TagControlComponent.prototype._resetInput = function () {
                    this.tag = '';
                };
                TagControlComponent.prototype._splitString = function (tagString) {
                    tagString = tagString.trim();
                    var tags = tagString.split(String.fromCharCode(this.delimiter));
                    return tags.filter(function (tag) { return !!tag; });
                };
                TagControlComponent.prototype._isTagValid = function (tagString) {
                    return this.allowedTagsPattern.test(tagString);
                };
                TagControlComponent.prototype.isBlank = function (obj) {
                    return obj === undefined || obj === null;
                };
                __decorate([
                    core_1.Input(), 
                    __metadata('design:type', Array)
                ], TagControlComponent.prototype, "ngModel", void 0);
                __decorate([
                    core_1.Input(), 
                    __metadata('design:type', String)
                ], TagControlComponent.prototype, "placeholder", void 0);
                __decorate([
                    core_1.Input(), 
                    __metadata('design:type', String)
                ], TagControlComponent.prototype, "delimiterCode", void 0);
                __decorate([
                    core_1.Input(), 
                    __metadata('design:type', RegExp)
                ], TagControlComponent.prototype, "allowedTagsPattern", void 0);
                __decorate([
                    core_1.Input(), 
                    __metadata('design:type', Boolean)
                ], TagControlComponent.prototype, "addOnBlur", void 0);
                __decorate([
                    core_1.Input(), 
                    __metadata('design:type', Boolean)
                ], TagControlComponent.prototype, "addOnEnter", void 0);
                __decorate([
                    core_1.Input(), 
                    __metadata('design:type', Boolean)
                ], TagControlComponent.prototype, "addOnPaste", void 0);
                __decorate([
                    core_1.HostBinding('class.ng2-tag-input-focus'), 
                    __metadata('design:type', Boolean)
                ], TagControlComponent.prototype, "isFocussed", void 0);
                TagControlComponent = __decorate([
                    core_1.Component({
                        selector: 'tagControl',
                        template: "\n<tag\n    [text]=\"tag\"\n    [index]=\"index\"\n    [selected]=\"selectedTag === index\"\n    (tagRemoved)=\"_removeTag($event)\"\n    *ngFor=\"let tag of tagList; let index = index\">\n  </tag>\n\n<input\nclass=\"tag-control\"\n    type=\"text\"\n   [(ngModel)]=\"tag\"\n    \n    [placeholder]=\"placeholder\"\n    \n    (paste)=\"inputPaste($event)\"\n    (keydown)=\"inputChanged($event)\"\n    (blur)=\"inputBlurred($event)\"\n    (focus)=\"inputFocused()\"\n    name=\"tag_tag\"\n id=\"tag_tag\"\n>\n\n    ",
                        styles: ["\n    :host {\n      display: block;\n      box-shadow: 0 1px #ccc;\n      padding: 5px 0;\n    }\n\n  \n    .tag-control {\n      box-shadow: none;\n      border: 0;\n    }\n\nlabel {\n  display: block;\n}\ninput {\n  padding: 5px;\n  border: 0;\n  \n}\n\ninput:focus {\n  border: 0;\n  outline: 0;\n}\n\n  "],
                    }), 
                    __metadata('design:paramtypes', [])
                ], TagControlComponent);
                return TagControlComponent;
            }());
            exports_1("TagControlComponent", TagControlComponent);
        }
    }
});
//# sourceMappingURL=tagControl.component.js.map