import { SpinnerComponent } from './../../../spinner/spinner.component';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { HomeService } from 'src/app/service/home.service';

@Component({
  selector: 'app-exam-profile',
  templateUrl: './exam-profile.component.html',
  styleUrls: ['./exam-profile.component.css']
})
export class ExamProfileComponent implements OnInit {

  isExpanded: boolean = true;
  timerExam!: string;
  timerStatus: string | undefined;
  private routeSub!: Subscription;

  constructor(
    public homeService: HomeService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  async ngOnInit() {
    SpinnerComponent.show();

    this.routeSub = this.route.params.subscribe(async params => {
      await this.homeService.getExamById(Number(params['id']));
      await this.homeService.getNumberOfUsersBuyByExamId(Number(params['id']));
      
      this.homeService.userIfBoughtExam({
        examId: Number(params['id']),
        accountId: Number(localStorage.getItem('AccountId'))
      });      
    });

    await delay(1000);    
    
    SpinnerComponent.hide();

    this.examTimer();
    this.getExamDuration();
  }

  async examTimer() {
    SpinnerComponent.show();
    await delay(1000);
    SpinnerComponent.hide();

    let startTime = new Date(this.homeService.exams.startDate).getTime();
    let endTime = new Date(this.homeService.exams.endDate).getTime();
    let nowTime: number = new Date().getTime();

    if (startTime < nowTime && endTime < nowTime) {
      this.timerStatus = undefined;
      this.timerExam = 'EXPIRED';      
    } else if (startTime < nowTime && endTime > nowTime) {
      this.timerStatus = "ENDS AFTER";
      this.timerFunc(endTime - nowTime);
    } else {
      this.timerStatus = "START AFTER";
      this.timerFunc(startTime - nowTime);
    }    
  }
  
  timerFunc(distance: number) {
    let timer = setInterval(() => {
      let days = Math.floor(distance / (1000 * 60 * 60 * 24));
      let hours: string|number = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
      let minutes: string|number = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
      let seconds: string|number = Math.floor((distance % (1000 * 60)) / 1000);
        
      hours += days * 24;

      if (days == 0 && hours == 0 && minutes == 0 && seconds == 0) {
        clearInterval(timer);
        this.examTimer();
      }

      
      if (hours < 10) { hours = `0${hours}`; }
      if (minutes < 10) { minutes = `0${minutes}`; }
      if (seconds < 10) { seconds = `0${seconds}`; }
      
      this.timerExam = hours + ":" + minutes + ":" + seconds;

      
      distance -= 1000;
    }, 1000);
  }

  expandExamInformation(): void {
    this.isExpanded = !this.isExpanded;
    if (this.isExpanded) {
        document.getElementById('expandInf')!.style.transform = 'rotate(0deg)';
        document.getElementById('examInfContainer')!.style.transform = 'translateX(0)';
    } else {
        document.getElementById('expandInf')!.style.transform = 'rotate(180deg)';
        document.getElementById('examInfContainer')!.style.transform = 'translateX(-100%)';
    }
  }

  // Return Number Represt Duration of Exam in Minutes
  getExamDuration(): number {
    let startTime = new Date(this.homeService.exams.startDate).getTime();
    let endTime = new Date(this.homeService.exams.endDate).getTime();

    let durationTime = endTime - startTime;
    let durationMinutes = Math.ceil((durationTime % (1000 * 60 * 60)) / (1000 * 60));

    return durationMinutes;
  }

  // Number Of Registered Users
  getNumberOfRegisteredUsers(): number {
    return this.homeService.numberOfUsersBuyExam;
  }

  moveToExam() {
    this.router.navigate([`exam/${this.homeService.exams.id}`])
  }

  // Unsubscribe to prevent memory leaks
  ngOnDestroy() {
    this.routeSub.unsubscribe();
  }
}

function delay(ms: number) {
  return new Promise( resolve => setTimeout(resolve, ms) );
}