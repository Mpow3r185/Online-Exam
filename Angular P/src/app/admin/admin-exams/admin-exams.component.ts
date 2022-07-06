import { MatDialog } from '@angular/material/dialog';
import { AdminService } from './../../service/admin.service';
import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import {animate, state, style, transition, trigger} from '@angular/animations';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ThisReceiver } from '@angular/compiler';


@Component({
  selector: 'app-admin-exams',
  templateUrl: './admin-exams.component.html',
  styleUrls: ['./admin-exams.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class AdminExamsComponent implements OnInit {
  
  @ViewChild('callUpdateDialog') callUpdateDialog!: TemplateRef<any>;

  dataSource: any;
  columnsToDisplay = ['courseName', 'title', 'successMark', 'startDate', 'endDate', 'examLevel', 'cost'];
  columnsToDisplayWithExpand = [...this.columnsToDisplay, 'expand'];
  expandedElement: PeriodicElement | null | undefined;
  exam: any = {};
  oldExamData: any = {};

  updateForm = new FormGroup({
    title: new FormControl('', [Validators.required,Validators.maxLength(50)]),
    description: new FormControl('', [Validators.required, Validators.maxLength(150)]),
    examLevel: new FormControl('', Validators.required),
    successMark: new FormControl('', [Validators.required, Validators.max(100), Validators.min(1)]),
    numberOfQuestions: new FormControl('', [Validators.required, Validators.min(1)]),
    cost: new FormControl('', [Validators.required, Validators.min(0)]),
    startDate: new FormControl('',Validators.required),
    endDate: new FormControl('', Validators.required),
    markStatus: new FormControl('', Validators.required),
    status: new FormControl('', Validators.required),
    examImage: new FormControl('',Validators.required),
    zoomMeeting: new FormControl('')
  });

  constructor(
    public adminService: AdminService,
    private dialog: MatDialog
    ) { }

  async ngOnInit(): Promise<void> {
    await this.adminService.getAllExams();
    await delay(2000);
    
    this.dataSource = this.adminService.exams;
  }

    updateExam(exam: any) {
    this.oldExamData = exam;
    this.exam = {...exam};

    this.dialog.open(this.callUpdateDialog);
  }

  saveExam() {
    this.exam['examImage'] = this.exam['examImage'].split('\\').pop();

    this.oldExamData['title'] = this.exam['title'];
    this.oldExamData['description'] = this.exam['description'];
    this.oldExamData['examImage'] = this.exam['examImage'];
    this.oldExamData['status'] = this.exam['status'];
    this.oldExamData['markStatus'] = this.exam['markStatus'];
    this.oldExamData['cost'] = this.exam['cost'];
    this.oldExamData['startDate'] = this.exam['startDate'];
    this.oldExamData['endDate'] = this.exam['endDate'];
    this.oldExamData['zoomMeeting'] = this.exam['zoomMeeting'];
    this.oldExamData['creationDate'] = this.exam['creationDate'];
    this.oldExamData['courseId'] = this.exam['courseId'];
    this.oldExamData['examLevel'] = this.exam['examLevel'];
    this.oldExamData['numberOfQuestions'] = this.exam['numberOfQuestions'];
    this.oldExamData['passcode'] = this.exam['passcode'];
    this.oldExamData['successMark'] = this.exam['successMark'];
    

    this.adminService.updateExam(this.exam);
  }

}

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
  description: string;
}

function delay(ms: number) {
  return new Promise( resolve => setTimeout(resolve, ms) );
}
