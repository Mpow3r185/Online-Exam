import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-exam-profile',
  templateUrl: './exam-profile.component.html',
  styleUrls: ['./exam-profile.component.css']
})
export class ExamProfileComponent implements OnInit {

  isExpanded: boolean = true;

  
  @Input() id!: number;
  @Input() courseId!: number;
  @Input() title!: string;
  @Input() passcode!: string;
  @Input() dsecription!: string;
  @Input() examLevel!: number;
  @Input() successMark!: number;
  @Input() cost!: number;
  @Input() startDate!: Date;
  @Input() endDate!: Date;
  @Input() status!: string;
  @Input() creationDate!: Date;

  constructor() { 
    

  }

  ngOnInit(): void {
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
}
