import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthenticationService } from 'src/app/service/authentication.service';
import { SpinnerComponent } from '../../spinner/spinner.component';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  hide = true;
  response!: { dbPath: "" };

  constructor(public authService: AuthenticationService, private router: Router,private toastr: ToastrService) { }

   //For Register new user
   registerForm: FormGroup = new FormGroup({
    fullName: new FormControl('', [Validators.required, Validators.minLength(6), Validators.maxLength(60)]),
    username: new FormControl('', [Validators.required,Validators.minLength(5), Validators.maxLength(15)]),
    email: new FormControl('', [Validators.required, Validators.email]),
    phoneNumber: new FormControl('', Validators.required),
    password: new FormControl('', [Validators.required, Validators.minLength(8),Validators.maxLength(15)]),
  });



  ngOnInit(): void {
  }

  onPasswordChange() {
    if (this.registerForm.controls.password.value == this.registerForm.controls.confirmPassword.value) {
      this.registerForm.controls.confirmPassword.setErrors(null);
    } else {
      this.registerForm.controls.confirmPassword.setErrors({ mismatch: true });
    }
  }

  public uploadFinished = (event: any) => {
    this.response = event;
  };

  createUser() {
    
    if(this.registerForm.valid){
      this.authService.createNewUser(this.registerForm.value);
      this.router.navigate(['auth/login'])
    }
    else {
        this.toastr.error('You Must Fill The Fields First')
    }
  }


  goToLogin(){
    this.router.navigate(['auth/login'])
  }
}

