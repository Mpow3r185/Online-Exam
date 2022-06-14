import { Component, OnInit } from '@angular/core';

declare const openNavBar: any;

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  callFun() {
    openNavBar();
  }
  accountStatus: boolean = false;
  constructor() { }

  ngOnInit(): void {
    const token = localStorage.getItem('token');
    if (token) {
      this.accountStatus = true;
    }
  }

}
