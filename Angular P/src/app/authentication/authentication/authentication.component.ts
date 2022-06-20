import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-authentication',
  templateUrl: './authentication.component.html',
  styleUrls: ['./authentication.component.css']
})
export class AuthenticationComponent implements OnInit {

  auth: string;
  constructor() {
    this.auth = "Sing In";
   }

  ngOnInit(): void {
  }

  displaySignUp() {
    const container = document.querySelector('.container-box') as HTMLButtonElement;
    container.classList.add("right-panel-active");
    this.auth = "Sign Up"; 
  }

  displaySignIn() {
    const container = document.querySelector('.container-box') as HTMLButtonElement;
    container.classList.remove("right-panel-active");
    this.auth = "Sign In";
  }



}