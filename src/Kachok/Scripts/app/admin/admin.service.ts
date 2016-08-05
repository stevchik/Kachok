import {Injectable, OnInit} from '@angular/core';
import {Http, Response, Headers, RequestOptions} from '@angular/http';

import {Observable} from 'rxjs/Observable';

import {Equipment, MuscleGroup, ExerciseUom, Status, Experience, ExerciseTarget} from './admin';


@Injectable()
export class AdminService {
    private _adminUrl: string = 'api/Admin';
    errorMessage: string;

    uomOptions: Array<EnumValue>;
    statusOptions: Array<EnumValue>;
    experienceOptions: Array<EnumValue>;
    targetOption: Array<EnumValue>;
    equipment: Array<Equipment>;
    muscleGroup: Array<MuscleGroup>;

    constructor(private _http: Http) { }

    Init(): void {
        this.uomOptions = this.getEnumOptions(ExerciseUom);
        this.statusOptions = this.getEnumOptions(Status);
        this.experienceOptions = this.getEnumOptions(Experience);
        this.targetOption = this.getEnumOptions(ExerciseTarget);

        this.getEquipment()
            .subscribe(
            equipment => this.equipment = equipment,
            error => this.errorMessage = <any>error
            );

        this.getMuscleGroup()
            .subscribe(
            muscle => this.muscleGroup = muscle,
            error => this.errorMessage = <any>error
            );
    }

    private getEquipment(): Observable<Equipment[]> {
        return this._http.get(this._adminUrl + "/Equipment")
            .map(this.extractData)
            .catch(this.handleError);
    };

    private getMuscleGroup(): Observable<MuscleGroup[]> {
        return this._http.get(this._adminUrl + "/MuscleGroups")
            .map(this.extractData)
            .catch(this.handleError);
    };

    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }

    private handleError(error: any) {
        // In a real world app, we might use a remote logging infrastructure
        // We'd also dig deeper into the error to get a better message
        let errMsg = (error.message) ? error.message : error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);
    }

    private getEnumOptions(par: any): Array<EnumValue> {

        let options: EnumValue[] = new Array<EnumValue>();

        if (par) {

            let keys = Object.keys(par).filter(a => parseInt(a, 10) >= 0);
       
            for (let key of keys) {
                 options.push(new EnumValue(key, par[key]));
            }
        }

        return options;
    }
}

export class EnumValue {
    constructor(public key?: string, public value?: string) { };
}