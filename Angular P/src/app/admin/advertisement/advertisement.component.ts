import { Component, OnInit } from '@angular/core';
import { AdvertisementService } from 'src/app/service/advertisement.service';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';

@Component({
  selector: 'app-advertisement',
  templateUrl: './advertisement.component.html',
  styleUrls: ['./advertisement.component.css']
})
export class AdvertisementComponent implements OnInit {
  page = 1;

  constructor(public adService: AdvertisementService) { }

  ngOnInit(): void {
    SpinnerComponent.show();
    this.adService.data = [];
    this.adService.getActiveAdvertisement();

    setTimeout(() => {
      SpinnerComponent.hide();
    }, 2000);
  }

}
