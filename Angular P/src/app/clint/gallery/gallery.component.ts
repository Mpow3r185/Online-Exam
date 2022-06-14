import { Component, OnInit } from '@angular/core';
import { AdvertisementService } from 'src/app/service/advertisement.service';

declare const filterImage: any;

@Component({
  selector: 'app-gallery',
  templateUrl: './gallery.component.html',
  styleUrls: ['./gallery.component.css']
})
export class GalleryComponent implements OnInit {
  constructor(public adService: AdvertisementService) { }

  ngOnInit(): void {
    this.adService.getActiveAdvertisement();
    this.adService.getGalleryImage();

  }

  filterGallery(event: any) {
    filterImage(event);
  }

}
