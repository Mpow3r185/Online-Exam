import { SpinnerComponent } from 'src/app/spinner/spinner.component';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';


@Injectable({
  providedIn: 'root',
})
export class HomeService {
  
  exams: any;
  ourServiceData: any = [{}];

  constructor(
    private http: HttpClient,
    private toastr: ToastrService,
    private dialog: MatDialog
    ) {}

  // Get Exams
  getExams() {
    SpinnerComponent.show();
    this.http.get('https://localhost:44342/api/exam').subscribe((result) => {            
      this.exams = result;      
    }, error => {
      this.toastr.error('Unable to connect the server.')
    });
    SpinnerComponent.hide();
  }
  
  
  getAllServices(){
    this.http.get('https://localhost:44342/api/OurService').subscribe((result)=>{
        this.ourServiceData = result;
        //this.toastr.success("service retrieved");
    },err =>{
      console.log(err.message,err.status);
       this.toastr.error('Unable to connect the server');
    })
  }
  
  //To get info for user he just login
  getUserByUserName() {
    let user: any = localStorage.getItem('user');
    user = JSON.parse(user);
    let searchBody = {
      username: user.unique_name
    };
    this.http.post('https://localhost:44342/api/Account/SearchAccount', searchBody).subscribe(
        (result: any) => {
          this.selectedUser = result;
          //console.log(this.selectedUser);
        },
        (error) => console.log(error)
      );
  }
  
}
