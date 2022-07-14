import { UpdateExamComponent } from './update-exam/update-exam.component';
import { AfterViewInit, Component, Input, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { AdminService } from 'src/app/service/admin.service';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';
import { CreateCourseComponent } from './create-course/create-course.component';
declare const $:any;

@Component({
  selector: 'app-admin-courses',
  templateUrl: './admin-courses.component.html',
  styleUrls: ['./admin-courses.component.css']
})
export class AdminCoursesComponent implements OnInit,AfterViewInit {
 
   //This For Update Course Dialog
  @ViewChild('callUpdateDialog') callUpdateDialog!: TemplateRef<any>;
  
  //This For Delete Course Dialog
  @ViewChild('callDeleteDialog') callDeleteDialog!: TemplateRef<any>;

  @Input() CourseNameD: string | undefined;
  
 
  constructor(public adminService: AdminService,private dialog: MatDialog, private toastr: ToastrService) { }
 
  ngAfterViewInit(): void {
    setTimeout(() => {
      $('#dtTable').DataTable({
        pageLength: 5,
        processing: true
    });
    }, 3500);
  }

  ngOnInit(): void {
    SpinnerComponent.show();
    this.adminService.getAllCourses();
    setTimeout(() => {
      SpinnerComponent.hide();
    }, 3500);

  }

  //-------------------------------------------------------
  //For Create Course 
  CreateCourseDialog() {
    const dialogRef = this.dialog.open(CreateCourseComponent);
  }

  //-------------------------------------------------------
  //For Update Course Information
  updateForm: FormGroup = new FormGroup({
    id: new FormControl(),
    courseName: new FormControl('', [Validators.required, Validators.maxLength(30)]),
    description: new FormControl('', Validators.maxLength(300)),
    status: new FormControl('', Validators.required),
    courseImage: new FormControl()
  });

  previous_data: any = {}; // empty obj
  openUpdateDialog(Cid: any, CName: any, CDescription: any, CStatus: any, CImage: any) {
    this.previous_data = {
      id: Cid, 
      courseName: CName, 
      description: CDescription, 
      status: CStatus, 
      courseImage: CImage
    }

    this.updateForm.controls['id'].setValue(this.previous_data.id);
    this.updateForm.controls['status'].setValue(this.previous_data.status);
    this.updateForm.controls['courseImage'].setValue(this.previous_data.courseImage);
    this.dialog.open(this.callUpdateDialog);
  }
  
  updateCourse(img:any) {
    if(img.length == 0){
       this.updateForm.controls['status'].setValue(this.previous_data.status);
      if(this.updateForm.valid){
        this.adminService.updateCourse(this.updateForm.value);
        setTimeout(() => {
          window.location.reload();
        }, 2000); 
      }
      else{
        this.toastr.error('You Must Fill The Fields First');
      }  
    }else{
      let fileToUpload = <File>img[0];
      const formData = new FormData();
      formData.append('file', fileToUpload, fileToUpload.name);

      this.updateForm.controls['status'].setValue(this.previous_data.status);
      if(this.updateForm.valid){
        this.adminService.updateCourseWithImage(this.updateForm.value,formData);
        setTimeout(() => {
          window.location.reload();
        }, 2000); 
      }
      else{
        this.toastr.error('You Must Fill The Fields First');
      }  
    }
  }

  //-------------------------------------------------------
  //Delete Course Dialog
  openDeleteDialog(id: number, cName:string) {
    this.CourseNameD = cName;
    const dialogRef = this.dialog.open(this.callDeleteDialog);

    dialogRef.afterClosed().subscribe((result) => {
      if (result != undefined) {
          if (result == 'yes') {
            this.adminService.DeleteCourse(id);
            setTimeout(() => {
              window.location.reload();
            }, 2000); 
            
          }
      }
    })
  }

  //-------------------------------------------------------
  //Add Exam Dialog
  openAddExamDialog(cid: number) {
    this.adminService.courseId = cid;
    this.dialog.open(UpdateExamComponent);
  }

}
