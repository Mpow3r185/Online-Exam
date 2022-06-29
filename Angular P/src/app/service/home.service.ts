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
  testimonial: any = [{}];
  usersBuyExam: any = [{}];
  numberOfUsersBuyExam: any = 0;

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
    SpinnerComponent.show();

    this.http.get('https://localhost:44342/api/exam').subscribe((result) => { 
      this.exams = result;
    }, error => {
      this.toastr.error('Unable to connect the server.')
    });

    SpinnerComponent.hide();
  }

  // Get Exam By Id
  async getExamById(exid: number): Promise<void> {
    SpinnerComponent.show();

    this.http.post(`https://localhost:44342/api/exam/getExamById/${exid}`, null).subscribe((result) => {
      this.exams = result;
    }, err => {
      this.toastr.error('Unable to connect the server.')
    })

    SpinnerComponent.hide();
  }

  // Get Courses
  async getCourses(): Promise<void> {
    SpinnerComponent.show();

    this.http.get('https://localhost:44342/api/course').subscribe((result) => {
      this.courses = result.filter((value:any)=> value.status=='ENABLE');
    }, err => {
      this.toastr.error('Unable to connect the server');
    });

    SpinnerComponent.hide();
  }
  
  // Search Course
  async searchCourse(body: any) {
    SpinnerComponent.show();

    this.http.post('https://localhost:44342/api/course/searchCourse', body).subscribe((result) => {
      this.courses = result;
    }, err => {
      this.toastr.error('Unable to connect the server');
    });

    SpinnerComponent.hide();
  }

  // Get Dynamic Data
  async getDynamicData(): Promise<void> {
    SpinnerComponent.show();

    this.http.get('https://localhost:44342/api/dynamicHome').subscribe((result) => {
      this.dynamicData = result;      
    }, err => {
      this.toastr.error('Unable to connect the server');
    });

    SpinnerComponent.hide();
  }
  
  // Get Popular Courses Id
  private async getPopularCourses(): Promise<void> {
    SpinnerComponent.show();

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

    SpinnerComponent.hide();
  } 
  
  // Get Exams By Course Id
  async getExamsByCourseId(cid: number) {
    SpinnerComponent.show();

    this.http.post(`https://localhost:44342/api/exam/getExamsByCourseId/${cid}`, null).subscribe((result) => {
      this.exams = result;      
    }, err => {
      this.toastr.error('Unable to connect the server');
    });

    SpinnerComponent.hide();
  }
  
  async getAllServices(){
    SpinnerComponent.show();

    this.http.get('https://localhost:44342/api/OurService').subscribe((result)=>{
        this.ourServiceData = result;
    }, err =>{
       this.toastr.error('Unable to connect the server');
    });

    SpinnerComponent.hide();
  }

  // Search Exam
  async searchExam(body: any) {
    SpinnerComponent.show();

    this.http.post('https://localhost:44342/api/exam/searchExam', body).subscribe((result) => {
      this.exams = result;
    });

    SpinnerComponent.hide();
  }

  // Get Users Buy The Exam Id
  async GetUsersBuyExamId(exid: number): Promise<void> {
    SpinnerComponent.show();

    this.http.post(`https://localhost:44342/api/exam/GetUsersBuyExamId/${exid}`, null).subscribe((result) => {
      this.usersBuyExam = result;
    });

    SpinnerComponent.hide();
  }

  // Get Number Of Users Buy Exam By Exam Id
  async GetNumberOfUsersBuyByExamId(exid: number): Promise<void> {
    SpinnerComponent.show();

    this.http.post(`https://localhost:44342/api/exam/GetNumberOfUsersBuyByExamId/${exid}`, null).subscribe((result) => {
      this.numberOfUsersBuyExam = result;      
    }, err => {
      this.toastr.error('Unable to connect sever.')
    });

    SpinnerComponent.hide();
  }

  //To get info for user he just login
  async getUserByUserName() {
      SpinnerComponent.show();

      let user: any = localStorage.getItem('user');
      user = JSON.parse(user);
      let searchBody = {
        username: user.unique_name
      };

      this.http.post('https://localhost:44342/api/Account/SearchAccount', searchBody).subscribe((result: any) => {
      this.selectedUser = result;
    },
    (error) => {
        this.toastr.error(error.message)
    });
    
    SpinnerComponent.hide();
  }
// Get Testimonials
   getTestimonials() {
    SpinnerComponent.show();

    this.http.get('https://localhost:44342/api/testimonial').subscribe((result:any) => {
      this.testimonial = result.filter((value:any)=>
        value.status=='ACCEPTED'
      );

    }, err => {
      this.toastr.error(err.message,err.status);
    });

    SpinnerComponent.hide();
  }

  // Create Testimonial
  createTestimonial(test:any) {
    SpinnerComponent.show();
    
    let body:any={message:test.toString(),accountId:this.selectedUser[0].id,status:'PENDING'};
    
    this.http.post('https://localhost:44342/api/testimonial',body).subscribe(async (result) => {
      await delay(1000);
      this.toastr.success('created');

    }, err => {
      this.toastr.error(err.message,err.status);
    });

    SpinnerComponent.hide();
  }
}

function delay(ms: number) {
  return new Promise( resolve => setTimeout(resolve, ms) );
}
