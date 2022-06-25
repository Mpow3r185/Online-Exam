import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
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
    public homeService: HomeService,
    public dialog: MatDialog,
    public userService: UserService,
    private router: Router) { }

  async ngOnInit(): Promise<void> {
    await this.homeService.getCourses();
  }
}

