import {Injectable} from '@angular/core';
import {Http, Response} from '@angular/http';

import {Observable} from 'rxjs/Observable';

import {Exercise} from './exercise';

@Injectable()
export class ExerciseService {
    private _exerciseUrl = 'api/Exercises';

    constructor(private _http: Http) { }

    getExercises(): Observable<Exercise[]> {
        return this._http.get(this._exerciseUrl)
            .map(this.extractData)
            .catch(this.handleError);
    };

    getExercise(): Observable<Exercise> {
        return new Observable<Exercise>();
    };

    saveExercise(exercise: Exercise): Observable<Exercise> {
        return new Observable<Exercise>();
    };

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


    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }

    private handleError(error: any) {
        // In a real world app, we might use a remote logging infrastructure
        // We'd also dig deeper into the error to get a better message
        let errMsg = (error.message) ? error.message :  error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);
    }

}
