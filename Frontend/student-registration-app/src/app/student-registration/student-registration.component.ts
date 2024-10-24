import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Course } from '../models/course.model';
import { RegistrationService } from '../services/registration.service';
import { CourseService } from '../services/course.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-student-registration',
  templateUrl: './student-registration.component.html',
  styleUrl: './student-registration.component.scss'
})
export class StudentRegistrationComponent implements OnInit {
  courses: any[] = []
  registrationForm: FormGroup;

  constructor(
    private router: Router,
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
    if (this.registrationForm.value.selectedCourse.length != 3) {
      alert("Debes registrar exactamente 3 cursos")
      return
    }
    
    var valueArr = this.registrationForm.value.selectedCourse.map((item: { teacherId: any; }) => { return item.teacherId });
    var isDuplicate = valueArr.some((item: any, idx: any) => { 
      return valueArr.indexOf(item) != idx 
    });
    
    if(isDuplicate) {
      alert("No puedes registrar más de un curso con el mismo profesor")
      return
    }
    
    
    this.registrationService.registerStudent(this.registrationForm.value.name, this.registrationForm.value.selectedCourse)
      .subscribe(response => {
        this.router.navigate(['/courses/', response.id])
      })
  }
}
