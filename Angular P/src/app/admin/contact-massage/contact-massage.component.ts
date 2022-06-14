import { Component, OnInit } from '@angular/core';
import { ContactService } from 'src/app/service/contact.service';

@Component({
  selector: 'app-contact-massage',
  templateUrl: './contact-massage.component.html',
  styleUrls: ['./contact-massage.component.css']
})
export class ContactMassageComponent implements OnInit {
  page = 1;
  constructor(public contactService:ContactService) { }

  ngOnInit(): void {
    this.contactService.getAllContact();
  }

}
