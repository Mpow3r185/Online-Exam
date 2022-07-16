import { CorrectAnswer } from './../../shared/shared/Data/CorrectAnswer';
import { QuestionOption } from './../../shared/shared/Data/QuestionOption';
import { ToastrService } from 'ngx-toastr';
import { SpinnerComponent } from './../../spinner/spinner.component';
import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/service/admin.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-questions',
  templateUrl: './admin-questions.component.html',
  styleUrls: ['./admin-questions.component.css']
})
export class AdminQuestionsComponent implements OnInit {

  selectedExamId: number|null = null;
  counter: number = 1;

  constructor(
    public adminService: AdminService,
    private router: Router,
    private toastr: ToastrService
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

      const correctAnswers: CorrectAnswer[] = this.adminService.questionsDetails.correctAnswers.filter((correctAnw) => (questionOptions.find((a) => a.id == correctAnw.questionOptionId)) ? true : false );

      questionExam.correctAnswers = correctAnswers;          
    }

    await delay(3000);
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
    SpinnerComponent.show();

    this.adminService.getExamsByCourseId(courseId);
    await delay(500);

    SpinnerComponent.hide();
  }
  
  updateExamId(exid: number): void {
    this.selectedExamId = exid;
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
    console.log(this.adminService.questionsDetails);
  }

  closeExpand(rowNum: any) {
    document.querySelectorAll('.row-element')[rowNum].classList.remove('expanded');
    document.querySelectorAll('.row-element')[rowNum].classList.add('cus-bottom-border');
    (<HTMLElement>document.querySelectorAll('.row-details')[rowNum]).style.height = '0px';
    (<HTMLElement>document.querySelectorAll('.details-container')[rowNum]).style.transform = 'translateY(-110%)';
    document.querySelectorAll('.row-details')[rowNum].classList.add('display-none');

    this.currentExpandRowNum = null;
  }

  resetCounter(): void {
    this.counter = 1;
  }

  increaseCounter(): void {
    this.counter++;
  }

}


function delay(ms: number) {
  return new Promise( resolve => setTimeout(resolve, ms) );
}