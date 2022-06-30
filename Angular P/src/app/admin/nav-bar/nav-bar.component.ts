import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SpinnerComponent } from '../../spinner/spinner.component';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  constructor(private router: Router,  private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  logOut() {
   SpinnerComponent.show();
    setTimeout(() => {
      this.toastr.success("Logout Successfully");
      SpinnerComponent.hide();
    }, 2000);
    localStorage.clear();
    this.router.navigate(['/auth/login']);
  }

}
