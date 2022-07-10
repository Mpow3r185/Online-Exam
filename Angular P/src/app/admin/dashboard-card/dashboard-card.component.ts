import { Component, OnInit } from '@angular/core';
import { CalendarOptions } from '@fullcalendar/angular';
import { AdminService } from 'src/app/service/admin.service';
import { HomeService } from 'src/app/service/home.service';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';

@Component({
  selector: 'app-dashboard-card',
  templateUrl: './dashboard-card.component.html',
  styleUrls: ['./dashboard-card.component.css']
})
export class DashboardCardComponent implements OnInit {
  numOfUser!: number;
  numOfCourse!: number;

  lastFiveUser:any;
  lastFiveCourse:any;

  constructor(public homeService: HomeService, public adminService: AdminService) { }

  ngOnInit(): void {
    SpinnerComponent.show();
    this.adminService.getAllCourses();
    this.adminService.getAllAccounts();

    setTimeout(() => {
      this.numOfUser = this.adminService.AccountsData.length;
      this.numOfCourse = this.adminService.CoursesData.length;

      this.lastFiveUser = this.adminService.AccountsData.slice(Math.max(this.numOfUser - 5, 1));
      this.lastFiveCourse = this.adminService.CoursesData.slice(Math.max(this.numOfCourse - 5, 1));

    }, 2000);

    setTimeout(() => {
      SpinnerComponent.hide();
    }, 3500);

    
    
  }

  calendarOptions: CalendarOptions = {
    initialView: 'dayGridMonth',
  };

 


}
