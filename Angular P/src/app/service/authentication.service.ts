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

  
  constructor(private http: HttpClient, private router: Router, private toastr: ToastrService) { }

  //Create New Account Function
  createNewUser(body: any){

    SpinnerComponent.show();
    body.status = 'Ok';
    body.rolename = 'Student';
    body.gender = 'N/A';
    body.profilepicture = 'default.png';

    // Create Account API
    this.http.post('https://localhost:44342/api/Account', body).subscribe(
      (data: any) => {

          // Search Account Body
          let searchBody = {
            username: body.username
          };
          let accId: number;
          // Search Account API
          this.http.post('https://localhost:44342/api/account/searchAccount', searchBody).subscribe((account:any) => {
            
          // Create Phone Number Body
          let phoneNumberBody = 
            {
              phoneNum: body.phoneNumber,
              accountId: account[0].id
            };
              
            // Create Phone Number API
            this.http.post('https://localhost:44342/api/phoneNumber', phoneNumberBody).subscribe();
          });

          SpinnerComponent.hide();
          this.toastr.success('Successfully Registration');
      },
      error => {
          this.toastr.error('Failed Processing, Please try again');
      });
  }


  //-------------------------------------------------------
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
