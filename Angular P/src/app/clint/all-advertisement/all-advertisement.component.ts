import { Component, OnInit } from '@angular/core';
import { AdvertisementService } from 'src/app/service/advertisement.service';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';

@Component({
  selector: 'app-all-advertisement',
  templateUrl: './all-advertisement.component.html',
  styleUrls: ['./all-advertisement.component.css']
})
export class AllAdvertisementComponent implements OnInit {
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
