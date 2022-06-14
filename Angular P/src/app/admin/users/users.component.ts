import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
})
export class UsersComponent implements OnInit {
  page = 1;
  constructor(public userService: UserService) {}

  ngOnInit(): void {
    this.userService.getAllUser();
  }
}
