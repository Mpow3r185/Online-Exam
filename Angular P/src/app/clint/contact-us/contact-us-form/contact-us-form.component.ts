import { Component, OnInit } from '@angular/core';
import { ContactService } from 'src/app/service/contact.service';
import { HomeService } from 'src/app/service/home.service';

@Component({
  selector: 'app-contact-us-form',
  templateUrl: './contact-us-form.component.html',
  styleUrls: ['./contact-us-form.component.css'],
})
export class ContactUsFormComponent implements OnInit {
  constructor(public contactService: ContactService, public homeService: HomeService) {}

  ngOnInit(): void {
    this.homeService.getDynamicData();
  }
  

  onSubmit() {
    this.contactService.createContact();
  }
}
