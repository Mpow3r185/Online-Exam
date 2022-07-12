import { CreateQuestionsComponent } from './admin-exams/create-questions/create-questions.component';
import { AdminExamsComponent } from './admin-exams/admin-exams.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminCoursesComponent } from './admin-courses/admin-courses.component';
import { AdminProfileComponent } from './admin-profile/admin-profile.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { UsersComponent } from './users/users.component';
import { AdminTestimonialComponent } from './admin-testimonial/admin-testimonial.component';
import { StudentReportComponent } from './student-report/student-report.component';
import { StdReportDetailsComponent } from './student-report/std-report-details/std-report-details.component';
import { AdminServicesComponent } from './admin-services/admin-services.component';
import { SiteInfoComponent } from './site-info/site-info.component';


const routes: Routes = [
  {
    path: '',
    component: DashboardComponent,
  },
   {
    path:'courses',
   component:AdminCoursesComponent
  },
  {
    path: 'adminProfile',
    component: AdminProfileComponent,
  },
  {
    path: 'users',
    component: UsersComponent,
  },
  {
    path: 'testimonial',
    component: AdminTestimonialComponent,
  },
  {
    path: 'studentReport',
    component: StudentReportComponent
  },
  {
    path: 'stdDetailsReport/:id',
    component: StdReportDetailsComponent
  },
  {
    path:'service',
    component:AdminServicesComponent
  },
  {
    path: 'exams',
    component: AdminExamsComponent
  },
  {
    path: 'siteInfo',
    component: SiteInfoComponent,
  },
  {
    path: 'createQuestions/:id',
    component: CreateQuestionsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule {}
