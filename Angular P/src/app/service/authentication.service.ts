import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import jwtDecode from 'jwt-decode';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SpinnerComponent } from '../spinner/spinner.component';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  loginForm: FormGroup = new FormGroup(
    {
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.minLength(8)]),
    }
  );

  registerForm: FormGroup = new FormGroup({
    firstName: new FormControl('', [Validators.required]),
    lastName: new FormControl('', Validators.required),
    username: new FormControl('', Validators.required),
    email: new FormControl('', [Validators.required, Validators.email]),
    address: new FormControl('', Validators.required),
    phoneNumber: new FormControl('', Validators.required),
    profilePic: new FormControl(),
    password: new FormControl('', [Validators.required, Validators.minLength(8)]),
  }
  );

  constructor(private http: HttpClient, private router: Router, private toastr: ToastrService) { }

  createNewCustomer(){
    // debugger
    const headerDict = {
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    }
    const requestOptions = {
      headers: new HttpHeaders(headerDict),
    };
    SpinnerComponent.show();
    if (this.registerForm.valid) {
    this.http.post('https://localhost:44359/api/Users', this.registerForm.value, requestOptions).subscribe(
      (data: any) => {
        if (data == 'Sucessfully') {
          setTimeout(() => {
            window.location.reload();
            SpinnerComponent.hide();
          }, 2000);
          setTimeout(() => {
            this.toastr.success('Success')
          }, 2000);
        }
      },
      error => {
        if (error.status != 200) {
          window.location.reload();
          setTimeout(() => {
            SpinnerComponent.hide();
          }, 2000);
          setTimeout(() => {
            this.toastr.error('Failed Processing, Please try again')
          }, 2000);
        }
      }
      );
    }
    else {
      window.location.reload();
      setTimeout(() => {
        SpinnerComponent.hide();
      }, 2000);
      setTimeout(() => {
        this.toastr.error('Failed Processing, Please try again')
      }, 2000);
    }
  }

  chickAuthentication() {
    const headerDict = {
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    }
    const requestOptions = {
      headers: new HttpHeaders(headerDict),
    };

    var response1:any;

    SpinnerComponent.show();

    this.http.post('https://localhost:44359/api/Login/Auth', this.loginForm.value, requestOptions).subscribe(
      (result: any) => {
        response1 = result;
        const response={
          token:response1.toString(),
        };
        localStorage.setItem('token', response.token);
        let data:any = jwtDecode(response.token);
        localStorage.setItem('user', JSON.stringify({...data}));
        if (data.role == 'admin') {
          this.router.navigate(['admin/dashboard']);
        }
        else if (data.role == 'Client') {
          // SpinnerComponent.hide();
          this.router.navigate(['/client/home']);
        }
      },
      error => {
        if (error.stats != 200) {
          setTimeout(() => {
            SpinnerComponent.hide();
          }, 2000);
          setTimeout(() => {
            this.toastr.error("User not found, Please try Again")
          }, 2000);
        }
      }
    );
  }
}
