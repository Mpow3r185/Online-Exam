import { MatDialog } from '@angular/material/dialog';
import { CorrectAnswer } from './../../shared/shared/Data/CorrectAnswer';
import { QuestionOption } from './../../shared/shared/Data/QuestionOption';
import { ToastrService } from 'ngx-toastr';
import { SpinnerComponent } from './../../spinner/spinner.component';
import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { AdminService } from 'src/app/service/admin.service';
import { Router } from '@angular/router';
import { QuestionsDetailsDTO } from 'src/app/shared/shared/DTO/questions-details';
import { QuestionExamDTO } from 'src/app/shared/shared/DTO/question-exam';

@Component({
  selector: 'app-admin-questions',
  templateUrl: './admin-questions.component.html',
  styleUrls: ['./admin-questions.component.css']
})
export class AdminQuestionsComponent implements OnInit {

  @ViewChild('callDeleteDialog') callDeleteDialog!: TemplateRef<any>;

  selectedExamId: number|null = null;
  counter: number = 1;
  copy: QuestionsDetailsDTO = new QuestionsDetailsDTO();
  selectedQuestionTodDelete: any;

  constructor(
    public adminService: AdminService,
    private router: Router,
    private toastr: ToastrService,
    private dialog: MatDialog
  ) {
    this.adminService.getQuestionsDetails();
    this.adminService.getAllCourses();
  }

  async ngOnInit(): Promise<void> {
    SpinnerComponent.show();
    await delay(3000);

    for (let questionExam of this.adminService.questionsDetails.questionsExamsDTO) {
      const qid: number = questionExam.questionId as number;
          
      const questionOptions: QuestionOption[] = this.adminService.questionsDetails.questionsOptions.filter((qOp) => qOp.questionId == qid);
      questionExam.options = questionOptions;

      let correctAnswers: CorrectAnswer[] = [];
      if (questionExam.type == 'Fill') {
        correctAnswers.push(questionExam.options[0]);
      } else {

        for (let questionOption of questionOptions) {
          for (let answer of this.adminService.questionsDetails.correctAnswers) {
            if (answer.questionOptionId == questionOption.id) {
              answer.correctanswerContent = questionOption.optionContent;
              correctAnswers.push(answer)
            }
          }
        }
      }
  
      questionExam.correctAnswers = correctAnswers;

    }
    
    await delay(3000);

    for (let questionExam of this.adminService.questionsDetails.questionsExamsDTO) {      
      const questionExamCopy: QuestionExamDTO = new QuestionExamDTO();
      questionExamCopy.correctAnswers = questionExam.correctAnswers;
      questionExamCopy.courseId = questionExam.courseId;
      questionExamCopy.courseName = questionExam.courseName;
      questionExamCopy.examId = questionExam.examId;
      questionExamCopy.options = questionExam.options;
      questionExamCopy.type = questionExam.type;
      questionExamCopy.questionContent = questionExam.questionContent;
      questionExamCopy.score = questionExam.score;
      questionExamCopy.questionId = questionExam.questionId;
      questionExamCopy.status = questionExam.status;
      questionExamCopy.title = questionExam.title;
      this.copy.questionsExamsDTO.push(questionExamCopy);
    }

    this.copy.correctAnswers = this.adminService.questionsDetails.correctAnswers;
    this.copy.questionsOptions = this.adminService.questionsDetails.questionsOptions;    
  
    SpinnerComponent.hide();
  }

  moveToCreateExamQuestions(): void {
    if (this.selectedExamId) {
      this.router.navigate([`/admin/createQuestions/${this.selectedExamId}`]);
    } else {
      this.toastr.error('Choose Course And Exam');
    }
    
  }

  async getExamsCourse(courseId: number): Promise<void> {
    if (courseId == -1) {
      this.adminService.questionsDetails.questionsExamsDTO = this.copy.questionsExamsDTO;
      this.adminService.questionsDetails.correctAnswers = this.copy.correctAnswers;
      this.adminService.questionsDetails.questionsOptions = this.copy.questionsOptions;
      return;
    }
    
    SpinnerComponent.show();
    await delay(2000);

    this.adminService.questionsDetails.questionsExamsDTO = this.copy.questionsExamsDTO.filter(questionExam => questionExam.courseId == courseId);
    this.adminService.questionsDetails.correctAnswers = this.copy.correctAnswers;
    this.adminService.questionsDetails.questionsOptions = this.copy.questionsOptions;    
    
    this.adminService.getExamsByCourseId(courseId);
    
    await delay(2500);

    SpinnerComponent.hide();
  }
  
  async updateExamId(exid: number): Promise<void> {
    SpinnerComponent.show();

    this.selectedExamId = exid;

    this.adminService.questionsDetails.questionsExamsDTO = this.copy.questionsExamsDTO.filter((questionExam) => questionExam.examId == exid);
    await delay(2000);
    SpinnerComponent.hide();
  }


  currentExpandRowNum: any = null;

  handleExpand(rowNum: any) {
    if (this.currentExpandRowNum == rowNum) {
        this.closeExpand(rowNum);
    } else {
        if (this.currentExpandRowNum != null) {
            this.closeExpand(this.currentExpandRowNum);
        }
        this.openExpand(rowNum);
    }
  }

  openExpand(rowNum: any) {
    document.querySelectorAll('.row-element')[rowNum].classList.add('expanded');
    document.querySelectorAll('.row-element')[rowNum].classList.remove('cus-bottom-border');
    document.querySelectorAll('.row-details')[rowNum].classList.remove('display-none');
    (<HTMLElement>document.querySelectorAll('.row-details')[rowNum]).style.height = `${document.querySelectorAll('.row-details td')[rowNum].clientHeight}px`;
    (<HTMLElement>document.querySelectorAll('.details-container')[rowNum]).style.transform = 'translateY(0)';

    this.currentExpandRowNum = rowNum; 
  }

  closeExpand(rowNum: any) {
    document.querySelectorAll('.row-element')[rowNum].classList.remove('expanded');
    document.querySelectorAll('.row-element')[rowNum].classList.add('cus-bottom-border');
    (<HTMLElement>document.querySelectorAll('.row-details')[rowNum]).style.height = '0px';
    (<HTMLElement>document.querySelectorAll('.details-container')[rowNum]).style.transform = 'translateY(-110%)';
    document.querySelectorAll('.row-details')[rowNum].classList.add('display-none');

    this.currentExpandRowNum = null;
  }

  deleteQuestion(question: QuestionExamDTO) {
    this.selectedQuestionTodDelete = question;
    this.dialog.open(this.callDeleteDialog);
  }

}


function delay(ms: number) {
  return new Promise( resolve => setTimeout(resolve, ms) );
}
