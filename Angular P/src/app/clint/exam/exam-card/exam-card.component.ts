import { Component, Input, OnInit } from '@angular/core';
import { HomeService } from 'src/app/service/home.service';

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
  @Input() description!: string;
  @Input() examLevel!: number;
  @Input() successMark!: number;
  @Input() cost!: number;
  @Input() startDate!: Date;
  @Input() endDate!: Date;
  @Input() status!: string;
  @Input() creationDate!: Date;
  @Input() examImage!: string;

  course: any = [{}];

  constructor(public homeService: HomeService) { 
    this.run();
  }

  private async run() {
    await this.homeService.searchCourse( { cid: this.courseId } );
  }

  ngOnInit(): void {
  }

}
