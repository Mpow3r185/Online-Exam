import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { SideBarComponent } from './side-bar/side-bar.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SharedModule } from '../shared/shared/shared.module';
import { AdminProfileComponent } from './admin-profile/admin-profile.component';
import { EditProfileComponent } from './edit-profile/edit-profile.component';
import { UserService } from '../service/user.service';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { UsersComponent } from './users/users.component';
import { DashboardCardComponent } from './dashboard-card/dashboard-card.component';
import { HomeService } from '../service/home.service';
import { TestimonialViewComponent } from './dashboard-card/testimonial-view/testimonial-view.component';
import { AdminService } from '../service/admin.service';
import { AdminCoursesComponent } from './admin-courses/admin-courses.component';
import { AdminTestimonialComponent } from './admin-testimonial/admin-testimonial.component';
import {MatTableModule} from '@angular/material/table';
import {MatSelectModule} from '@angular/material/select';
import { CreateCourseComponent } from './admin-courses/create-course/create-course.component';
import { AdminServicesComponent } from './admin-services/admin-services.component';
import { CreateServiceComponent } from './admin-services/create-service/create-service.component';


@NgModule({
  declarations: [
    SideBarComponent,
    DashboardComponent,
    AdminProfileComponent,
    EditProfileComponent,
    NavBarComponent,
    UsersComponent,
    DashboardCardComponent,
    TestimonialViewComponent,
    AdminCoursesComponent,
    AdminTestimonialComponent,
    CreateCourseComponent,
    AdminServicesComponent,
    CreateServiceComponent
  ],
  imports: [
    SharedModule,
    AdminRoutingModule,
    MatTableModule,
     MatSelectModule
  ],
  providers: [UserService, HomeService,AdminService]
})
export class AdminModule { }
