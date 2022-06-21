import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { HomeService } from 'src/app/service/home.service';
import { UserService } from 'src/app/service/user.service';
import { TestimonialViewComponent } from './testimonial-view/testimonial-view.component';

@Component({
  selector: 'app-dashboard-card',
  templateUrl: './dashboard-card.component.html',
  styleUrls: ['./dashboard-card.component.css']
})
export class DashboardCardComponent implements OnInit {
  numOfUser!: number;
  numOfAdvertisement!: number;
  constructor(public homeService: HomeService, public dialog: MatDialog, public userService: UserService) { }

  ngOnInit(): void {
    /*this.adService.data = [];
    this.adService.getDesactiveAdvertisement();
    this.homeService.getAllTestimonials();
    this.userService.getAllUser();
    setTimeout(() => {
      this.numOfUser = this.userService.users.length;
    }, 1200);*/
  }

  openDialog(item: any) {
    this.dialog.open(TestimonialViewComponent, {
      width: '35%',
      data: {
        'testimonialInfo': item
      }
    });
  }

  updateActiveStatus(adId: number) {
    window.location.reload();
  }

  activateTestimonial(id: number) {
    this.homeService.updateTestimonial(id);
    window.location.reload();
  }

}
