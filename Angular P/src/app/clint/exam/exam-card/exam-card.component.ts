import { Time } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';

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
  @Input() dsecription!: string;
  @Input() examLevel!: number;
  @Input() successMark!: number;
  @Input() cost!: number;
  @Input() startDate!: Date;
  @Input() endDate!: Date;
  //@Input() startHour!: Time;
  //@Input() endHour!: Time;
  @Input() status!: string;
  @Input() creationDate!: Date;

  constructor() { }

  ngOnInit(): void {
  }

}
