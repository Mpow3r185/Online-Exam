import { Component, HostListener, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../service/user.service';

@Component({
  selector: 'app-internal-nav-bar',
  templateUrl: './internal-nav-bar.component.html',
  styleUrls: ['./internal-nav-bar.component.css']
})
export class InternalNavBarComponent implements OnInit {
  accountStatus: boolean = false;
  constructor(public userService: UserService, private router: Router) { }

  async ngOnInit() {
    if (localStorage.getItem('token')) {
      this.accountStatus = true;
    }
  }

  logOut() {
    localStorage.clear();
    this.router.navigate(['/auth/login']);
  }

  isScrolled: boolean = false;
  @HostListener('document:scroll')
  changeNavbarBehavior() {
    if (document.body.scrollTop > 0 || document.documentElement.scrollTop > 0) {
      this.isScrolled = true;
    } else {
      this.isScrolled = false;
    }
  }

}
