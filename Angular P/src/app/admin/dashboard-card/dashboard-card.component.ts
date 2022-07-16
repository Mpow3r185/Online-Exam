import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/service/admin.service';
import { HomeService } from 'src/app/service/home.service';
import { ExamFilter } from 'src/app/shared/shared/DTO/exam-filter';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';

@Component({
  selector: 'app-dashboard-card',
  templateUrl: './dashboard-card.component.html',
  styleUrls: ['./dashboard-card.component.css']
})
export class DashboardCardComponent implements OnInit {
  numOfUser!: number;
  numOfCourse!: number;
  numOfExam!: number;
  
  days?: Date[];
  currentDay: number = new Date().getDate();
  numOfQuestion!: number;

  lastFiveUser:any;
  lastFiveCourse:any;
  lastFiveExam:any;

  constructor(
    public homeService: HomeService,
    public adminService: AdminService) { 
        this.getNumberOfDaysInCurrentMonth();
    }

  ngOnInit(): void {
    SpinnerComponent.show();
    this.adminService.getAllCourses();
    this.adminService.getAllAccounts();
    this.adminService.getAllExams();
 this.adminService.getQuestions();

    setTimeout(() => {
      this.numOfUser = this.adminService.AccountsData.length;
      this.numOfCourse = this.adminService.CoursesData.length;
      this.numOfExam = this.adminService.exams.length;
       this.numOfQuestion = this.adminService.Allquestions.length;

      this.lastFiveUser = this.adminService.AccountsData.slice(Math.max(this.numOfUser - 5, 1));
      this.lastFiveCourse = this.adminService.CoursesData.slice(Math.max(this.numOfCourse - 5, 1));
      this.lastFiveExam = this.adminService.exams.slice(Math.max(this.numOfExam - 5, 1));

    }, 4000);

    setTimeout(() => {
      SpinnerComponent.hide();
    }, 3500);
    
  }

  async getNumberOfDaysInCurrentMonth(): Promise<void> {
    let year: number = new Date().getFullYear();
    let month: number = new Date().getMonth();

    this.days = Array(new Date(year, month, 0).getDate());

    for(let i=0; i<this.days.length; i++) {
        this.days[i] = new Date(year, month, i+1);
    }
  }
}

function delay(ms: number) {
    return new Promise( resolve => setTimeout(resolve, ms) );
  }
  
