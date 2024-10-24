import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { Student } from '../models/student.model.';
import { CourseRegisterDto, RegisterDto } from '../models/registerDtos.model';
import { Course } from '../models/course.model';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {
  private apiUrl = 'http://localhost:5199';

  constructor(private http: HttpClient) {}

  registerStudent(studentName: string, courses: any[]): Observable<any>  {
    const mapCourses: CourseRegisterDto[] = []; 
    console.log(courses);

    courses.map(course => {
      mapCourses.push({
        courseId: course.courseId,
        courseName: course.name,
        credits: course.credits,
        teacherId: course.teacherId,
        teacherName: course.teacher.name,
      })
    })

    const data: RegisterDto = {
      studentName: studentName,
      courses: mapCourses,
    }
    console.log(data);
    
    return this.http.post<any>(`${this.apiUrl}/student/register`, data);
  }
}
