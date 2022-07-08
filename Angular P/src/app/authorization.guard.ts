import { Injectable, OnInit } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { SpinnerComponent } from './spinner/spinner.component';
import { HomeService } from './service/home.service';

@Injectable({
  providedIn: 'root',
})
export class AuthorizationGuard implements CanActivate {
  constructor(private router: Router, private toastr: ToastrService, private homeService: HomeService) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

    const token = localStorage.getItem('token');
    if (token) {
      if (state.url.indexOf('profile') >= 0) {
        let user: any = localStorage.getItem('user');
        if (user) {
          user = JSON.parse(user);
          if (user.role == 'Student') {
            setTimeout(() => {
              SpinnerComponent.hide();
            }, 2000);
            return true;
          } else {
            setTimeout(() => {
              SpinnerComponent.hide();
            }, 2000);
            setTimeout(() => {
              this.toastr.error('You do not have permission to access the page');
            }, 2000);
            return false;
          }
        } else {
          setTimeout(() => {
            SpinnerComponent.hide();
          }, 2000);
          setTimeout(() => {
            this.toastr.error('You are not authorized');
          }, 2000);
          return false;
        }
      }
      else if (state.url.indexOf('admin') >= 0) {
        let user: any = localStorage.getItem('user');
        if (user) {
          user = JSON.parse(user);
          if (user.role == 'Admin') {
            setTimeout(() => {
              SpinnerComponent.hide();
            }, 2000);
            return true;
          }
          else {
            setTimeout(() => {
              SpinnerComponent.hide();
            }, 2000);
            this.router.navigate(['/page404']);
            setTimeout(() => {
              this.toastr.error('You do not have permission to access the page');
            }, 2000);
            return false;
          }
        }
        else {
          setTimeout(() => {
            SpinnerComponent.hide();
          }, 2000);
          setTimeout(() => {
            this.toastr.error('You are not authorized');
          }, 2000);
          return false;
        }
      } 
      else if (state.url.indexOf('exam') >= 0) {
        let x = {
          examId: Number(state.url.split('/').pop()),
          accountId: Number(localStorage.getItem('AccountId'))
        };
        
        this.homeService.userIfBoughtExam(x);
        setTimeout(() => {}, 1000);


        let user: any = localStorage.getItem('user');
        if (user) {
          user = JSON.parse(user);
          if (user.role == 'Student') {

            if (!this.homeService.isBoughtExam) {
              this.router.navigate([`/examProfile/${Number(state.url.split('/').pop())}`]);
            }
            setTimeout(() => {
            }, 2000);
            return true;
          } else {
            setTimeout(() => {
              SpinnerComponent.hide();
            }, 2000);
            setTimeout(() => {
              this.toastr.error('You do not have permission to access the page');
            }, 2000);
            return false;
          }
        } else {
          setTimeout(() => {
            SpinnerComponent.hide();
          }, 2000);
          setTimeout(() => {
            this.toastr.error('You are not authorized');
          }, 2000);
          return false;
        }
      }
      
      return true;
    } else {
      setTimeout(() => {
        SpinnerComponent.hide();
      }, 2000);
      setTimeout(() => {
        this.toastr.error('You are not authorized');
      }, 2000);
      this.router.navigate(['auth/login']);
      return false;
    }
  }
}
