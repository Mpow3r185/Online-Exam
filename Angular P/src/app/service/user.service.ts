import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { SpinnerComponent } from '../spinner/spinner.component';

@Injectable({
  providedIn: 'root',
})
export class UserService {
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

    SpinnerComponent.show();

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
          setTimeout(() => {
            SpinnerComponent.hide()
          }, 2000);
        },
        (error) => console.log(error)
      );
      },
      (error) => console.log(error)
    );
  
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
      (error) => console.log(error)
    );
  }
async editAccount(data: any): Promise<void>{
   // body.imageName = this.displayImage;
    console.log(data);
    
   data.rolename = this.homeService.selectedUser[0].rolename; data.status = this.homeService.selectedUser[0].status; 
   data.profilePicture = this.homeService.selectedUser[0].profilePicture; data.username = this.homeService.selectedUser[0].username; 
   data.password = this.homeService.selectedUser[0].password;
    console.log(data);
   this.http.put("https://localhost:44342/api/Account",data).subscribe((data:any)=>{
        console.log(data);
        this.toastr.success("Updated successfully");
        
    }, err=>{
      console.log(err.message);
    })
    console.log(data);
    
  }
}
