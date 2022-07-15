import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { SpinnerComponent } from '../spinner/spinner.component';
import { HomeService } from './home.service';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  
   InvoicesData:any;
  CertificateData:any;
  
  updateForm: FormGroup = new FormGroup({
    Id: new FormControl(),
    email: new FormControl('', [Validators.required, Validators.email]),
    username: new FormControl('', [Validators.required]),
    firstName: new FormControl('', [Validators.required]),
    lastName: new FormControl('', Validators.required),
    address: new FormControl('', Validators.required),
    profilePic: new FormControl(),
  });

  selectedUser: any;
  users: any = [];
  numberOfOwner: number = 0;
  response!: { dbPath: "" };
  constructor(
    private http: HttpClient,
    private toastr: ToastrService,
    private homeService: HomeService
  ) {}

  public uploadFinished = (event: any) => {
    this.response = event;
  };

  updateUser() {
    const headerDict = {
      'Content-Type': 'application/json',
      Accept: 'application/json',
    };
    const requestOptions = {
      headers: new HttpHeaders(headerDict),
    };

    let user: any = localStorage.getItem('user');
    user = JSON.parse(user);

    if (this.response == null) {
      var pic = this.selectedUser.profilePic;
    } else {
      pic = this.response.dbPath;
    }

    this.updateForm.controls.Id.setValue(parseInt(user.primarysid));
    this.updateForm.controls.profilePic.setValue(pic);
    SpinnerComponent.show();
    if (this.updateForm.valid) {
    this.http
      .put(
        'https://localhost:44359/api/Users',
        this.updateForm.value,
        requestOptions
      )
      .subscribe(
        (result) => {
          if (result == 'Updated') {
            this.toastr.success('Success Process');
            window.location.reload();
            setTimeout(() => {
              SpinnerComponent.hide()
            }, 2000);
          }
        },
        (error) => {
          if (error.status != 200) {
            this.toastr.error('Failed Process');
            setTimeout(() => {
              SpinnerComponent.hide()
            }, 2000);
          }
        }
      );
    }
    else {
      setTimeout(() => {
        SpinnerComponent.hide();
      }, 2000);
      setTimeout(() => {
        this.toastr.error('Failed Possess');
      }, 2000);
    }
  }

  setInitValue() {
    this.updateForm.controls.email.setValue(this.selectedUser.email);
    this.updateForm.controls.username.setValue(this.selectedUser.username);
    this.updateForm.controls.firstName.setValue(this.selectedUser.firstName);
    this.updateForm.controls.lastName.setValue(this.selectedUser.lastName);
    this.updateForm.controls.address.setValue(this.selectedUser.address);
  }

  async getUserById(): Promise<void> {
    let user: any = localStorage.getItem('user');
    user = JSON.parse(user);

   // SpinnerComponent.show();

    let searchBody = {
      username: user.unique_name
    };
    this.http.post("https://localhost:44342/api/Account/SearchAccount",searchBody).subscribe(
      (result: any) => {
        let id  = result.id;
        this.http
      .post(`https://localhost:44342/api/account/GetAccountById/${result[0].id}` ,null)
      .subscribe(
        (result: any) => {
          this.selectedUser = result;
        });
      },
      (error) =>{
        this.toastr.error('Unable to connect the server');
      });
  
  }

  getAllUser() {
    SpinnerComponent.show();
    this.http.get('https://localhost:44359/api/Users').subscribe(
      (result: any) => {
        this.users = result.filter((value: any) => value.roleName != 'admin');
        setTimeout(() => {
          SpinnerComponent.hide();
        }, 2000);
      },
      (error) =>{
        this.toastr.error('Unable to connect the server');
      });
    }

  editAccount(data: any){
    
    SpinnerComponent.show();
    data.rolename = this.selectedUser.rolename; 
    data.status = this.selectedUser.status; 
    data.username = this.selectedUser.username;
    data.password = this.selectedUser.password;
    this.http.put("https://localhost:44342/api/Account",data).subscribe((data:any)=>{
    this.toastr.success("Updated successfully");
    SpinnerComponent.hide();
    }, err=>{
       this.toastr.error('Unable to connect the server');
     });
     
   }
   editAccountWithImage(body: any, img:FormData) {
     SpinnerComponent.show();
       this.http.post('https://localhost:44342/api/Account/Upload', img).subscribe((ResultImage: any) => {
         body.profilePicture = ResultImage.profilePicture;
         body.rolename = this.selectedUser.rolename; 
         body.status = this.selectedUser.status; 
         body.username = this.selectedUser.username;
         body.password = this.selectedUser.password;
         this.http.put('https://localhost:44342/api/Account', body).subscribe((res) => { 
            this.toastr.success("Profile Updated Successfully")
         }, err => {
           this.toastr.error("Unable to connect the server.");
           SpinnerComponent.hide();
         })
         
       }, err => {
         SpinnerComponent.hide();
       })  
   }

//Get invoice By User Id
  async GetInvoicesByUserId(){
    let userId = localStorage.getItem('AccountId');
    this.http.get(`https://localhost:44342/api/Invoice/GetInvoiceByUserId/${userId}`).subscribe((result: any) => {
      this.InvoicesData = result;
    },
    (error) => {
      this.toastr.error('Unable to connect server.')
    });
  }

//Get Certificate By User Id
  async GetCertificateByUserId(){
    let userId = localStorage.getItem('AccountId');
    this.http.get(`https://localhost:44342/api/Certificate/GetCertificateByUserId/${userId}`).subscribe((result: any) => {
      this.CertificateData = result;
    },
    (error) => {
      this.toastr.error('Unable to connect server.')
    });
  }

}
