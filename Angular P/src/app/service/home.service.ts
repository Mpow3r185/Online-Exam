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
  
  exams: any = [{}];
  courses: any = [{}];
  dynamicData: any = [{}];
  popularCoursesId!: any;
  popularCourses: any = [];
  ourServiceData: any = [{}];
  selectedUser: any;
  homePage: any = [{}];

  constructor(
    private http: HttpClient,
    private toastr: ToastrService,
    private dialog: MatDialog
    ) {
      this.run();
    }

  // Call Async Functions
  private async run() {
    SpinnerComponent.show();
    await this.getDynamicData();
    await this.getPopularCourses();
    SpinnerComponent.hide();
  }

  // Get Exams
  async getExams(): Promise<void> {
    this.http.get('https://localhost:44342/api/exam').subscribe((result) => { 
      SpinnerComponent.show();           
      this.exams = result;      
      SpinnerComponent.hide();
    }, error => {
      this.toastr.error('Unable to connect the server.')
    });
  }

  // Get Courses
  async getCourses(): Promise<void> {
    this.http.get('https://localhost:44342/api/course').subscribe((result) => {
      SpinnerComponent.show();
      this.courses = result;
      SpinnerComponent.hide();
    }, err => {
      this.toastr.error('Unable to connect the server');
    });
  }
  
  // Search Course
  async searchCourse(body: any) {
    this.http.post('https://localhost:44342/api/course/searchCourse', body).subscribe((result) => {
      SpinnerComponent.show();
      this.courses = result;
      console.log(result);
      
      SpinnerComponent.hide();
    }, err => {
      this.toastr.error('Unable to connect the server');
    });
  }

  // Get Dynamic Data
  async getDynamicData(): Promise<void> {
    
    this.http.get('https://localhost:44342/api/dynamicHome').subscribe((result) => {
      SpinnerComponent.show();
      this.dynamicData = result;      
      SpinnerComponent.hide();
    }, err => {
      this.toastr.error('Unable to connect the server');
    });
  }
  
  // Get Popular Courses Id
  private async getPopularCourses(): Promise<void> {
   this.http.get('https://localhost:44342/api/course/getPopularCourses').subscribe((result: any) => {  
    
    for (let item of result) {
      this.http.post(`https://localhost:44342/api/course/getCourseById/${item.courseId}`, null).subscribe((course) => {
        this.popularCourses.push(course);
      },
      err => {
        this.toastr.error('Unable to connect the server');
      })
    }
   },
   err => {
     this.toastr.error('Unable to connect the server');
   });
  }
  
  // Get Exams By Course Id
  async getExamsByCourseId(cid: number) {
    this.http.post(`https://localhost:44342/api/exam/getExamsByCourseId/${cid}`, null).subscribe((result) => {
      SpinnerComponent.show();      
      this.exams = result;
      SpinnerComponent.hide();
    }, err => {
      this.toastr.error('Unable to connect the server');
    });
  }
  
  async getAllServices(){
    this.http.get('https://localhost:44342/api/OurService').subscribe((result)=>{
        this.ourServiceData = result;
    },err =>{
      console.log(err.message,err.status);
       this.toastr.error('Unable to connect the server');
    })
  }

  // Search Exam
  async searchExam(body: any) {
    this.http.post('https://localhost:44342/api/exam/searchExam', body).subscribe((result) => {
      SpinnerComponent.show();
      this.exams = result;
      SpinnerComponent.hide();
    })
  }

  //To get info for user he just login
  async getUserByUserName() {
    let user: any = localStorage.getItem('user');
    user = JSON.parse(user);
    let searchBody = {
      username: user.unique_name
    };
    this.http.post('https://localhost:44342/api/Account/SearchAccount', searchBody).subscribe(
        (result: any) => {
          this.selectedUser = result;
        },
        (error) => console.log(error)
      );
  }
}
