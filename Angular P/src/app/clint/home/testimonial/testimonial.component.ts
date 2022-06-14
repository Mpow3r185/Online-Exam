import { Component, Input, OnInit } from '@angular/core';
import { HomeService } from 'src/app/service/home.service';

@Component({
  selector: 'app-testimonial',
  templateUrl: './testimonial.component.html',
  styleUrls: ['./testimonial.component.css']
})
export class TestimonialComponent implements OnInit {
  @Input() testimonialInfo: any;
  constructor(public homeService: HomeService) { }

  ngOnInit(): void {
  }

  getData(value :any){
    this.homeService.getTestimonial(value);
  }

}
