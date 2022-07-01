import { Component, OnInit } from '@angular/core';
import { ContactService } from 'src/app/service/contact.service';
import { HomeService } from 'src/app/service/home.service';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';

@Component({
  selector: 'app-contact-us-form',
  templateUrl: './contact-us-form.component.html',
  styleUrls: ['./contact-us-form.component.css'],
})
export class ContactUsFormComponent implements OnInit {
  constructor(
    public contactService: ContactService,
    public homeService: HomeService) {}

  ngOnInit(): void {  }
  

  onSubmit() {
    SpinnerComponent.show();

    this.contactService.createContact();

    SpinnerComponent.show();
  }
}
