import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Outcome } from '../data/models';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

@Injectable({
    providedIn: 'root',
  })
export class DayAtDojoService {
    apiRoot: string = 'https://localhost:44340/api';
    apiURL: string = `${this.apiRoot}/DayAtDojo`;

    constructor(private _http: HttpClient) {}

    // Outcome
    getOutcome(): Observable<Outcome[]> {
        return this._http.get<Outcome[]>(`${this.apiURL}/GetOutcome`)
        .pipe(
            retry(1),
            catchError(this.handleError),
          );
    }

    addOutcome(value: Outcome): Observable<any> {
        return this._http.post<Outcome>(`${this.apiURL}/AddOutcome`, value)
        .pipe(
            retry(1),
            catchError(this.handleError),
        );
    }

    updateOutcome(value: Outcome): Observable<any> {
        return this._http.post<Outcome>(`${this.apiURL}/UpdateOutcome`, value)
        .pipe(
            retry(1),
            catchError(this.handleError),
        );
    }

    deleteOutcome(id: number): Observable<any> {
        return this._http.delete(`${this.apiURL}/DeleteOutcome/${id}`)
        .pipe(
            retry(1),
            catchError(this.handleError),
        );
    }

    handleError(error) {
        let errorMessage = '';
        if (error.error instanceof ErrorEvent) {
          // client-side error
          errorMessage = `Error: ${error.error.message}`;
        } else {
          // server-side error
          errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
        }
        window.alert(errorMessage);
        return throwError(errorMessage);
    }
}
