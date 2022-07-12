import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import {MatAccordion} from '@angular/material/expansion';
import {animate, state, style, transition, trigger} from '@angular/animations';
import { AdminService } from 'src/app/service/admin.service';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';
import { MatDialog } from '@angular/material/dialog';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-admin-questions',
  templateUrl: './admin-questions.component.html',
  styleUrls: ['./admin-questions.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class AdminQuestionsComponent implements OnInit {
  @ViewChild(MatAccordion) accordion: MatAccordion | any;
  @ViewChild('callUpdateDialog') callUpdateDialog!: TemplateRef<any>;
  @ViewChild('callDeleteDialog') callDeleteDialog!: TemplateRef<any>;


  dataSource :any;
  question: any = {};
  oldQuestionData: any = {};
  oldOptionData:any={};
  columnsToDisplay = ['questionContent', 'type','status', 'score'];
  columnsToDisplayWithExpand = [...this.columnsToDisplay, 'expand'];
  expandedElement: PeriodicElement | null | undefined;
  

  constructor(public adminService:AdminService,
    private dialog: MatDialog, private toastr: ToastrService) { }

  async ngOnInit(): Promise<void> {
    SpinnerComponent.show();
    await this.adminService.getAllCourses();
    await this.adminService.getAllQuestions();
    setTimeout(() => {
      SpinnerComponent.hide();
    }, 3500);
    await delay(2000);
    this.dataSource=this.adminService.questions;
    
  }

  async getExamsByCourseId(id:number): Promise<void>
  {
    await this.adminService.getExamsByCourseId(id);
    await delay(2000);
  }

  async getQuestionsByExamId(id:number): Promise<void>
  {
    await this.adminService.GetQeustionsDetailsByExamId(id);
    
    await delay(2000);
    this.dataSource=this.adminService.questions;
  }

  async getOptionsByQId(question:any): Promise<void>
  {
    this.question = question;
    await this.adminService.GetOptionsWithCorrectAnsByQId(question.id);
    await delay(2000);
    this.dataSource=this.adminService.options;
  }

// Delete Question
deleteQuestion(question: any): void {
  this.question = question;
  this.dialog.open(this.callDeleteDialog);
}

// Submit Delete Question
async submitDeleteQuestion(qid: number) {    
  SpinnerComponent.show();
  
  this.adminService.DeleteQuestion(qid);
  console.log(qid);
  
  
  SpinnerComponent.hide();
  window.location.reload();
}
updateQuestion(question: any) { 
  this.oldQuestionData = question;
  this.question = {...question};
  this.dialog.open(this.callUpdateDialog);
}

updateForm = new FormGroup({
  questionContent: new FormControl(''),
  type: new FormControl(''),
  score: new FormControl(''),
  status: new FormControl(''),
  examId: new FormControl(''),
  optionContent: new FormControl('')

});


saveQuestion() {
  this.oldQuestionData['questionContent'] = this.question['questionContent'];
  this.oldQuestionData['type'] = this.question['type'];
  this.oldQuestionData['status'] = this.question['status'];
  this.oldQuestionData['score'] = this.question['score'];
  this.adminService.UpdateQuestion(this.question);
}

}
export interface PeriodicElement {
  questionContent: string;
  type:string;
  status:string;
  score: number;
  optionContent:string;
}

function delay(ms: number) {
  return new Promise( resolve => setTimeout(resolve, ms) );
}
