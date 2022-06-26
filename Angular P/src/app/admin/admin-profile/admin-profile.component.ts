import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-admin-profile',
  templateUrl: './admin-profile.component.html',
  styleUrls: ['./admin-profile.component.css']
})
export class AdminProfileComponent implements OnInit {

  constructor(public userService: UserService) { }

  ngOnInit(): void {
    this.userService.getUserById();
    setTimeout(() => {
      this.userService.setInitValue()
    }, 1000);
  }

}
