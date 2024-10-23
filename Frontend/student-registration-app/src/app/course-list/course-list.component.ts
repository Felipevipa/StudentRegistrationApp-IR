import { Component } from '@angular/core';
import { Course } from '../models/course.model';
import { CourseService } from '../services/course.service';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrl: './course-list.component.scss'
})
export class CourseListComponent {
  courses: Course[] = []

  constructor(private courseService: CourseService) { }

  // ngOnInit(): void {
  //   this.courseService.getCourses().subscribe(courses => {
  //     this.courses = courses;
  //   });
  // }
}
