import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutUsComponent } from './about-us/about-us.component';
import { AllAdvertisementComponent } from './all-advertisement/all-advertisement.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { CourseComponent } from './course/course.component';
import { DetailsComponent } from './details/details.component';
import { HomeComponent } from './home/home.component';
import { ExamComponent } from './exam/exam.component';

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
    path: 'details/:adId/:categoryId',
    component: DetailsComponent
  },
  {
    path: 'advertisement',
    component: AllAdvertisementComponent,
  },
  {
    path:'course',
    component:CourseComponent
  },
  {
    path:'exam',
    component: ExamComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ClintRoutingModule {}
