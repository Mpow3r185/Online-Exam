import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-contact-us-info-card',
  templateUrl: './contact-us-info-card.component.html',
  styleUrls: ['./contact-us-info-card.component.css']
})
export class ContactUsInfoCardComponent implements OnInit {
  @Input() contactInfo: any;
  constructor() { }
  

  ngOnInit(): void {
  }

}
