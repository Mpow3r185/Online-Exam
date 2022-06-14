import { Component, OnInit } from '@angular/core';
import { AdvertisementService } from 'src/app/service/advertisement.service';
import SwiperCore, {
  Navigation,
  Autoplay,
  EffectCoverflow,
  Pagination,
} from 'swiper';
import { HomeService } from 'src/app/service/home.service';
import { MatDialog } from '@angular/material/dialog';
import { TestimonialFormComponent } from './testimonial-form/testimonial-form.component';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';
import { UserService } from 'src/app/service/user.service';
import { Router } from '@angular/router';
// import * as FuzzySearch from 'fuzzy-search';

SwiperCore.use([Navigation]);
SwiperCore.use([Autoplay]);
SwiperCore.use([EffectCoverflow, Pagination]);

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  loopStatues: boolean = false;
  // searcher: any;
  search!: string;
  adData: any = [];
  accountStatus: boolean = false;
  // search: FormControl = new FormControl();
  constructor(
    public adService: AdvertisementService,
    public homeService: HomeService,
    public dialog: MatDialog,
    public userService: UserService,
    private router: Router
  ) {}

  people = [{
    name: {
      firstName: 'Jesse',
      lastName: 'Bowen',
    },
    state: 'Seattle',
  }];

  ngOnInit(): void {
    SpinnerComponent.show();
    this.adService.data = [];
    this.adService.getActiveAdvertisement();
    this.homeService.getAllTestimonials();
    if (localStorage.getItem('token')) {
    this.userService.getUserById();
    setTimeout(() => this.homeService.getFirstTestimonial(), 1500);
    }

    let token = localStorage.getItem('token');

    if (token) {
      this.accountStatus = true;
    }


    if (this.adService.data.length > 3) {
      this.loopStatues = true;
    }
    setTimeout(() => SpinnerComponent.hide(), 2000);
  }

  openDialog() {
    this.dialog.open(TestimonialFormComponent, {
      height: '400px',
      width: '600px',
    });
  }
}
