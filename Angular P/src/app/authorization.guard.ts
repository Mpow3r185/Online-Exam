import { Injectable } from '@angular/core';
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

@Injectable({
  providedIn: 'root',
})
export class AuthorizationGuard implements CanActivate {
  constructor(private router: Router, private toastr: ToastrService) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    const token = localStorage.getItem('token');
    if (token) {
      if (state.url.indexOf('client') >= 0) {
        let user: any = localStorage.getItem('user');
        if (user) {
          user = JSON.parse(user);
          if (user.role == 'Client') {
            setTimeout(() => {
              SpinnerComponent.hide();
            }, 2000);
            return true;
          } else {
            setTimeout(() => {
              SpinnerComponent.hide();
            }, 2000);
            setTimeout(() => {
              this.toastr.error('this page for Client');
            }, 2000);
            return false;
          }
        } else {
          setTimeout(() => {
            SpinnerComponent.hide();
          }, 2000);
          setTimeout(() => {
            this.toastr.error('you are not authorized');
          }, 2000);
          return false;
        }
      }
      else if (state.url.indexOf('admin')) {
        let user: any = localStorage.getItem('user');
        if (user) {
          user = JSON.parse(user);
          if (user.role == 'admin') {
            setTimeout(() => {
              SpinnerComponent.hide();
            }, 2000);
            return true;
          }
          else {
            setTimeout(() => {
              SpinnerComponent.hide();
            }, 2000);
            this.router.navigate(['client/home']);
            setTimeout(() => {
              this.toastr.error('this page for admin');
            }, 2000);
            return false;
          }
        }
        else {
          setTimeout(() => {
            SpinnerComponent.hide();
          }, 2000);
          setTimeout(() => {
            this.toastr.error('you are not authorized');
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
        this.toastr.error('you are not authorized');
      }, 2000);
      this.router.navigate(['auth/login']);
      return false;
    }
  }
}
