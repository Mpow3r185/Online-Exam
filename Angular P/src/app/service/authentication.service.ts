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
  AccountData:any =[{}]; 

  loginForm: FormGroup = new FormGroup(
    {
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.minLength(8)]),
    }
  );

  
  constructor(private http: HttpClient, private router: Router, private toastr: ToastrService) { }

  //Create new user function
  createNewUser(body: any){
    // debugger

    const headerDict = {
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    }
    const requestOptions = {
      headers: new HttpHeaders(headerDict),
    };

    SpinnerComponent.show();
    body.status = 'Ok';
    body.rolename = 'Student';
    body.gender = 'N/A';
    body.profilepicture = 'pp.png';

    this.http.post('https://localhost:44342/api/Account', body).subscribe(
      (data: any) => {
          setTimeout(() => {
            //window.location.reload();
            SpinnerComponent.hide();
          }, 2000);
          setTimeout(() => {
            this.toastr.success('Successfully Registration')
          }, 2000);
      },
      error => {
        if (error.status != 200) {
          setTimeout(() => {
            SpinnerComponent.hide();
          }, 2000);
          setTimeout(() => {
            this.toastr.error('Failed Processing, Please try again')
          }, 2000);
          console.log(error.message,error.status)
        }
      });

      //---This to get the information for the last user he register on site
      let getId = {
        Email: body.email,
        Username:body.username
      }
      this.http.post('https://localhost:44342/api/Account/SearchAccount',getId,requestOptions).subscribe((result)=>{
            this.AccountData = result; 
            console.log("Done Retrieve");
            console.log(this.AccountData);  
            console.log(this.AccountData[0]);
            //when i need to access the id like this he type undefined 
            console.log(this.AccountData[0].id);
            
        },err =>{
          console.log(err.message,err.status);
          //this.toastr.error(err.message,err.status);
        })
        //--- This for add the PhoneNumber on phone number table
      //   let numInfo = {
      //     PhoneNum:body.phoneNumber,
      //     AccountId:this.AccountData[0].Id
      //   }
      // this.http.post('https://localhost:44342/api/PhoneNumber', numInfo, requestOptions).subscribe(
      // (data: any) => {
      //     console.log("Add phone number is done");   
      // },
      // error => {
      //   if (error.status != 200) {
      //     console.log(error.message,error.status)
      //   }
      // });



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
