import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { HomeService } from './home.service';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  testimonials: any = [{}];
  CoursesData:any;
  AccountsData:any;

  constructor(
    private http: HttpClient,
    public homeSerivce: HomeService,
    private toastr: ToastrService) { }



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
    this.http.put('https://localhost:44342/api/testimonial', body).subscribe((result) => {
      this.toastr.success('ok')
    }, error => {
      this.toastr.error('error')
    });
  }

  // Delete Testimonial
  DeleteTestimonial(id: number) {
    this.http.delete('https://localhost:44342/api/testimonial/deleteTestimonial/' + id).subscribe((result) => {
      this.toastr.success('rejected')
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
  getAllCourses() {
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
  
}
