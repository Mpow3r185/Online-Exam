import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-fill-option',
  templateUrl: './fill-option.component.html',
  styleUrls: ['./fill-option.component.css']
})
export class FillOptionComponent implements OnInit {

  @Input() questionId!: number;

  constructor() { }

  ngOnInit(): void {
  }

}
