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
    var EnumToKeysPipe, EnumValue;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            }],
        execute: function() {
            EnumToKeysPipe = (function () {
                function EnumToKeysPipe() {
                }
                EnumToKeysPipe.prototype.transform = function (value, args) {
                    var keys = new Array();
                    for (var _i = 0, value_1 = value; _i < value_1.length; _i++) {
                        var enumMember = value_1[_i];
                        var isValueProperty = parseInt(enumMember, 10) >= 0;
                        if (isValueProperty) {
                            keys.push(new EnumValue(enumMember, value[enumMember]));
                        }
                    }
                    return keys;
                };
                EnumToKeysPipe = __decorate([
                    core_1.Pipe({ name: 'enumToKeys' }), 
                    __metadata('design:paramtypes', [])
                ], EnumToKeysPipe);
                return EnumToKeysPipe;
            }());
            exports_1("EnumToKeysPipe", EnumToKeysPipe);
            EnumValue = (function () {
                function EnumValue(key, value) {
                    this.key = key;
                    this.value = value;
                }
                ;
                return EnumValue;
            }());
            exports_1("EnumValue", EnumValue);
        }
    }
});
//# sourceMappingURL=enumToKeysPipe.js.map