import { Component } from '@angular/core';
import { Course } from '../models/course.model';
import { CourseService } from '../services/course.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrl: './course-list.component.scss'
})
export class CourseListComponent {
  courses: any[] = []

  constructor(
    private route: ActivatedRoute,
    private courseService: CourseService
  ) { }


  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id')
    console.log(id);
    if(id == null){
      return
    }

    this.courseService.getCoursesOfStudent(id)
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
