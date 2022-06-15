import { Component, OnInit } from '@angular/core';
import { ContactService } from 'src/app/service/contact.service';

@Component({
  selector: 'app-contact-us-form',
  templateUrl: './contact-us-form.component.html',
  styleUrls: ['./contact-us-form.component.css'],
})
export class ContactUsFormComponent implements OnInit {
  constructor(public contactService: ContactService) {}

  ngOnInit(): void {}
  

  onSubmit() {
    this.contactService.createContact();
  }
}
