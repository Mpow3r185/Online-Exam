import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared/shared.module';
import { UserProfileRoutingModule } from './user-profile-routing.module';
import { ProfileComponent } from './profile/profile.component';
import { ClintModule } from '../clint/clint.module';



@NgModule({
  declarations: [
    ProfileComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ClintModule,
    UserProfileRoutingModule
  ]
})
export class UserProfileModule { }