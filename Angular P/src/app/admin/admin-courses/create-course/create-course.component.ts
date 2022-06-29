import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AdminService } from 'src/app/service/admin.service';

@Component({
  selector: 'app-create-course',
  templateUrl: './create-course.component.html',
  styleUrls: ['./create-course.component.css']
})
export class CreateCourseComponent implements OnInit {
  SelectStatus!:string;
 
  constructor(private adminService:AdminService,private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  createForm: FormGroup = new FormGroup({
    courseName: new FormControl('', [Validators.required,Validators.maxLength(30)]),
    description: new FormControl('', Validators.required),
    status: new FormControl('', Validators.required),
    courseImage: new FormControl()
  })


  saveCourse(img:any) {
    //This For Uploaded Image 
    if(img.length === 0){ return;}
    let imageUploaded = <File>img[0];
    const formData = new FormData();
    formData.append('file', imageUploaded, imageUploaded.name);
    
    this.createForm.controls['status'].setValue(this.SelectStatus);
    if(this.createForm.valid){
      
      this.adminService.CreateCourse(this.createForm.value,formData);
      setTimeout(() => {
        window.location.reload();
      }, 2000);  
    }
    else{
      this.toastr.error('You Must Fill The Fields First');
    }
  }

}
