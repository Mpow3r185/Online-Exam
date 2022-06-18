import { NgModule } from '@angular/core';
import { ClintRoutingModule } from './clint-routing.module';
import { SharedModule } from '../shared/shared/shared.module';

import { ContactService } from '../service/contact.service';
import { HomeService } from '../service/home.service';
import { AdvertisementService } from '../service/advertisement.service';

import { HomeComponent } from './home/home.component';
import { InternalNavBarComponent } from '../internal-nav-bar/internal-nav-bar.component';
import { FooterComponent } from '../footer/footer.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { ServiceCardComponent } from './about-us/service-card/service-card.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { ContactUsFormComponent } from './contact-us/contact-us-form/contact-us-form.component';
import { ContactUsInfoCardComponent } from './contact-us/contact-us-info-card/contact-us-info-card.component';
import { TestimonialComponent } from './home/testimonial/testimonial.component';
import { DetailsComponent } from './details/details.component';
import { HeaderComponent } from './header/header.component';
import { TestimonialFormComponent } from './home/testimonial-form/testimonial-form.component';
import { UserService } from '../service/user.service';
import { AllAdvertisementComponent } from './all-advertisement/all-advertisement.component';
import { AllAdvertisementCardComponent } from './all-advertisement/all-advertisement-card/all-advertisement-card.component';
import { CourseCardComponent } from './course/course-card/course-card.component';
import { CourseComponent } from './course/course.component';

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
    DetailsComponent,
    HeaderComponent,
    TestimonialFormComponent,
    AllAdvertisementComponent,
    AllAdvertisementCardComponent,
    CourseCardComponent,
    CourseComponent,
    ExamComponent
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
  providers: [ContactService, AdvertisementService, HomeService, UserService]
})
export class ClintModule { }
