import { NgModule } from '@angular/core';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { AuthenticationRoutingModule } from './authentication-routing.module';
import { SharedModule } from '../shared/shared/shared.module';
import { HttpClientModule } from '@angular/common/http';
import { AuthenticationService } from '../service/authentication.service';
import { AuthenticationComponent } from './authentication/authentication.component';
import { InternalNavBarComponent } from '../internal-nav-bar/internal-nav-bar.component';
import { ClintModule } from '../clint/clint.module';

@NgModule({
  declarations: [
    RegistrationComponent,
    LoginComponent,
    AuthenticationComponent,
  ],
  imports: [
    AuthenticationRoutingModule,
    SharedModule,
    ClintModule
  ],
  providers: [AuthenticationService]
})
export class AuthenticationModule { }
