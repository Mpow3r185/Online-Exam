import { Component, Input, OnInit } from '@angular/core';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-user-card',
  templateUrl: './user-card.component.html',
  styleUrls: ['./user-card.component.css']
})
export class UserCardComponent implements OnInit {
  @Input() userInfo:any;
  constructor(public userService: UserService) { }

  ngOnInit(): void {
  }

}
