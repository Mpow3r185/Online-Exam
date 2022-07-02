import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-single-option',
  templateUrl: './single-option.component.html',
  styleUrls: ['./single-option.component.css']
})
export class SingleOptionComponent implements OnInit {

  @Input() optionId!: number;
  @Input() optionContent!: string;
  @Input() questionId!: number;
  @Input() optionNumber!: number;

  constructor() { }

  ngOnInit(): void {
  }

}
