import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AdvertisementService } from 'src/app/service/advertisement.service';
import { HomeService } from 'src/app/service/home.service';
import { UserService } from 'src/app/service/user.service';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})
export class CourseComponent implements OnInit {

  loopStatues: boolean = false;
  search!: string;
  adData: any = [];
  accountStatus: boolean = false;

  constructor(
    public adService: AdvertisementService,
    public homeService: HomeService,
    public dialog: MatDialog,
    public userService: UserService,
    private router: Router) { }

  // Test Data
  courses:any=[{
    courseName:'React',
    courseImage:'assets/images/reactcourse.png'
  },
  {
    courseName:'Angular',
    courseImage:'assets/images/angular.png'
  },
  {
    courseName:'Data Base',
    courseImage:'assets/images/dbcourse.jpg'
  },
  {
    courseName:'Web Api',
    courseImage:'assets/images/apicourse.png'
  },
  {
    courseName:'C#',
    courseImage:'assets/images/c.jpg'
  },
  {
    courseName:'Entrepreneurship',
    courseImage:'assets/images/entrep.jpeg'
  }];

  ngOnInit(): void {
    SpinnerComponent.show();
    setTimeout(() => SpinnerComponent.hide(), 2000);
  }
}

