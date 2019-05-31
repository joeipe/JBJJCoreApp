import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Grade, Person } from '../data/models';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable({
    providedIn: 'root',
  })
export class StudentService {
    apiRoot: string = 'https://localhost:44340/api';
    apiURL: string = `${this.apiRoot}/Student`;

    constructor(private _http: HttpClient) {}

    // Grade
    GetGrade(): Observable<Grade[]> {
        return this._http.get<Grade[]>(`${this.apiURL}/GetGrade`)
        .pipe(
            retry(1),
            catchError(this.handleError),
        );
    }

    AddGrade(value: Grade): Observable<any> {
        return this._http.post<Grade>(`${this.apiURL}/AddGrade`, value)
        .pipe(
            retry(1),
            catchError(this.handleError),
        );
    }

    UpdateGrade(value: Grade): Observable<any> {
        return this._http.post<Grade>(`${this.apiURL}/UpdateGrade`, value)
        .pipe(
            retry(1),
            catchError(this.handleError),
        );
    }

    DeleteGrade(id: number): Observable<any> {
        return this._http.delete(`${this.apiURL}/DeleteGrade/${id}`)
        .pipe(
            retry(1),
            catchError(this.handleError),
        );
    }

    // Grade
    getPerson(): Observable<Person[]> {
        return this._http.get<Person[]>(`${this.apiURL}/GetPerson`)
        .pipe(
            retry(1),
            catchError(this.handleError),
        );
    }

    GetPersonWithGraph(): Observable<Person[]> {
        return this._http.get<Person[]>(`${this.apiURL}/GetPersonWithGraph`)
        .pipe(
            retry(1),
            catchError(this.handleError),
        );
    }

    AddPerson(value: Person): Observable<any> {
        return this._http.post<Person>(`${this.apiURL}/AddPerson`, value)
        .pipe(
            retry(1),
            catchError(this.handleError),
        );
    }

    UpdatePerson(value: Person): Observable<any> {
        return this._http.post<Person>(`${this.apiURL}/UpdatePerson`, value)
        .pipe(
            retry(1),
            catchError(this.handleError),
        );
    }

    DeletePerson(id: number): Observable<any> {
        return this._http.delete(`${this.apiURL}/DeletePerson/${id}`)
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
