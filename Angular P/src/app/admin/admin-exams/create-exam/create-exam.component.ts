import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AdminService } from 'src/app/service/admin.service';

@Component({
  selector: 'app-create-exam',
  templateUrl: './create-exam.component.html',
  styleUrls: ['./create-exam.component.css']
})
export class CreateExamComponent implements OnInit {

  selectStatus!:string;
  selectMarkStatus!: string;
  selectExamLevel!: string;

  createForm: FormGroup = new FormGroup({
    title: new FormControl('', [Validators.required,Validators.maxLength(50)]),
    description: new FormControl('', [Validators.required, Validators.maxLength(150)]),
    examLevel: new FormControl('', Validators.required),
    successMark: new FormControl('', [Validators.required, Validators.max(100), Validators.min(0)]),
    numberOfQuestions: new FormControl('', [Validators.required, Validators.min(1)]),
    cost: new FormControl('', [Validators.required, Validators.min(0)]),
    startDate: new FormControl('', Validators.required),
    endDate: new FormControl('', Validators.required),
    markStatus: new FormControl('', Validators.required),
    status: new FormControl('', Validators.required),
    examImage: new FormControl('', Validators.required),
    zoomMeeting: new FormControl(''),
    courseId: new FormControl('', Validators.required),
  });

  constructor(
    public adminService:AdminService,
    private toastr: ToastrService) {}

  ngOnInit(): void {
    this.adminService.getAllCourses();
  }

  async saveExam(img: any) {    
    let fileToUpload = <File>img[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    
    
    let body: any = this.createForm.value;
    body['status'] = this.createForm.controls['status'].value;
    body['markStatus'] = this.createForm.controls['markStatus'].value;
    body['examLevel'] = this.createForm.controls['examLevel'].value
    body['courseId'] = Number(this.createForm.controls['courseId'].value.split('/')[0]);
    body['examImage'] = body['examImage'].split('\\').pop();
    body['courseName'] = this.createForm.controls['courseId'].value.split('/')[1];
    this.adminService.createExam(body, formData);
    this.adminService.exams.push(body);
  }

}


function delay(ms: number) {
  return new Promise( resolve => setTimeout(resolve, ms) );
}