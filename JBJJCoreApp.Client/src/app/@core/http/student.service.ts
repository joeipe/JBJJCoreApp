import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ClassType } from '../data/models';

@Injectable({
    providedIn: 'root'
  })
export class StudentService {
    apiURL: string = 'https://localhost:44340/api/Schedule';

    constructor(private httpClient: HttpClient) {}

    public getClassType(){
        return this.httpClient.get<ClassType[]>(`${this.apiURL}/GetClassType`);
    }
}