import { Component, OnInit } from '@angular/core';
import { HomeService } from 'src/app/service/home.service';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';

@Component({
  selector: 'app-about-us',
  templateUrl: './about-us.component.html',
  styleUrls: ['./about-us.component.css']
})
export class AboutUsComponent implements OnInit {

  constructor(private home:HomeService) { }

  ngOnInit(): void {
    SpinnerComponent.show();
    this.home.getAllServices();
    setTimeout(() => SpinnerComponent.hide(), 2000);
  }

}
