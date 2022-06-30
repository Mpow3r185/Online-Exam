import { ExamProfileComponent } from './exam/exam-profile/exam-profile.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutUsComponent } from './about-us/about-us.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { CourseComponent } from './course/course.component';
import { HomeComponent } from './home/home.component';
import { ExamComponent } from './exam/exam.component';
import { Page404Component } from './page404/page404.component';
import { CourseProfileComponent } from './course/course-profile/course-profile.component';
import { ExamContentComponent } from './exam/exam-content/exam-content.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'contact',
    component: ContactUsComponent,
  },
  {
    path: 'aboutUs',
    component: AboutUsComponent,
  },
  {
    path:'courses',
    component:CourseComponent
  },
  {
    path:'exams',
    component: ExamComponent
  },
  {
    path:'exam/:id',
    component: ExamContentComponent
  },
  {
    path:'examProfile/:id',
    component: ExamProfileComponent
  },
  {
    path: 'course/:id',
    component: CourseProfileComponent
  },
  {
    path:'page404',
    component: Page404Component
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ClintRoutingModule {}
