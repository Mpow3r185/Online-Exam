import { Component, OnInit } from '@angular/core';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';

@Component({
  selector: 'app-advertisement',
  templateUrl: './advertisement.component.html',
  styleUrls: ['./advertisement.component.css']
})
export class AdvertisementComponent implements OnInit {
  page = 1;

  constructor() { }

  ngOnInit(): void {
    SpinnerComponent.show();

    setTimeout(() => {
      SpinnerComponent.hide();
    }, 2000);
  }

}
