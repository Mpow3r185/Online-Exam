import { Component, OnInit } from '@angular/core';
import { HomeService } from 'src/app/service/home.service';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';

@Component({
  selector: 'app-about-us',
  templateUrl: './about-us.component.html',
  styleUrls: ['./about-us.component.css']
})
export class AboutUsComponent implements OnInit {

  constructor(public home:HomeService) { }

  ngOnInit(): void {
    SpinnerComponent.show();
    this.home.getAllServices();
    SpinnerComponent.hide();
  }

}
