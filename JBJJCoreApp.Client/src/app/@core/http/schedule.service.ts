import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ClassType, TimeTable } from '../data/models';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from '../../../environments/environment';

@Injectable({
    providedIn: 'root',
  })
export class ScheduleService {
    apiURL: string = `${environment.apiRoot}/Schedule`;

    constructor(private _http: HttpClient) {}

    // Class Type
    getClassType(): Observable<ClassType[]> {
        return this._http.get<ClassType[]>(`${this.apiURL}/GetClassType`)
        .pipe(
            retry(1),
            catchError(this.handleError),
          );
    }

    AddClassType(value: ClassType): Observable<any> {
        return this._http.post<ClassType>(`${this.apiURL}/AddClassType`, value)
        .pipe(
            retry(1),
            catchError(this.handleError),
            );
    }

    UpdateClassType(value: ClassType): Observable<any> {
        return this._http.post<ClassType>(`${this.apiURL}/UpdateClassType`, value)
        .pipe(
            retry(1),
            catchError(this.handleError),
            );
    }

    DeleteClassType(id: number): Observable<any> {
        return this._http.delete(`${this.apiURL}/DeleteClassType/${id}`)
        .pipe(
            retry(1),
            catchError(this.handleError),
          );
    }

    // Time Table
    GetTimeTable(): Observable<TimeTable[]> {
        return this._http.get<TimeTable[]>(`${this.apiURL}/GetTimeTable`)
        .pipe(
            retry(1),
            catchError(this.handleError),
          );
    }

    GetTimeTableWithGraph(): Observable<TimeTable[]> {
        return this._http.get<TimeTable[]>(`${this.apiURL}/GetTimeTableWithGraph`)
        .pipe(
            retry(1),
            catchError(this.handleError),
            );
    }

    AddTimeTable(value: TimeTable): Observable<any> {
        return this._http.post<TimeTable>(`${this.apiURL}/AddTimeTable`, value)
        .pipe(
            retry(1),
            catchError(this.handleError),
            );
    }

    UpdateTimeTable(value: TimeTable): Observable<any> {
        return this._http.post<TimeTable>(`${this.apiURL}/UpdateTimeTable`, value)
        .pipe(
            retry(1),
            catchError(this.handleError),
            );
    }

    DeleteTimeTable(id: number): Observable<any> {
        return this._http.delete(`${this.apiURL}/DeleteTimeTable/${id}`)
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
