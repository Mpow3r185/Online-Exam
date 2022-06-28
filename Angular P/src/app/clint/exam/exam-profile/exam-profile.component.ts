import { SpinnerComponent } from './../../../spinner/spinner.component';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { HomeService } from 'src/app/service/home.service';

@Component({
  selector: 'app-exam-profile',
  templateUrl: './exam-profile.component.html',
  styleUrls: ['./exam-profile.component.css']
})
export class ExamProfileComponent implements OnInit {

  isExpanded: boolean = true;
  timerStatus: any;
  timerExam: any;
  private routeSub!: Subscription;

  constructor(public homeService: HomeService, private route: ActivatedRoute) {}

  async ngOnInit() {
    
    this.routeSub = this.route.params.subscribe(async params => {
      await this.homeService.getExamById(Number(params['id']));
      await this.homeService.GetNumberOfUsersBuyByExamId(Number(params['id']));
    });
    await delay(1000);

    this.getExamDuration();
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

  // Unsubscribe to prevent memory leaks
  ngOnDestroy() {
    this.routeSub.unsubscribe();
  }
}

function delay(ms: number) {
  return new Promise( resolve => setTimeout(resolve, ms) );
}