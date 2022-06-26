import { Component, OnInit,Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-course-card',
  templateUrl: './course-card.component.html',
  styleUrls: ['./course-card.component.css']
})
export class CourseCardComponent implements OnInit {

  constructor(public router: Router) { }
  @Input() id!: number;
  @Input() courseName!: string;
  @Input() description!: string;
  @Input() status!: string
  @Input() courseImage!: string;

  ngOnInit(): void {
  }

  goToCourseProfile() {
    this.router.navigate([`course/${this.id}`])
  }

}
