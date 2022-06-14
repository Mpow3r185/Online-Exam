import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AdvertisementService } from 'src/app/service/advertisement.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  constructor(public adService: AdvertisementService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.adService.getAdvertisementById({id: this.route.snapshot.params.adId, categoryId: this.route.snapshot.params.categoryId});
  }

}
