import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared/shared.module';
import { UserProfileRoutingModule } from './user-profile-routing.module';
import { ProfileComponent } from './profile/profile.component';
import { ClintModule } from '../clint/clint.module';
import {MatSelectModule} from '@angular/material/select';
import { InvoiceComponent } from './invoice/invoice.component';
import { InvoiceDetailsComponent } from './invoice/invoice-details/invoice-details.component';
import { CertificateComponent } from './certificate/certificate.component';
import { CertificatedetailsComponent } from './certificate/certificatedetails/certificatedetails.component';



@NgModule({
  declarations: [
    ProfileComponent,
    InvoiceComponent,
    InvoiceDetailsComponent,
    CertificateComponent,
    CertificatedetailsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ClintModule,
    UserProfileRoutingModule,
    MatSelectModule
   
  ]
})
export class UserProfileModule { }
