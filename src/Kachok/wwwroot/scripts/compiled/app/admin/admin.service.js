System.register(['@angular/core', '@angular/http', 'rxjs/Observable', './admin'], function(exports_1, context_1) {
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
    var core_1, http_1, Observable_1, admin_1;
    var AdminService, EnumValue;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (http_1_1) {
                http_1 = http_1_1;
            },
            function (Observable_1_1) {
                Observable_1 = Observable_1_1;
            },
            function (admin_1_1) {
                admin_1 = admin_1_1;
            }],
        execute: function() {
            AdminService = (function () {
                function AdminService(_http) {
                    this._http = _http;
                    this._adminUrl = 'api/Admin';
                }
                AdminService.prototype.Init = function () {
                    var _this = this;
                    this.uomOptions = this.getEnumOptions(admin_1.ExerciseUom);
                    this.statusOptions = this.getEnumOptions(admin_1.Status);
                    this.experienceOptions = this.getEnumOptions(admin_1.Experience);
                    this.targetOption = this.getEnumOptions(admin_1.ExerciseTarget);
                    this.getEquipment()
                        .subscribe(function (equipment) { return _this.equipment = equipment; }, function (error) { return _this.errorMessage = error; });
                    this.getMuscleGroup()
                        .subscribe(function (muscle) { return _this.muscleGroup = muscle; }, function (error) { return _this.errorMessage = error; });
                };
                AdminService.prototype.getEquipment = function () {
                    return this._http.get(this._adminUrl + "/Equipment")
                        .map(this.extractData)
                        .catch(this.handleError);
                };
                ;
                AdminService.prototype.getMuscleGroup = function () {
                    return this._http.get(this._adminUrl + "/MuscleGroups")
                        .map(this.extractData)
                        .catch(this.handleError);
                };
                ;
                AdminService.prototype.extractData = function (res) {
                    var body = res.json();
                    return body || {};
                };
                AdminService.prototype.handleError = function (error) {
                    // In a real world app, we might use a remote logging infrastructure
                    // We'd also dig deeper into the error to get a better message
                    var errMsg = (error.message) ? error.message : error.status ? error.status + " - " + error.statusText : 'Server error';
                    console.error(errMsg); // log to console instead
                    return Observable_1.Observable.throw(errMsg);
                };
                AdminService.prototype.getEnumOptions = function (par) {
                    var options = new Array();
                    if (par) {
                        var keys = Object.keys(par).filter(function (a) { return parseInt(a, 10) >= 0; });
                        for (var _i = 0, keys_1 = keys; _i < keys_1.length; _i++) {
                            var key = keys_1[_i];
                            options.push(new EnumValue(key, par[key]));
                        }
                    }
                    return options;
                };
                AdminService = __decorate([
                    core_1.Injectable(), 
                    __metadata('design:paramtypes', [http_1.Http])
                ], AdminService);
                return AdminService;
            }());
            exports_1("AdminService", AdminService);
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
//# sourceMappingURL=admin.service.js.map