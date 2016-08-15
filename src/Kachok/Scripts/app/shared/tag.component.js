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
    var TagComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            }],
        execute: function() {
            TagComponent = (function () {
                function TagComponent() {
                    this.tagRemoved = new core_1.EventEmitter();
                }
                TagComponent.prototype.removeTag = function () {
                    this.tagRemoved.emit(this.index);
                };
                __decorate([
                    core_1.Input(), 
                    __metadata('design:type', Boolean)
                ], TagComponent.prototype, "selected", void 0);
                __decorate([
                    core_1.Input(), 
                    __metadata('design:type', String)
                ], TagComponent.prototype, "text", void 0);
                __decorate([
                    core_1.Input(), 
                    __metadata('design:type', Number)
                ], TagComponent.prototype, "index", void 0);
                __decorate([
                    core_1.Output(), 
                    __metadata('design:type', core_1.EventEmitter)
                ], TagComponent.prototype, "tagRemoved", void 0);
                TagComponent = __decorate([
                    core_1.Component({
                        selector: 'tag',
                        template: "{{text}}\n  <span\n  class=\"tag-select\"\n  (click)=\"removeTag()\">&times;</span>",
                        styles: ["\n    :host {\n         display: inline-block;\n        background: #fff;\n        padding: 7px;\n        margin-right: 10px;\n        border: #ccc 1px solid;\n        border-radius: 4px;\n        margin-bottom: 10px !important;\n    }\n\n    :host.tag-control-selected {\n      color: white;\n      background: #a94442;\n    }\n\n    .tag-select {\n      cursor: pointer;\n      display: inline-block;\n      padding: 0 3px;\n    }\n  "],
                        host: {
                            '[class.tag-control-selected]': 'selected'
                        }
                    }), 
                    __metadata('design:paramtypes', [])
                ], TagComponent);
                return TagComponent;
            }());
            exports_1("TagComponent", TagComponent);
        }
    }
});
//# sourceMappingURL=tag.component.js.map