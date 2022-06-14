import { Component, OnInit } from '@angular/core';

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
      subtitle: "198 West 21th Street, Suite 721 New York NY 10016"
    },
    {
      icon: "fal fa-mobile",
      title: "Phone",
      subtitle: "+ 1235 2355 98"
    },
    {
      icon: "fal fa-envelope",
      title: "Email",
      subtitle: "info@yoursite.com"
    }
  ];
  constructor() { }

  ngOnInit(): void {
  }

}
