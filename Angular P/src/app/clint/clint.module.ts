import { NgModule } from '@angular/core';
import { ClintRoutingModule } from './clint-routing.module';
import { SharedModule } from '../shared/shared/shared.module';

import { ContactService } from '../service/contact.service';
import { HomeService } from '../service/home.service';

import { HomeComponent } from './home/home.component';
import { InternalNavBarComponent } from '../internal-nav-bar/internal-nav-bar.component';
import { FooterComponent } from '../footer/footer.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { ServiceCardComponent } from './about-us/service-card/service-card.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { ContactUsFormComponent } from './contact-us/contact-us-form/contact-us-form.component';
import { ContactUsInfoCardComponent } from './contact-us/contact-us-info-card/contact-us-info-card.component';
import { TestimonialComponent } from './home/testimonial/testimonial.component';
import { HeaderComponent } from './header/header.component';
import { UserService } from '../service/user.service';
import { CourseCardComponent } from './course/course-card/course-card.component';
import { CourseComponent } from './course/course.component';
import { ExamComponent } from './exam/exam.component';
import { ExamCardComponent } from './exam/exam-card/exam-card.component';
import { ExamProfileComponent } from './exam/exam-profile/exam-profile.component';
import { Page404Component } from './page404/page404.component';
import { CourseProfileComponent } from './course/course-profile/course-profile.component';
import { PaypalDialogComponent } from './exam/exam-profile/paypal-dialog/paypal-dialog.component';

@NgModule({
  declarations: [
    HomeComponent,
    InternalNavBarComponent,
    FooterComponent,
    AboutUsComponent,
    ServiceCardComponent,
    ContactUsComponent,
    ContactUsFormComponent,
    ContactUsInfoCardComponent,
    TestimonialComponent,
    HeaderComponent,
    CourseCardComponent,
    CourseComponent,
    ExamComponent,
    ExamCardComponent,
    ExamProfileComponent,
    Page404Component,
    CourseProfileComponent,
    PaypalDialogComponent
  ],
  imports: [
    ClintRoutingModule,
    SharedModule
  ],
  exports:[
    InternalNavBarComponent,
    FooterComponent,
    HeaderComponent
  ],
  providers: [ContactService, HomeService, UserService]
})
export class ClintModule { }
