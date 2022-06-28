import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { interval } from 'rxjs';
import { HomeService } from 'src/app/service/home.service';

@Component({
  selector: 'app-exam-card',
  templateUrl: './exam-card.component.html',
  styleUrls: ['./exam-card.component.css']
})
export class ExamCardComponent implements OnInit {
  
  @Input() id!: number;
  @Input() courseId!: number;
  @Input() title!: string;
  @Input() passcode!: string;
  @Input() description!: string;
  @Input() examLevel!: string;
  @Input() successMark!: number;
  @Input() cost!: number;
  @Input() startDate!: Date;
  @Input() endDate!: Date;
  @Input() status!: string;
  @Input() creationDate!: Date;
  @Input() examImage!: string;
  @Input() courseName!: string;

  course: any = [{}];
  timerExam!: string;
  timerStatus: string | undefined;

  constructor(public homeService: HomeService, private router: Router) { 
  }


  ngOnInit(): void {
    this.examTimer();
    this.getExamDuration();
  }
  
  // Return Number Represt Duration of Exam in Minutes
  getExamDuration(): number {
    let startTime = new Date(this.startDate).getTime();
    let endTime = new Date(this.endDate).getTime();

    let durationTime = endTime - startTime;
    let durationMinutes = Math.ceil((durationTime % (1000 * 60 * 60)) / (1000 * 60));    

    return durationMinutes;
  }

  goToExamProfile(exid: number) {
    this.router.navigate([`exam/${exid}`]);
  }

  examTimer(): void {
      
    let startTime = new Date(this.startDate).getTime();
    let endTime = new Date(this.endDate).getTime();
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
      let hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
      let minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
      let seconds = Math.floor((distance % (1000 * 60)) / 1000);
        
      hours += days * 24;
      this.timerExam = hours + ":" + minutes + ":" + seconds;

      if (days == 0 && hours == 0 && minutes == 0 && seconds == 0) {
        clearInterval(timer);
        this.examTimer();
      }
      distance -= 1000;
    }, 1000);
  }

  // Number Of Registered Users
  getNumberOfRegisteredUsers(): number {
    return this.homeService.numberOfUsersBuyExam;
  }

}
