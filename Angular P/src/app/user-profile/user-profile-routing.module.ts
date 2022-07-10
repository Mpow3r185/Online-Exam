import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProfileComponent } from './profile/profile.component';
import { UserProfileModule } from './user-profile.module';
import { InvoiceComponent } from './invoice/invoice.component';
import { CertificateComponent } from './certificate/certificate.component';

const routes: Routes = [
  {
    path: 'myprofile',
    component: ProfileComponent,
  },
  {
    path: 'invoice',
    component: InvoiceComponent,
  },
  {
    path: 'certificate',
    component: CertificateComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserProfileRoutingModule { }
