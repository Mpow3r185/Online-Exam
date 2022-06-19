import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-exam-card',
  templateUrl: './exam-card.component.html',
  styleUrls: ['./exam-card.component.css']
})
export class ExamCardComponent implements OnInit {

  @Input() examName!: string;
  @Input() courseName!: string;
  @Input() dsecription!: string;
  @Input() cost!: number;
  @Input() examImage!: string;
  @Input() numberOfUsersRegistered!: number;
  @Input() startDate!: string;
  @Input() endDate!: string;
  @Input() startHour!: string;
  @Input() endHour!: string;
  @Input() duration!: number;
  @Input() successMark!: number;
  @Input() examLevel!: string;

  constructor() { }

  ngOnInit(): void {
  }

}
