import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/service/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  hide = true;

  constructor(public authService: AuthenticationService,private router: Router) { }
  ngOnInit(): void {
  }

  chickAuthentication() {
    this.authService.chickAuthentication();
  }
  goToRegisteration(){
    this.router.navigate(['auth/register'])
  }

}
