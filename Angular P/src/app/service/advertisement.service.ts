import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SpinnerComponent } from '../spinner/spinner.component';

@Injectable({
  providedIn: 'root',
})
export class AdvertisementService {
  data: any[] = [];
  images!: string;
  selectedAd: any;
  isActive?: boolean;
  reportData: any = [];
  adNumber: number = 0;
  constructor(private http: HttpClient, private router: Router) {}

  getAllAdvertisement() {
    this.http
      .get('https://localhost:44359/api/Advertisement')
      .subscribe((result: any) => {
        for (const key in result) {
          this.getAdvertisementById(result[key]);
        }
        this.adNumber = result.length;
      });
  }

  getAdvertisementById(adInfo: any) {
    const headerDict = {
      'Content-Type': 'application/json charset=utf-8',
    };
    this.http
      .get(
        `https://localhost:44359/api/Advertisement/GetAdvertisement/${adInfo.id}/${adInfo.categoryId}`,
        {
          headers: new HttpHeaders(headerDict),
        }
      )
      .subscribe(
        (result: any) => {
          if (this.isActive) {
            if (result.isActive) {
              this.data.push(result);
            }
          } else if (!this.isActive && this.isActive != null){
            if (!result.isActive) {
              this.data.push(result);
            }
          }
          this.selectedAd = result;
          this.getAdImage();
        },
        (err) => console.log(err)
      );
  }

  getGalleryImage() {
    this.data = this.data.slice(0, 9);
  }

  getActiveAdvertisement() {
    this.isActive = true;
    this.getAllAdvertisement();
  }

  getDesactiveAdvertisement() {
    this.isActive = false;
    this.getAllAdvertisement();
  }

  getAdImage() {
    if (this.data.length > 0) {
      this.data.forEach(
        (element) => {
          this.images = element.imageSrc;
          element.imageSrc = this.images.toString().split(',');
        }
      );
    }
    else {
      this.images = this.selectedAd.imageSrc;
      this.selectedAd.imageSrc = this.images.toString().split(',');
    }
  }

  updateActivateStatus(id: any) {
    const headerDict = {
      'Content-Type': 'application/json',
      Accept: 'application/json',
    };
    const requestOptions = {
      headers: new HttpHeaders(headerDict),
    };
    this.http
      .put(
        'https://localhost:44359/api/Advertisement/UpdateActivate',
        { Id: id },
        requestOptions
      )
      .subscribe(
        (result: any) => {},
        (error) => console.log(error)
      );
  }

  getRentReport() {
    SpinnerComponent.show();
    this.http.get('https://localhost:44359/api/Advertisement/adRentReport').subscribe(
      result => {
        this.reportData = result;
        setTimeout(() => {
          SpinnerComponent.hide();
        }, 2000);
      },
      error => console.log(error)
    );
  }

  getSaleReport() {
    SpinnerComponent.show();
    this.http.get('https://localhost:44359/api/Advertisement/adSaleReport').subscribe(
      result => {
        this.reportData = result;
        setTimeout(() => {
          SpinnerComponent.hide();
        }, 2000);
      }
    );
  }
}
