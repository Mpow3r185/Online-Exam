import { SpinnerComponent } from './../../../spinner/spinner.component';
import { HomeService } from './../../../service/home.service';
import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-exam-content',
  templateUrl: './exam-content.component.html',
  styleUrls: ['./exam-content.component.css']
})

export class ExamContentComponent implements OnInit {

  currentQuestionNumber: number = 0;                        // Number of the Exam Displayed
  private sizes?: number[];                                         // Height of Every Question Container
  private heightContainersCumulativeSum?: number[];                 // Cumulative Sum of Sizes array
  userAnswers: Map<number, number> = new Map<number, number>();     // User Answers <QuestionId, OptionId>
  timerExam!: string;

  private questionsContainers: any;
  private parentContainer: any;
  private sliderContainer: any;

  private routeSub!: Subscription;
  
  // Constructor
  constructor(
    public homeService: HomeService,
    private route: ActivatedRoute,
    private router: Router
    ) { 
      this.routeSub = this.route.params.subscribe(async params => {     
        
        await this.homeService.getExamContent(Number(params['id']));
        await this.homeService.getExamById(Number(params['id']));

        
      });
    }


  async ngOnInit(): Promise<void> {
    SpinnerComponent.show();

    await delay(15000);
    document.querySelector('#prevBtn')?.setAttribute('disabled', '');                  // Disable Previous Button
    document.querySelector(`#q0`)?.classList.add('q-active');                            
    this.questionsContainers = document.querySelectorAll('.questionCard');
    if (this.questionsContainers.length === 1) { document.querySelector('#nextBtn')?.setAttribute('disabled', ''); }

    this.sizes = new Array(this.questionsContainers.length);                           // Initialize Array
    this.parentContainer = document.getElementById('parentContainer');
    this.sliderContainer = document.getElementById('slider');
    this.heightContainersCumulativeSum = new Array(this.questionsContainers.length);   // Initialize Array

    // Fill Sizes Array
    for (let i=0; i<this.questionsContainers.length; i++) {
      this.sizes[i] = this.questionsContainers[i].clientHeight + 54;
    }
    
    // Fill Cumulative Sum Array
    this.heightContainersCumulativeSum[0] = this.sizes[0];
    for (let i=1; i<this.questionsContainers.length; i++) {
      this.heightContainersCumulativeSum[i] = this.heightContainersCumulativeSum[i-1] + this.sizes[i];
    }

    // Display First Question
    this.parentContainer.style.height = `${this.sizes[0]}px`;
    
    SpinnerComponent.hide();
    console.log(this.homeService.examContent);
    
    this.examTimer();
  }

  
  // On Resize Event Implementation
  onResize(): void {
    // Update Sizes Array
    for (let i=0; i<this.questionsContainers.length; i++) {
      this.sizes![i] = this.questionsContainers[i].clientHeight + 54;
    }

    // Update Cumulative Sum Array
    this.heightContainersCumulativeSum![0] = this.sizes![0];
    for (let i=1; i<this.questionsContainers.length; i++) {
      this.heightContainersCumulativeSum![i] = this.heightContainersCumulativeSum![i-1] + this.sizes![i];
    }

    this.transport(this.currentQuestionNumber);
  }
  

  // Transport Between Questions
  transport(questionNumber: number) {
    let questionAnswer;

    // Check If User Answer The Question or let it Empty
    if (document.querySelector(`input[name="q${this.currentQuestionNumber}]:checked`) === null) {
      questionAnswer = null; 
    } else {
      questionAnswer = (<HTMLInputElement>document.querySelector(`input[name="q${this.currentQuestionNumber}"]:checked`)).value;
    }

    // Save The Answer
    let questionId = (<HTMLInputElement>document.querySelectorAll('.hidden')[this.currentQuestionNumber]).value;  // Get Question Id
    this.userAnswers.set(Number(questionId), Number(questionAnswer));   // Save User Answer

    document.querySelector(`#q${this.currentQuestionNumber}`)?.classList.remove('q-active');

    this.parentContainer.style.height = `${this.sizes![questionNumber] - 2}px`;

    // Check If Transport to Backword or Forward
    if (questionNumber < this.currentQuestionNumber) {
      this.sliderContainer.style.transform = `translateY(${(this.sizes![questionNumber] - this.heightContainersCumulativeSum![questionNumber])}px)`;

    } else {
      this.sliderContainer.style.transform = `translateY(${-(this.heightContainersCumulativeSum![questionNumber] - this.sizes![questionNumber])}px)`;
    }

    this.currentQuestionNumber = questionNumber;    // Update Displayed Question Index

    if (this.currentQuestionNumber == this.questionsContainers.length - 1) {
      document.querySelector('#nextBtn')?.setAttribute('disabled', '');
  } else {
    document.querySelector('#nextBtn')?.removeAttribute('disabled');
  }

  if (this.currentQuestionNumber == 0) {
      document.querySelector('#prevBtn')?.setAttribute('disabled', '');
  } else {
      document.querySelector('#prevBtn')?.removeAttribute('disabled');
  }

  document.querySelector(`#q${questionNumber}`)?.classList.add('q-active');
  }

  examTimer(): void {
    let startTime: number = new Date(this.homeService.exams.startDate).getTime();
    let endTime: number = new Date(this.homeService.exams.endDate).getTime();
    let nowTime: number = new Date().getTime();

    if (nowTime >= startTime && nowTime < endTime) {
      this.timerFunc(endTime - nowTime);
    } else {
      this.router.navigate([`examProfile/${this.homeService.exams.id}`]);
    }
  }

  timerFunc(distance: number) {
    let days: number;
    let hours: number|string;
    let minutes: number|string;
    let seconds: number|string;

    let timer = setInterval( () => {
      days = Math.floor(distance / (1000 * 60 * 60 * 24));
      hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
      minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
      seconds = Math.floor((distance % (1000 * 60)) / 1000);
      
      hours += days * 24;

      if (hours === 0 && minutes === 0 && seconds === 0) {
        // Navigate to submit API function in service
        clearInterval(timer);
        this.router.navigate([`examProfile/${this.homeService.exams.id}`]);
        // Call Exit Message Dialog
      }

      if (hours < 10) { hours = `0${hours}`; }
      if (minutes < 10) { minutes = `0${minutes}`; }
      if (seconds < 10) { seconds = `0${seconds}`; }

      this.timerExam = hours + ":" + minutes + ":" + seconds;

      distance -= 1000; // Decrease by 1 second
    }, 1000);
  }

  // Unsubscribe to prevent memory leaks
  ngOnDestroy() {
    this.routeSub.unsubscribe();
  }

}


function delay(ms: number) {
  return new Promise( resolve => setTimeout(resolve, ms) );
}
