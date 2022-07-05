import { Component, OnInit } from '@angular/core';
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


  constructor(
    private adminService:AdminService,
    private toastr: ToastrService) {      
     }

  ngOnInit(): void {
  }

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
    zoomMeeting: new FormControl('')
  });

  saveExam() {
    let body: any = this.createForm.value;
    body['status'] = this.selectStatus;
    body['markStatus'] = this.selectMarkStatus;
    body['examLevel'] = this.selectExamLevel;
    body['courseId'] = this.adminService.courseId;
    body['examImage'] = body['examImage'].split('\\').pop();
    
    this.adminService.createExam(body);
    
  }

}
