import { Component, Input, OnInit } from '@angular/core';
import { HomeService } from 'src/app/service/home.service';

@Component({
  selector: 'app-testimonial',
  templateUrl: './testimonial.component.html',
  styleUrls: ['./testimonial.component.css']
})
export class TestimonialComponent implements OnInit {

  @Input() profileImage:string | undefined;
  // @Input() name!: string;
  // @Input() title!: string;
  // @Input() message!: string;

  //New2
  @Input() idd      : number | undefined;
  @Input() message  : string | undefined;
  @Input() status   : string | undefined;
  @Input() accountId: number | undefined;
  @Input() userName : string | undefined;
  @Input() profilePicture : string | undefined;
  @Input() fullName : string | undefined;



  constructor() { }

  ngOnInit(): void {
    
  }

}

