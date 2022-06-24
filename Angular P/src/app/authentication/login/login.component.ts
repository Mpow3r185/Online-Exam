import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthenticationService } from 'src/app/service/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  hide = true;

  constructor(public authService: AuthenticationService,private router: Router,private toastr: ToastrService) { }
  ngOnInit(): void {
  }

  
  loginForm: FormGroup = new FormGroup(
    {
      username: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
    }
  );

  chickAuthentication() {
    if(this.loginForm.valid){
      this.authService.chickAuthentication(this.loginForm.value);
    }
    else{
      this.toastr.error('You Must Fill The Fields First');
    }
  }

  goToRegisteration(){
    this.router.navigate(['auth/register'])
  }

}
