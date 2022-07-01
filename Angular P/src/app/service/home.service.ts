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
  isBoughtExam: boolean|any = false;
  examContent: any;

  constructor(
    private http: HttpClient,
    private toastr: ToastrService,
    private dialog: MatDialog
    ) {
      this.run();
    }

  // Call Async Functions
  private async run() {
    await this.getDynamicData();
   }

  // Get Exams
  async getExams(): Promise<void> {
    this.http.get('https://localhost:44342/api/exam').subscribe((result) => { 
      this.exams = result;
    }, error => {
      this.toastr.error('Unable to connect the server.')
    });
  }

  // Get Exam Content
  async getExamContent(exid: number): Promise<void> {
    this.http.post(`https://localhost:44342/api/exam/getExamContent/${exid}`, null).subscribe((result) => {
      this.examContent = result;
      
    }, error => {
      this.toastr.error('Unable to connect the server');
    })
  }

  // Get Exam By Id
  async getExamById(exid: number): Promise<void> {    
    this.http.post(`https://localhost:44342/api/exam/getExamById/${exid}`, null).subscribe((result) => {
      this.exams = result;
      
    }, err => {
      this.toastr.error('Unable to connect the server.');
    })
  }

  // Get Courses
  async getCourses(): Promise<void> {
    this.http.get('https://localhost:44342/api/course').subscribe((result:any) => {
      this.courses = result.filter((value:any)=> value.status=='ENABLE');
    }, err => {
      this.toastr.error('Unable to connect the server');
    });
  }
  
  // Search Course
  async searchCourse(body: any) {
    this.http.post('https://localhost:44342/api/course/searchCourse', body).subscribe((result) => {
      this.courses = result;
    }, err => {
      this.toastr.error('Unable to connect the server');
    });
  }

  // Get Dynamic Data
  async getDynamicData(): Promise<void> {
    this.http.get('https://localhost:44342/api/dynamicHome').subscribe((result) => {
      this.dynamicData = result;      
    }, err => {
      this.toastr.error('Unable to connect the server');
    });
  }
  
  // Get Popular Courses Id
  async getPopularCourses(): Promise<void> {
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
      this.exams = result;      
    }, err => {
      this.toastr.error('Unable to connect the server');
    });
  }
  
  async getAllServices(){
    this.http.get('https://localhost:44342/api/OurService').subscribe((result)=>{
        this.ourServiceData = result;
    }, err =>{
       this.toastr.error('Unable to connect the server');
    });
  }

  // Search Exam
  async searchExam(body: any) {
    this.http.post('https://localhost:44342/api/exam/searchExam', body).subscribe((result) => {
      this.exams = result;
    });
  }

  // Get Users Buy The Exam Id
  async GetUsersBuyExamId(exid: number): Promise<void> {
    this.http.post(`https://localhost:44342/api/exam/getUsersBuyExamId/${exid}`, null).subscribe((result) => {
      this.usersBuyExam = result;
    });
  }

  // Get Number Of Users Buy Exam By Exam Id
  async getNumberOfUsersBuyByExamId(exid: number): Promise<void> {
    this.http.post(`https://localhost:44342/api/exam/GetNumberOfUsersBuyByExamId/${exid}`, null).subscribe((result) => {
      this.numberOfUsersBuyExam = result;
    }, err => {
      this.toastr.error('Unable to connect server.')
    });
  }

  //To get info for user he just login
  async getUserByUserName() {
      let user: any = localStorage.getItem('user');
      user = JSON.parse(user);
      let searchBody = {
        username: user.unique_name
      };

      this.http.post('https://localhost:44342/api/Account/SearchAccount', searchBody).subscribe((result: any) => {
        if(result[0].rolename == 'Student'){
            this.selectedUser = result;
          }
    },
    (error) => {
        this.toastr.error(error.message)
    });
  }
// Get Testimonials
   async getTestimonials() {
    this.http.get('https://localhost:44342/api/testimonial').subscribe((result:any) => {
      this.testimonial = result.filter((value:any)=>
        value.status=='ACCEPTED'
      );

    }, err => {
      this.toastr.error(err.message,err.status);
    });
  }

  // Create Testimonial
  createTestimonial(test:any) {    
    let body: any = {
      message:test.toString(),
      accountId:this.selectedUser[0].id,
      status:'PENDING'
    };
    
    this.http.post('https://localhost:44342/api/testimonial', body).subscribe(async (result) => {
      await delay(1000);
      this.toastr.success('Thank you for your valuable feedback');

    }, err => {
      this.toastr.error(err.message,err.status);
    });
  }

  // Check If User Bought The Exam
  async userIfBoughtExam(body: any) {  
      
    this.http.post('https://localhost:44342/api/exam/CheckIfUserBuyExam', body).subscribe((result) => {
      this.isBoughtExam = result;
      
    }, error => {
      this.toastr.error('Unable to connect a server');
    })
  }
}

function delay(ms: number) {
  return new Promise( resolve => setTimeout(resolve, ms) );
}
