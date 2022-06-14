import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminProfileComponent } from './admin-profile/admin-profile.component';
import { AdvertisementComponent } from './advertisement/advertisement.component';
import { ContactMassageComponent } from './contact-massage/contact-massage.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { RentReportComponent } from './rent-report/rent-report.component';
import { SaleReportComponent } from './sale-report/sale-report.component';
import { UsersComponent } from './users/users.component';

const routes: Routes = [
  {
    path: 'dashboard',
    component: DashboardComponent,
  },
  {
    path: 'adminProfile',
    component: AdminProfileComponent,
  },
  {
    path: 'advertisement',
    component: AdvertisementComponent,
  },
  {
    path: 'users',
    component: UsersComponent,
  },
  {
    path: 'contactMassage',
    component: ContactMassageComponent,
  },
  {
    path: 'rentReport',
    component: RentReportComponent,
  },
  {
    path: 'saleReport',
    component: SaleReportComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule {}
