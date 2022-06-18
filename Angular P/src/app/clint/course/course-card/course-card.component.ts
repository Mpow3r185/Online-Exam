import { Component, OnInit,Input } from '@angular/core';

@Component({
  selector: 'app-course-card',
  templateUrl: './course-card.component.html',
  styleUrls: ['./course-card.component.css']
})
export class CourseCardComponent implements OnInit {

  constructor() { }
  @Input() courseName:string|undefined;
  @Input() courseImage:string|undefined;

  ngOnInit(): void {
  }

}
