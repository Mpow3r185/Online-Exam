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
/*
    if (this.description.length > 120) {
      this.description = this.description.substring(0, 120) + '...';
    }*/

    this.examTimer();
    
  }

  goToExamProfile(exid: number) {
    this.router.navigate([`exam/${exid}`]);
  }

  /*getExamDuration() {
    let stDate = new Date(this.startDate).getTime();
      let enDate = new Date(this.endDate).getTime();
    let interval = setInterval(() => {
      
  
      let distance = enDate - stDate;
  
      var days = Math.floor(distance / (1000 * 60 * 60 * 24));
      var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
      var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
      var seconds = Math.floor((distance % (1000 * 60)) / 1000);
  
      console.log(days + "d " + hours + "h "
      + minutes + "m " + seconds + "s Duration");
  
  
      let now = new Date().getTime();
  
      distance = stDate - now;
  
      var days = Math.floor(distance / (1000 * 60 * 60 * 24));
      var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
      var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
      var seconds = Math.floor((distance % (1000 * 60)) / 1000);
  
      console.log(days + "d " + hours + "h "
      + minutes + "m " + seconds + "s To Start");

      if (days == 0 && hours == 0 && minutes == 0 && seconds == 0) {
        clearInterval(interval);
      } 
    }, 1000);
    
    setInterval(() => {
      let distance = enDate - stDate;
  
      var days = Math.floor(distance / (1000 * 60 * 60 * 24));
      var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
      var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
      var seconds = Math.floor((distance % (1000 * 60)) / 1000);
  
      console.log(days + "d " + hours + "h "
      + minutes + "m " + seconds + "s To End");

      enDate -= 1000;
      
    }, 1000);

    


    
    console.log(enDate.getFullYear() - stDate.getFullYear());
    console.log(enDate.getMonth() - stDate.getMonth());
    console.log(enDate.getDay() - stDate.getDay());
    console.log(enDate.getHours() - stDate.getHours());
    console.log(enDate.getMinutes() - stDate.getMinutes());
    console.log(enDate.getSeconds() - stDate.getSeconds());
    
    return ;
  }*/

  examTimer(): string {
      
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
    return '';
  }

  timerFunc(distance: number) {
    let timer = setInterval(() => {
      var days = Math.floor(distance / (1000 * 60 * 60 * 24));
      var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
      var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
      var seconds = Math.floor((distance % (1000 * 60)) / 1000);
      
      hours += days * 24;

      this.timerExam = hours + ":" + minutes + ":" + seconds;

      if (days == 0 && hours == 0 && minutes == 0 && seconds == 0) {
        clearInterval(timer);
        this.examTimer();
      }

      distance -= 1000;
    }, 1000);
  }

}
