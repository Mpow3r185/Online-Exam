import { Component, Input, OnInit } from '@angular/core';
import { HomeService } from 'src/app/service/home.service';

@Component({
  selector: 'app-testimonial',
  templateUrl: './testimonial.component.html',
  styleUrls: ['./testimonial.component.css']
})
export class TestimonialComponent implements OnInit {

  @Input() profileImage!: string;
  @Input() name!: string;
  @Input() title!: string;
  @Input() message!: string;

  constructor() { }

  ngOnInit(): void {

  }

  getData(value :any){
    
  }

}
