import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { HomeService } from './home.service';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';
import { renderFlagCheckIfStmt } from '@angular/compiler/src/render3/view/template';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  testimonials: any = [{}];
  CoursesData:any;
  AccountsData:any;
  fullUserDetails:any=[{}];
  account: any;
  NumOfUsers:any;
  TotalCertificates:any;
  FailUsers:any;
  courseId!: number;
  exams: any;
  zoomMeeting: any;

  constructor(
    private http: HttpClient,
    public homeSerivce: HomeService,
    private toastr: ToastrService) { }



//--------------------------------------------------------
//--  CRUD Operation for Table Testimonial except Create
//--------------------------------------------------------


  // Get Testimonial
  async getTestimonials() {
   
    this.http.get('https://localhost:44342/api/testimonial').subscribe((result) => {
      this.testimonials = result;
    }, error => {
      this.toastr.error('Unable to connect the server.')
    });

  }

  // update Testimonial
  updateTestimonial(body: any) {
    SpinnerComponent.show();
    this.http.put('https://localhost:44342/api/testimonial', body).subscribe((result) => {
    }, error => {
      this.toastr.error('error')
    });
  }

  // Delete Testimonial
  DeleteTestimonial(id: number) {
    SpinnerComponent.show();
    this.http.delete('https://localhost:44342/api/testimonial/deleteTestimonial/' + id).subscribe((result) => {
    this.toastr.success('Testimonial Deleted Successfully.');
    }, error => {
      this.toastr.error('error')
    });
  }
  
  
//--------------------------------------------------------
//--  CRUD Operation for Table Course
//--------------------------------------------------------

  /*
  *  Get All Courses
  */
  async getAllCourses() {
    this.http.get('https://localhost:44342/api/course').subscribe((result) => {            
      this.CoursesData = result;      
    }, error => {
      this.toastr.error('Unable to connect the server.');
      this.toastr.error(error.message,error.status);
    });
  }

  /*
  * Create Course
  */
  CreateCourse(body:any,img:FormData) {
    SpinnerComponent.show();
    this.http.post('https://localhost:44342/api/course/Upload', img).subscribe((ResultImage: any) => {
     
      //This To add Course
      body.courseImage = ResultImage.courseImage;
      this.http.post('https://localhost:44342/api/course', body).subscribe((result) => { 
        this.toastr.success('Course Created Successfully.');   
      }, error => {
      this.toastr.error('Unable to connect the server.');
      SpinnerComponent.hide();
      });  

    }, err => {
      console.log(err);
      SpinnerComponent.hide();
    })

    
  }

  /**
   *  Update Course
   */

  //Update Course When he dose't uploaded an Image 
   updateCourse(body: any) {
    SpinnerComponent.show();
      this.http.put('https://localhost:44342/api/course', body).subscribe((res) => { 
        this.toastr.success("Course Updated Successfully")
      }, err => {
        this.toastr.error("Unable to connect the server.");
        SpinnerComponent.hide();
      })   
  }

   //Update Course When he uploaded an Image 
  updateCourseWithImage(body: any, img:FormData) {
    SpinnerComponent.show();
      this.http.post('https://localhost:44342/api/course/Upload', img).subscribe((ResultImage: any) => {
        
        body.courseImage = ResultImage.courseImage;
        this.http.put('https://localhost:44342/api/course', body).subscribe((res) => { 
           this.toastr.success("Course Updated Successfully")
        }, err => {
          this.toastr.error("Unable to connect the server.");
          SpinnerComponent.hide();
        })
        
      }, err => {
        console.log(err);
        SpinnerComponent.hide();
      })  
  }


  /*
  * Delete Course
  */
  DeleteCourse(id:number) {
    SpinnerComponent.show();
    this.http.delete(`https://localhost:44342/api/course/DeleteCourse/${id}`).subscribe((result) => { 
      this.toastr.success('Course Deleted Successfully.');
    }, error => {
      this.toastr.error('Unable to connect the server.');
      SpinnerComponent.hide();
    });
  }


//--------------------------------------------------------
//--  CRUD Operation for Table Account
//--------------------------------------------------------

 /*
  *  Get All Courses
  */
 getAllAccounts() {
  this.http.get('https://localhost:44342/api/account').subscribe((result) => {            
    this.AccountsData = result;      
  }, error => {
    this.toastr.error('Unable to connect the server.');
    this.toastr.error(error.message,error.status);
  });
}


/**
*  Update Account
*/
 updateAccount(body: any) {
  SpinnerComponent.show();
 
  this.http.put('https://localhost:44342/api/account', body).subscribe((res) => { 
      this.toastr.success('Account Update Successfully');
  }, err => {
    this.toastr.error("Unable to connect the server.");
    SpinnerComponent.hide();
  })
}
  
  // Get full User Details By Id
async getFullUserDetailsById(accId: number): Promise<void> {
  SpinnerComponent.show();  
  this.http.post(`https://localhost:44342/api/report/stdDetails/${accId}`, null).subscribe((result) => {
    this.fullUserDetails = result;
  }, err => {
    this.toastr.error('Unable to connect the server.')
  })

  SpinnerComponent.hide();
}

async getAccountById(accId: number): Promise<void>{
  this.http.post(`https://localhost:44342/api/Account/getAccountById/${accId}`, null).subscribe((result) => {
    this.account = result;
    console.log(result);
    
  }, error => {
    this.toastr.error('Unable to connect the server');
  });
}


//Get Number of Users
 getNumOfUsers()
 {
   this.http.get('https://localhost:44342/api/report/NumberOfUsers').subscribe((result) => {            
     this.NumOfUsers = result;      
   }, error => {
     this.toastr.error('Unable to connect the server.');
     this.toastr.error(error.message,error.status);
   });
 }

 //Get Number of Users
 getNumOfCertificates()
 {
   this.http.get('https://localhost:44342/api/report/NumberOfCertificates').subscribe((result) => {            
     this.TotalCertificates = result;      
   }, error => {
     this.toastr.error('Unable to connect the server.');
     this.toastr.error(error.message,error.status);
   });
 }

 //Get Number of Fail Users
 getNumOfFailUsers()
 {
   this.http.get('https://localhost:44342/api/report/NumberOfFailUsers').subscribe((result) => {            
     this.FailUsers = result;      
   }, error => {
     this.toastr.error('Unable to connect the server.');
     this.toastr.error(error.message,error.status);
   });
 }
  
  

//--------------------------------------------------------
//--  CRUD Operation for Table Service
//--------------------------------------------------------

/**
*  Create Service
*/
CreateServices(body:any){
  SpinnerComponent.show();
  this.http.post('https://localhost:44342/api/OurService',body).subscribe((result)=>{
    this.toastr.success('Service Created Successfully');     
  },err =>{
    SpinnerComponent.hide();
    console.log(err.message,err.status);
     this.toastr.error('Unable to connect the server');
  })
}

/**
*  Update Service
*/
UpdateServices(body:any){
  SpinnerComponent.show();
  this.http.put('https://localhost:44342/api/OurService',body).subscribe((result)=>{
    this.toastr.success('Service Updated Successfully');
  },err =>{
    console.log(err.message,err.status);
    SpinnerComponent.hide();
     this.toastr.error('Unable to connect the server');
  })
}

/**
*  Delete Service
*/
DeleteServices(id:number){
  SpinnerComponent.show();
  this.http.delete(`https://localhost:44342/api/OurService/DeleteService/${id}`).subscribe((result)=>{
    this.toastr.success('Service Deleted Successfully');
  },err =>{
    console.log(err.message,err.status);
    SpinnerComponent.hide();
     this.toastr.error('Unable to connect the server');
  })
}


// Create Exam
createExam(body: any) {
  console.log(body);

  let zoomMeetingLink = body['zoomMeeting'];
  delete body['zoomMeeting'];
  
  this.http.post('https://localhost:44342/api/exam', body).subscribe((result) => {
    
    const searchBody: object = 
    { 
      exTitle: body.title,
      stDate: body.startDate,
      enDate: body.endDate,
      price: body.cost
    };
    this.http.post('https://localhost:44342/api/exam/searchExam', searchBody).subscribe((result: any) => {
      const exam = result[0];
      const zoomMeetingBody: object = {
        zoomLink: zoomMeetingLink,
        examId: exam.id
      };

      this.http.post(`https://localhost:44342/api/zoomMeeting`, zoomMeetingBody).subscribe((result) => {
        this.toastr.success("Created Exam Successfully");
      })
    }, error => {
      this.toastr.error('Unable to connect server');
    })
   }, error => {
    this.toastr.error(error.message);
  })
}

 //Update Course When he uploaded an Image 
updateExamWithImage(body: any, img:FormData) {
  SpinnerComponent.show();
    this.http.post('https://localhost:44342/api/exam/Upload', img).subscribe((ResultImage: any) => {
      
      body.examImage = ResultImage.examImage;
      this.http.put('https://localhost:44342/api/exam', body).subscribe((res) => { 
         this.toastr.success("Exam Updated Successfully")
      }, err => {
        this.toastr.error("Unable to connect the server.");
        SpinnerComponent.hide();
      })
      
    }, err => {
      console.log(err);
      SpinnerComponent.hide();
    })  
}

// Get All Exams
async getAllExams(): Promise<void> {
  this.http.get('https://localhost:44342/api/exam').subscribe((result) => {
    this.exams = result;
  }, error => {
    this.toastr.error('Unable to connect server');
  });
}

DeleteExam(id:number) {
  this.http.delete(`https://localhost:44342/api/exam/DeleteExam/${id}`).subscribe((result) => { 
    this.toastr.success('Exam Deleted Successfully.');
  }, error => {
    this.toastr.error('Unable to connect the server.');
  });
}


// Update Exam
updateExam(body: any) {
  
  const zoomLink = body['zoomMeeting'];
  delete body['zoomMeeting'];
  
  if (zoomLink == undefined || zoomLink == '') {
    this.http.put('https://localhost:44342/api/exam', body).subscribe((result) => {
      this.toastr.success('Exam updated successfully');
    }, error => {
      this.toastr.error('Unable to connect server');
    });
  }

  else {
    this.http.put('https://localhost:44342/api/exam', body).subscribe(async (result) => {
    this.toastr.success('Exam updated successfully');

    SpinnerComponent.show();
    await this.getZoomMeetingLinkByExamId(body.id);
    await delay(1500);
    SpinnerComponent.hide();
    
    const zoomMeetingBody: object = {
      zoomLink: zoomLink,
      examId: body.id
    };
    if(this.zoomMeeting) {
      this.http.put('https://localhost:44342/api/zoomMeeting', zoomMeetingBody).subscribe((result) => {
        this.toastr.success('Zoom link is updated');
      });
    }

    else {
      this.http.post('https://localhost:44342/api/zoomMeeting', zoomMeetingBody).subscribe((result) => {
        this.toastr.success('Zoom link is created');
      });
    }
    
  }, error => {
    this.toastr.error('Unable to connect server');
  });
  }
}

// Get Zoom Meeting Link By Exam Id
async getZoomMeetingLinkByExamId(exid: number) {
  this.http.post(`https://localhost:44342/api/zoomMeeting/GetZoomMeetingByExamId/${exid}`, null).subscribe((result) => {
    this.zoomMeeting = result;
  }, error => {
    this.toastr.error('Unable to connect server');
  });
}

}

function delay(ms: number) {
  return new Promise( resolve => setTimeout(resolve, ms) );
}
