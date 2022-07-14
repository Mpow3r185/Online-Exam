import { ToastrService } from 'ngx-toastr';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AdminService } from 'src/app/service/admin.service';

@Component({
  selector: 'app-update-exam',
  templateUrl: './update-exam.component.html',
  styleUrls: ['./update-exam.component.css']
})
export class UpdateExamComponent implements OnInit {

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
    courseId: new FormControl(this.adminService.courseId)
  });

  constructor(
    public adminService: AdminService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.adminService.getAllCourses();
  }

  

  saveExam(img: any) {
    let fileToUpload = <File>img[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    let body = this.createForm.value;
    console.log(body);
    
    this.adminService.updateExam(body, formData);    
  }

}
