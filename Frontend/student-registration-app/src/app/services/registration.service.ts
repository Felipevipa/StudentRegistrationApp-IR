import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Student } from '../models/student.model.';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {
  private apiUrl = 'http://localhost:5199';

  constructor(private http: HttpClient) {}

  registerStudent(student: Student): Observable<any> {
    return this.http.post(`${this.apiUrl}/students/register`, student);
  }
}
