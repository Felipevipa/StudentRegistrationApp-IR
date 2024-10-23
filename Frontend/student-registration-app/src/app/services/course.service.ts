import { Injectable } from '@angular/core';
import { Course } from '../models/course.model';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class CourseService {
    private courses: Course[] = [
        { id: "id1", name: 'Matematicas' },
        { id: "id2", name: 'Fisica' },
        { id: "id3", name: 'Quimica' },
        { id: "id4", name: 'Filosofia' },
        { id: "id5", name: 'Historia' },
    ];

    private apiUrl = 'http://localhost:5199';

    private coursesSubject: BehaviorSubject<Course[]> = new BehaviorSubject(this.courses);

    constructor(private http: HttpClient) { }

    getCourses() {
        return this.http.get<any[]>(`${this.apiUrl}/courses/GetAllCourses`);
    }

    getCoursesOfStudent(id: string) {
        return this.http.get<any[]>(`${this.apiUrl}/enrollments/GetCoursesOfStudent/${id}`);
    }

    getCourseStudents(id: string) {
        return this.http.get<any[]>(`${this.apiUrl}/enrollments/GetCourseStudents/${id}`);
    }
}