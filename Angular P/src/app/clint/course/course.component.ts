import { Component, OnInit } from '@angular/core';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})
export class CourseComponent implements OnInit {

  constructor() { }
  courses:any=[{
    courseName:'React',
    courseImage:'assets/images/reactcourse.png'
  },
  {
    courseName:'Angular',
    courseImage:'assets/images/angular.png'
  },
  {
    courseName:'Data Base',
    courseImage:'assets/images/dbcourse.jpg'
  },
  {
    courseName:'Web Api',
    courseImage:'assets/images/apicourse.png'
  },
  {
    courseName:'C#',
    courseImage:'assets/images/c.jpg'
  },
  {
    courseName:'Entrepreneurship',
    courseImage:'assets/images/entrep.jpeg'
  }]
  ngOnInit(): void {
    SpinnerComponent.show();
    setTimeout(() => SpinnerComponent.hide(), 2000);
  }

}
