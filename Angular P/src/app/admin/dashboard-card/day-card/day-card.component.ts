import { HomeService } from 'src/app/service/home.service';
import { Component, Input, OnInit } from '@angular/core';
import { ExamFilter } from 'src/app/shared/shared/DTO/exam-filter';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';
import { AdminService } from 'src/app/service/admin.service';
import { Exam } from 'src/app/shared/shared/Data/Exam';

@Component({
  selector: 'app-day-card',
  templateUrl: './day-card.component.html',
  styleUrls: ['./day-card.component.css']
})
export class DayCardComponent implements OnInit {

  @Input() dayNumber!: number;
  @Input() isToday!: boolean;
  @Input() date!: Date;

  exams: ExamCalender[] = [];
  eventsContainer!: Node;

  constructor(
    public adminService: AdminService
  ) { }

  async ngOnInit(): Promise<void> {
    SpinnerComponent.show();
    await delay(2000);

    this.date.setHours(24);
    let endDate = this.date;
    this.date.setHours(-24);
    
    let todayExams: any = [];
    for (let exam of this.adminService.exams) {      
      let examStartDate = new Date(exam.startDate);
      let examEndDate = new Date(exam.endDate);

      let isStartInDay: boolean = examStartDate.getFullYear() == this.date.getFullYear() && examStartDate.getMonth() == this.date.getMonth() && examStartDate.getDate() == this.date.getDate();
      let isEndInDay: boolean = examEndDate.getFullYear() == endDate.getFullYear() && examEndDate.getMonth() == endDate.getMonth() && examEndDate.getDate() == endDate.getDate();

      if (isStartInDay || isEndInDay) {
        
        // Create Exam Object
        const ex = new Exam();
        ex.cost = exam.cost;
        ex.courseId = exam.courseId;
        ex.courseName = exam.courseName;
        ex.creationDate = exam.creationDate;
        ex.description = exam.description;
        ex.endDate = exam.endDate;
        ex.startDate = exam.startDate;
        ex.examImage = exam.examImage;
        ex.examLevel = exam.examLevel;
        ex.id = exam.id;
        ex.markStatus = exam.markStatus;
        ex.numberOfQuestions = exam.numberOfQuestions;
        ex.passcode = exam.passcode;
        ex.status = exam.status;
        ex.successMark = exam.successMark;
        ex.title = exam.title;

        this.exams.push(new ExamCalender(ex, this.dayNumber));
      }
    }

    const dayCard = document.querySelectorAll('.day-card')[this.dayNumber-1];
    const container = dayCard.getElementsByClassName('container')[1];

    for (let exam of this.exams) {
        
        const circle = document.createElement('i');
        circle.classList.add('fa');
        circle.classList.add('fa-circle');
        circle.classList.add('pl-1');        

        if (exam.examCalenderStatus == ExamCalenderStatus.Start) {
            circle.classList.add('start');
        } else if (exam.examCalenderStatus == ExamCalenderStatus.Expired) {
            circle.classList.add('end');
        } else {
            circle.classList.add('not-start');
        }
        
        container.appendChild(circle);
      }
      this.f();
    
      SpinnerComponent.hide();
  }

  openCalendar(n: number): void {
    let afterCardNumber = this.getApproriateLocationForDiv(n);

    const dayCard = document.getElementsByTagName('app-day-card')[afterCardNumber+1];
    const CalendarContainer = document.getElementById('calendarContainer');

    const startCont = CalendarContainer?.children;
    for (let i=0; i<startCont!.length; i++) {        
        if (startCont![i].tagName.toString() == 'DIV') {
            CalendarContainer!.removeChild(startCont![i]);
        }
    }    

    if (this.eventsContainer){
        CalendarContainer?.insertBefore(this.eventsContainer, dayCard);
    }
    
  }

  f() {
    const divContainer = document.createElement('div');
    const CalendarContainer = document.getElementById('calendarContainer');
    let pointer = 0;
    for (let exam of this.exams) {

        const eventContainer = document.createElement('div');
        eventContainer.classList.add('font-weight-bolder');
        eventContainer.classList.add('white-color');
        eventContainer.classList.add('py-3');

        eventContainer.style.width = '1050px';
        eventContainer.style.borderBottom = '3px solid #fff';

        if (pointer == this.exams.length-1) {
            eventContainer.classList.add('mb-5')
        }
        pointer++;

        if (exam.examCalenderStatus == ExamCalenderStatus.Expired) {
            eventContainer.classList.add('end');
        } else if (exam.examCalenderStatus == ExamCalenderStatus.Start) {
            eventContainer.classList.add('start');
        } else {
            eventContainer.classList.add('not-start');
        }

        const row1 = document.createElement('div');
        row1.classList.add('row');
        row1.classList.add('justify-content-around');

        const dayNumberContainer = document.createElement('div');
        dayNumberContainer.classList.add('col-1');

        const dayNumberRow = document.createElement('div');
        dayNumberRow.classList.add('row');
        dayNumberRow.classList.add('pl-5');
        dayNumberRow.classList.add('py-2');
        dayNumberRow.innerText = `${this.dayNumber}`;

        dayNumberContainer.appendChild(dayNumberRow);
        row1.appendChild(dayNumberContainer);

        // Start At
        const startAtContainer = document.createElement('div');
        startAtContainer.classList.add('col-12');
        startAtContainer.classList.add('col-sm-12');
        startAtContainer.classList.add('col-md-12');
        startAtContainer.classList.add('col-lg-4');
        startAtContainer.classList.add('col-xl-4');

        const startAtRow = document.createElement('div');
        startAtRow.classList.add('row');
        startAtRow.classList.add('px-3');
        startAtRow.classList.add('py-2');

        const startAtLabel = document.createElement('div');
        startAtLabel.classList.add('col-5');
        startAtLabel.classList.add('text-center');
        startAtLabel.innerText = 'Start At';


        const startAtValue = document.createElement('div');
        startAtValue.classList.add('col-7');
        startAtValue.classList.add('text-center');
        startAtValue.innerText = `${exam.startAtValue}`;

        startAtRow.appendChild(startAtLabel);
        startAtRow.appendChild(startAtValue);
        startAtContainer.appendChild(startAtRow);
        row1.appendChild(startAtContainer);

        // End At
        const endAtContainer = document.createElement('div');
        endAtContainer.classList.add('col-12');
        endAtContainer.classList.add('col-sm-12');
        endAtContainer.classList.add('col-md-12');
        endAtContainer.classList.add('col-lg-4');
        endAtContainer.classList.add('col-xl-4');

        const endAtRow = document.createElement('div');
        endAtRow.classList.add('row');
        endAtRow.classList.add('px-3');
        endAtRow.classList.add('py-2');

        const endAtLabel = document.createElement('div');
        endAtLabel.classList.add('col-5');
        endAtLabel.classList.add('text-center');
        endAtLabel.innerText = 'End At';


        const endAtValue = document.createElement('div');
        endAtValue.classList.add('col-7');
        endAtValue.classList.add('text-center');
        endAtValue.innerText = `${exam.endAtValue}`;

        endAtRow.appendChild(endAtLabel);
        endAtRow.appendChild(endAtValue);
        endAtContainer.appendChild(endAtRow);
        row1.appendChild(endAtContainer);

        // Remaining, Expired
        const sharedContainer = document.createElement('div');
        sharedContainer.classList.add('col-12');
        sharedContainer.classList.add('col-sm-12');
        sharedContainer.classList.add('col-md-12');
        sharedContainer.classList.add('col-lg-3');
        sharedContainer.classList.add('col-xl-3');

        const sharedRow = document.createElement('div');
        sharedRow.classList.add('row');
        sharedRow.classList.add('px-3');
        sharedRow.classList.add('py-2');

        if (exam.examCalenderStatus == ExamCalenderStatus.Expired) {
            const expiredContainer = document.createElement('div');
            expiredContainer.classList.add('col-12');
            expiredContainer.classList.add('text-center');
            expiredContainer.innerText = `EXPIRED`;

            sharedRow.appendChild(expiredContainer);
            
        } else if (exam.examCalenderStatus == ExamCalenderStatus.Start) {
            const remainingLabel = document.createElement('div');
            remainingLabel.classList.add('col-5');
            remainingLabel.classList.add('text-center');
            remainingLabel.innerText = 'Remaining';


            const remainingValue = document.createElement('div');
            remainingValue.classList.add('col-7');
            remainingValue.classList.add('text-center');

            let now = new Date();
            let endDate = new Date(exam.exam.endDate);
            let remaining = Math.floor((endDate.getTime() - now.getTime()) / (1000 * 60));
            if (remaining < 0) { remaining = 0; }

            remainingValue.innerText = `${remaining} Minutes`;

            sharedRow.appendChild(remainingLabel);
            sharedRow.appendChild(remainingValue);

        } else {
            const durationLabel = document.createElement('div');
            durationLabel.classList.add('col-5');
            durationLabel.classList.add('text-center');
            durationLabel.innerText = 'Duration';


            const durationValue = document.createElement('div');
            durationValue.classList.add('col-7');
            durationValue.classList.add('text-center');

            let startDate = new Date(exam.exam.startDate);
            let endDate = new Date(exam.exam.endDate);
            let remaining = Math.floor((endDate.getTime() - startDate.getTime()) / (1000 * 60));

            durationValue.innerText = `${remaining} Minutes`;

            sharedRow.appendChild(durationLabel);
            sharedRow.appendChild(durationValue);
        }

        sharedContainer.appendChild(sharedRow);
        row1.appendChild(sharedContainer);
        eventContainer.appendChild(row1);
        divContainer.appendChild(eventContainer);

        this.eventsContainer = divContainer;
    }
  }

  getApproriateLocationForDiv(n: number): number {
    let afterCardNumber = 0;
    if (window.innerWidth >= 1200) {
        if (0 <= n && n <= 6) {
            afterCardNumber = 6;
        } else if (7 <= n && n <= 13) {
            afterCardNumber = 13;
        } else if (14 <= n && n <= 20) {
            afterCardNumber = 20;
        } else if (21 <= n && n <= 27) {
            afterCardNumber = 27;
        } else {
            afterCardNumber = 30;
        }
    } else if (window.innerWidth >= 992) {
        if (0 <= n && n <= 5) {
            afterCardNumber = 5;
        } else if (6 <= n && n <= 11) {
            afterCardNumber = 11;
        } else if (12 <= n && n <= 17) {
            afterCardNumber = 17;
        } else if (18 <= n && n <= 23) {
            afterCardNumber = 23;
        } else if (24 <= n && n <= 29) {
            afterCardNumber = 29;
        } else {
            afterCardNumber = 30;
        }
    } else if (window.innerWidth < 992) {
        if (0 <= n && n <= 3) {
            afterCardNumber = 3;
        } else if (4 <= n && n <= 7) {
            afterCardNumber = 7;
        } else if (8 <= n && n <= 11) {
            afterCardNumber = 11;
        } else if (12 <= n && n <= 15) {
            afterCardNumber = 15;
        } else if (16 <= n && n <= 19) {
            afterCardNumber = 19;
        } else if (20 <= n && n <= 23) {
            afterCardNumber = 23;
        } else if (24 <= n && n <= 27) {
            afterCardNumber = 27;
        } else {
            afterCardNumber = 30;
        }
    }

    return afterCardNumber;
  }

}

class ExamCalender {
    exam!: Exam;
    examCalenderStatus!: ExamCalenderStatus;
    dayNumber!: number;
    startAtValue!: string;
    endAtValue!: string;

    constructor(exam: Exam, dayNumber: number) {
        this.exam =  exam;
        this.dayNumber = dayNumber;
        this.extractStatus();
    }

    extractStatus() {
        let now: Date = new Date();
        let startDate: Date = new Date(this.exam.startDate);
        let endDate: Date = new Date(this.exam.endDate);     
        
        if (now.getDate() == this.dayNumber) {            
            if (now.getFullYear() == startDate.getFullYear() && now.getMonth() == startDate.getMonth() && now.getDate() == startDate.getDate() && now.getTime() >= startDate.getTime() && now.getTime() <= endDate.getTime()) {
                this.examCalenderStatus = ExamCalenderStatus.Start;
            } else if (now.getFullYear() == endDate.getFullYear() && now.getMonth() == endDate.getMonth() && now.getDate() == endDate.getDate() && now.getTime() > endDate.getTime()) {
                this.examCalenderStatus = ExamCalenderStatus.Expired;
            } else {
                this.examCalenderStatus = ExamCalenderStatus.NotStart;
            }
        } else {
            if (now.getFullYear() == startDate.getFullYear() && now.getMonth() == startDate.getMonth() && this.dayNumber == startDate.getDate()) {
                this.examCalenderStatus = ExamCalenderStatus.NotStart;
            } else if (now.getFullYear() == endDate.getFullYear() && now.getMonth() == endDate.getMonth() && this.dayNumber == endDate.getDate()) {
                this.examCalenderStatus = ExamCalenderStatus.Expired;
            } else {
                this.examCalenderStatus = ExamCalenderStatus.NotStart;
            }
        }

        let startAtMonth = startDate.getMonth();
        let startAtDay = (startDate.getDate() < 10) ? `0${startDate.getDate()}` : startDate.getDate().toString();
        let startAtHours = (startDate.getHours() < 10) ? `0${startDate.getHours()}` : startDate.getHours().toString();
        let startAtMinutes = (startDate.getMinutes() < 10) ? `0${startDate.getMinutes()}` : startDate.getMinutes().toString();
        let startAtSeconds = (startDate.getSeconds() < 10) ? `0${startDate.getSeconds()}` : startDate.getSeconds().toString();

        let endAtMonth = endDate.getMonth();
        let endAtDay = (endDate.getDate() < 10) ? `0${endDate.getDate()}` : endDate.getDate().toString();
        let endAtHours = (endDate.getHours() < 10) ? `0${endDate.getHours()}` : endDate.getHours().toString();
        let endAtMinutes = (endDate.getMinutes() < 10) ? `0${endDate.getMinutes()}` : endDate.getMinutes().toString();
        let endAtSeconds = (endDate.getSeconds() < 10) ? `0${endDate.getSeconds()}` : endDate.getSeconds().toString();

        const monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun",
        "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];

        this.startAtValue = `${monthNames[startAtMonth]} ${startAtDay}, ${startDate.getFullYear()} ${startAtHours}:${startAtMinutes}:${startAtSeconds}`;
        this.endAtValue = `${monthNames[endAtMonth]} ${endAtDay}, ${endDate.getFullYear()} ${endAtHours}:${endAtMinutes}:${endAtSeconds}`;
    }
}

enum ExamCalenderStatus {
    NotStart,
    Start,
    Expired
}


function delay(ms: number) {
  return new Promise( resolve => setTimeout(resolve, ms) );
}

