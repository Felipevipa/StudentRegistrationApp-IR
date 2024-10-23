import { Routes } from '@angular/router';
import { StudentRegistrationComponent } from './student-registration/student-registration.component';
import { CourseListComponent } from './course-list/course-list.component';

export const routes: Routes = [
    { path: '', redirectTo: '/register', pathMatch: 'full' },
    { path: 'register', component: StudentRegistrationComponent },
    { path: 'courses', component: CourseListComponent }
  ];
