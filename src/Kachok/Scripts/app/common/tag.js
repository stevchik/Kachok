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
    var TagCompoenent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            }],
        execute: function() {
            TagCompoenent = (function () {
                function TagCompoenent() {
                    this.tag = '';
                }
                TagCompoenent.prototype.ngOnInit = function () {
                    if (this.ngModel)
                        this.tagList = this.ngModel;
                };
                __decorate([
                    core_1.Input(), 
                    __metadata('design:type', Array)
                ], TagCompoenent.prototype, "ngModel", void 0);
                TagCompoenent = __decorate([
                    core_1.Component({
                        selector: 'tag',
                        template: "\n{{tagList}}\n    ",
                        styleUrls: ['css/tag.css']
                    }), 
                    __metadata('design:paramtypes', [])
                ], TagCompoenent);
                return TagCompoenent;
            }());
            exports_1("TagCompoenent", TagCompoenent);
        }
    }
});
//# sourceMappingURL=tag.js.map