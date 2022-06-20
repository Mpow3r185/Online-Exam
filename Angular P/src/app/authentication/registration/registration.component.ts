import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/service/authentication.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  hide = true;
  response!: { dbPath: "" };
  constructor(public authService: AuthenticationService, private router: Router) { }
  ngOnInit(): void {
  }

  onPasswordChange() {
    if (this.authService.registerForm.controls.password.value == this.authService.registerForm.controls.confirmPassword.value) {
      this.authService.registerForm.controls.confirmPassword.setErrors(null);
    } else {
      this.authService.registerForm.controls.confirmPassword.setErrors({ mismatch: true });
    }
  }

  public uploadFinished = (event: any) => {
    this.response = event;
  };

  createCustomer() {
    if (this.response.dbPath != null || this.response.dbPath != '') {
      this.authService.registerForm.controls.profilePic.setValue(this.response.dbPath);
    }
    else
    {
      this.authService.registerForm.controls.profilePic.setErrors({required: true});
    }
    this.authService.createNewCustomer();
  }
  goToLogin(){
    this.router.navigate(['auth/login'])
  }
}