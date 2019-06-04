import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Outcome, Attendance, AttendanceDetailed, SparringDetails } from '../data/models';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from '../../../environments/environment';

@Injectable({
    providedIn: 'root',
  })
export class DayAtDojoService {
    apiURL: string = `${environment.apiRoot}/DayAtDojo`;

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

    // Attendance
    getAttendanceWithTimeTableGraph(): Observable<Attendance[]> {
        return this._http.get<Attendance[]>(`${this.apiURL}/GetAttendanceWithTimeTableGraph`)
        .pipe(
            retry(1),
            catchError(this.handleError),
          );
    }

    getAttendanceWithGraphById(id: number): Observable<AttendanceDetailed> {
        return this._http.get<AttendanceDetailed>(`${this.apiURL}/GetAttendanceWithGraphById/${id}`)
        .pipe(
            retry(1),
            catchError(this.handleError),
          );
    }

    addAttendance(value: Attendance): Observable<any> {
        return this._http.post<Attendance>(`${this.apiURL}/AddAttendance`, value)
        .pipe(
            retry(1),
            catchError(this.handleError),
        );
    }

    updateAttendance(value: Attendance): Observable<any> {
        return this._http.post<Attendance>(`${this.apiURL}/UpdateAttendance`, value)
        .pipe(
            retry(1),
            catchError(this.handleError),
        );
    }

    deleteAttendance(id: number): Observable<any> {
        return this._http.delete(`${this.apiURL}/DeleteAttendance/${id}`)
        .pipe(
            retry(1),
            catchError(this.handleError),
        );
    }

    addSparringDetails(value: SparringDetails): Observable<any> {
        return this._http.post<Attendance>(`${this.apiURL}/AddSparringDetails`, value)
        .pipe(
            retry(1),
            catchError(this.handleError),
        );
    }

    updateSparringDetails(value: SparringDetails): Observable<any> {
        return this._http.post<Attendance>(`${this.apiURL}/UpdateSparringDetails`, value)
        .pipe(
            retry(1),
            catchError(this.handleError),
        );
    }

    deleteSparringDetails(id: number): Observable<any> {
        return this._http.delete(`${this.apiURL}/DeleteSparringDetails/${id}`)
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
