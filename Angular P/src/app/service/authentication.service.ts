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
  chickAuthentication(body:any) {

    const headerDict = {
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    }
    const requestOptions = {
      headers: new HttpHeaders(headerDict),
    };

    SpinnerComponent.show();
    this.http.post('https://localhost:44342/api/Account/login', body, requestOptions).subscribe(
      (result: any) => {

        const response={
          token:result.toString(),
        };

        localStorage.setItem('token', response.token);
        let data:any = jwtDecode(response.token);
        
        localStorage.setItem('user', JSON.stringify({...data}));
        
        //Check if user is Blocked Account
        let searchBody = {
          username: data.unique_name
        };
        this.http.post('https://localhost:44342/api/Account/SearchAccount', searchBody).subscribe(
            (result: any) => {
              if(result[0].status == 'BLOCK'){
                localStorage.clear();
                SpinnerComponent.hide();
                this.toastr.info("This User Is Blocked By Admin For Some Reasons");
              }else{
                localStorage.setItem('AccountId', result[0].id);
                if (data.role == 'Admin') {
                  this.router.navigate(['admin/']);
                }
                else if (data.role == 'Student') {
                  SpinnerComponent.hide();
                  this.router.navigate(['/']);
                }
              }
            }
          );
      },
      error => {
          setTimeout(() => {
            SpinnerComponent.hide();
          }, 2000);
          setTimeout(() => {
            this.toastr.error("These credentials do not match our records.")
          }, 2000);
      });
  }
  
}
