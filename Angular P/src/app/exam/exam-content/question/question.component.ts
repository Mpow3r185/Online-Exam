import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})
export class QuestionComponent implements OnInit {

  @Input() questionNumber!: number;
  @Input() question!: any;
  @Input() options: any;

  constructor() { }

  ngOnInit(): void {        
  }

}
