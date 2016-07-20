//import {Injectable} from '@angular/core';
//import {Http, Response} from '@angular/http';

//import {Observable} from 'rxjs/Observable';

//import {IExercise, IExerciseEquipment, IExerciceTag, IExerciseImage} from './exercise';

//@Injectable()
//export class ExerciseService {
//    private _exerciseUrl = '';

//    constructor(private _http: Http) { }

//    getEquipment(): Observable<IExercise[]> {
//        return this._http.get(this._exerciseUrl)
//            .map((response: Response) => <IExercise[]>response.json())
//            .do(data => console.log("All: " + JSON.stringify(data)))
//            .catch(this.handleError);
//    };

//    private handleError(error: Response) {
//        console.error(error);
//        return Observable.throw(error.json().error || 'Server error');
//    }

//}
