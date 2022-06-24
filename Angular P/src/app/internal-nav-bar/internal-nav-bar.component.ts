import { Component, HostListener, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HomeService } from '../service/home.service';
import { SpinnerComponent } from '../spinner/spinner.component';

@Component({
  selector: 'app-internal-nav-bar',
  templateUrl: './internal-nav-bar.component.html',
  styleUrls: ['./internal-nav-bar.component.css']
})
export class InternalNavBarComponent implements OnInit {

  isScrolled: boolean = false;
  accountStatus: boolean = false;
  
  constructor(public homeService: HomeService, private router: Router,  private toastr: ToastrService) {    }

  async ngOnInit() {
    if (localStorage.getItem('token')) {
      this.homeService.getUserByUserName();
      this.accountStatus = true;
    }
  }

  logOut() {
    SpinnerComponent.show();
    setTimeout(() => {
      SpinnerComponent.hide();
    }, 2000);
    setTimeout(() => {
      this.toastr.success("Logout Successfully");
    }, 2000);
    localStorage.clear();
    this.router.navigate(['/auth/login']);
  }

  
  @HostListener('document:scroll')
  changeNavbarBehavior() {
    if (document.body.scrollTop > 0 || document.documentElement.scrollTop > 0) {
      this.isScrolled = true;
    } else {
      this.isScrolled = false;
    }
  }
}
