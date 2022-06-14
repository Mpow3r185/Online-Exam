import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdvertisementService } from 'src/app/service/advertisement.service';
// import Swiper core and required modules
import SwiperCore, { EffectFade } from 'swiper';

// install Swiper modules
SwiperCore.use([EffectFade]);

@Component({
  selector: 'app-advertisement-card',
  templateUrl: './advertisement-card.component.html',
  styleUrls: ['./advertisement-card.component.css'],
})
export class AdvertisementCardComponent implements OnInit {
  @Input() info: any;
  constructor(private router: Router, public adService: AdvertisementService) {}

  ngOnInit(): void {}

  openDetailsPage(event: any) {
    this.router.navigate([
      `/client/details/${this.info.id}/${this.info.categoryId}`,
    ]);
  }
}
