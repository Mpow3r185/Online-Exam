import { Component, OnInit } from '@angular/core';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';

@Component({
  selector: 'app-about-us',
  templateUrl: './about-us.component.html',
  styleUrls: ['./about-us.component.css']
})
export class AboutUsComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    SpinnerComponent.show();
    setTimeout(() => SpinnerComponent.hide(), 2000);
  }

}
