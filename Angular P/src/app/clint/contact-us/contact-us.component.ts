import { Component, OnInit } from '@angular/core';
import { HomeService } from 'src/app/service/home.service';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.css']
})
export class ContactUsComponent implements OnInit {
  contactUsInfo: Array<any> = [
    {
      icon: "fal fa-map",
      title: "Address",
      subtitle: this.homeService.homePage[0].address
    },
    {
      icon: "fal fa-mobile",
      title: "Phone",
      subtitle: this.homeService.homePage[0].phoneNumber
    },
    {
      icon: "fal fa-envelope",
      title: "Email",
      subtitle: this.homeService.homePage[0].email
    }
  ];
  constructor(public homeService: HomeService) { }

  ngOnInit(): void {
    SpinnerComponent.show();
    setTimeout(() => SpinnerComponent.hide(), 2000);
    this.homeService.getHomePage();
  }

}
