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
import { UserCardComponent } from './user-card/user-card.component';
import { DashboardCardComponent } from './dashboard-card/dashboard-card.component';
import { HomeService } from '../service/home.service';
import { TestimonialViewComponent } from './dashboard-card/testimonial-view/testimonial-view.component';
import { AdminService } from '../service/admin.service';
import { AdminCoursesComponent } from './admin-courses/admin-courses.component';

@NgModule({
  declarations: [
    SideBarComponent,
    DashboardComponent,
    AdminProfileComponent,
    EditProfileComponent,
    NavBarComponent,
    UsersComponent,
    UserCardComponent,
    DashboardCardComponent,
    TestimonialViewComponent,
     AdminCoursesComponent
  ],
  imports: [
    SharedModule,
    AdminRoutingModule
  ],
  providers: [UserService, HomeService,AdminService]
})
export class AdminModule { }
