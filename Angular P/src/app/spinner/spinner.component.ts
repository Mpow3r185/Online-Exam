import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-spinner',
  templateUrl: './spinner.component.html',
  styleUrls: ['./spinner.component.css']
})
export class SpinnerComponent implements OnInit {
  constructor() { }

  ngOnInit(): void {
    let spinner: any = document.querySelector(".spinner-bg-color") as HTMLElement;
    spinner.classList.add("display-none");
  }

  static show() {
    let spinner: any = document.querySelector(".spinner-bg-color") as HTMLElement;
    spinner.classList.remove("display-none");
  }

  static hide() {
    let spinner: any = document.querySelector(".spinner-bg-color") as HTMLElement;
    spinner.classList.add("display-none");
  }

}
