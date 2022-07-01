import { Component, OnInit } from '@angular/core';
import { HomeService } from 'src/app/service/home.service';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.css']
})
export class ContactUsComponent implements OnInit {
  
  
  contactUsInfo!: Array<any>;
  constructor(public homeService: HomeService) { }

  async ngOnInit(): Promise<void> {
    SpinnerComponent.show();

    await delay(1000);
    
    this.contactUsInfo = [{
      icon: "fal fa-map",
      title: "Address",
      subtitle: this.homeService.dynamicData[0].address
    },
    {
      icon: "fal fa-mobile",
      title: "Phone",
      subtitle: this.homeService.dynamicData[0].phoneNumber
    },
    {
      icon: "fal fa-envelope",
      title: "Email",
      subtitle: this.homeService.dynamicData[0].email
    }
  ];
    
    SpinnerComponent.hide();
  }

  async getContactInfo() {
      
  }

}


function delay(ms: number) {
  return new Promise( resolve => setTimeout(resolve, ms) );
}
