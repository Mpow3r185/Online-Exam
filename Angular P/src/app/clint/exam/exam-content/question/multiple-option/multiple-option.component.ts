import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-multiple-option',
  templateUrl: './multiple-option.component.html',
  styleUrls: ['./multiple-option.component.css']
})
export class MultipleOptionComponent implements OnInit {

  @Input() questionId!: number;
  @Input() optionContent!: string;
  @Input() optionNumber!: number;
  @Input() optionId!: number;

  constructor() { }

  ngOnInit(): void {
  }

}
