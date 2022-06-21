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
import { AdvertisementComponent } from './advertisement/advertisement.component';
import { ContactMassageComponent } from './contact-massage/contact-massage.component';
import { ContactMassageCardComponent } from './contact-massage-card/contact-massage-card.component';
import { UsersComponent } from './users/users.component';
import { UserCardComponent } from './user-card/user-card.component';
import { ContactService } from '../service/contact.service';
import { DashboardCardComponent } from './dashboard-card/dashboard-card.component';
import { HomeService } from '../service/home.service';
import { TestimonialViewComponent } from './dashboard-card/testimonial-view/testimonial-view.component';
import { RentReportComponent } from './rent-report/rent-report.component';
import { SaleReportComponent } from './sale-report/sale-report.component';


@NgModule({
  declarations: [
    SideBarComponent,
    DashboardComponent,
    AdminProfileComponent,
    EditProfileComponent,
    NavBarComponent,
    AdvertisementComponent,
    ContactMassageComponent,
    ContactMassageCardComponent,
    UsersComponent,
    UserCardComponent,
    DashboardCardComponent,
    TestimonialViewComponent,
    RentReportComponent,
    SaleReportComponent
  ],
  imports: [
    SharedModule,
    AdminRoutingModule
  ],
  providers: [UserService, ContactService, HomeService]
})
export class AdminModule { }
