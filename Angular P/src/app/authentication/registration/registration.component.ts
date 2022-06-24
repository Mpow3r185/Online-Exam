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
    phoneNumber: new FormControl('', [Validators.required,Validators.maxLength(20),Validators.minLength(10)]),
    password: new FormControl('', [Validators.required, Validators.minLength(8),Validators.maxLength(15)]),
  });



  ngOnInit(): void {
  }


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

