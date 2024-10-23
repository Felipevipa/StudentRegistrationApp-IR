import { Component } from '@angular/core';
import { Course } from '../models/course.model';
import { CourseService } from '../services/course.service';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrl: './course-list.component.scss'
})
export class CourseListComponent {
  courses: any[] = []

  constructor(private courseService: CourseService) { }


  ngOnInit(): void {
    this.courseService.getCoursesOfStudent("84f12883-e127-4af4-aff7-cea88f9d4a71")
      .subscribe(courses => {
        courses.map(course => {
          course.students = []

          this.courseService.getCourseStudents(course.id.id)
            .subscribe(students => {
              students.map(student => {
                student.courses = []
                this.courseService.getCoursesOfStudent(student.id.id)
                .subscribe(courses2 => {
                  student.courses = courses2;
                  course.students.push(student)
                })
              })
              console.log(course);
              this.courses.push(course)
            })
        })
      })
  }

}
