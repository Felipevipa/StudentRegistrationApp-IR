import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Course } from '../models/course.model';
import { RegistrationService } from '../services/registration.service';
import { CourseService } from '../services/course.service';

@Component({
  selector: 'app-student-registration',
  templateUrl: './student-registration.component.html',
  styleUrl: './student-registration.component.scss'
})
export class StudentRegistrationComponent implements OnInit {
  courses: any[] = []
  // courses: Course[] = [
  //   { id: "Id1", name: "Historia 1" },
  //   { id: "Id2", name: "Historia 2" },
  //   { id: "Id3", name: "Historia 3" },
  //   { id: "Id4", name: "Historia 4" },
  // ]
  registrationForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private registrationService: RegistrationService,
    private courseService: CourseService,
  ) {
    this.registrationForm = this.formBuilder.group({
      name: ['', Validators.required],
      selectedCourse: [[], Validators.required]
    });
  }

  ngOnInit() {
    this.courseService.getCourses().subscribe(response => {
      this.courses = response;
    });
  }


  onSubmit() {
    console.warn(this.registrationForm.value);
  }
}
