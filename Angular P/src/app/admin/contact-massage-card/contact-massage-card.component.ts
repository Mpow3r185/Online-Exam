import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-contact-massage-card',
  templateUrl: './contact-massage-card.component.html',
  styleUrls: ['./contact-massage-card.component.css']
})
export class ContactMassageCardComponent implements OnInit {
@Input() info:any;
  constructor() { }

  ngOnInit(): void {
  }

}
