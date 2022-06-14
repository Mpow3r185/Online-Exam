import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-all-advertisement-card',
  templateUrl: './all-advertisement-card.component.html',
  styleUrls: ['./all-advertisement-card.component.css']
})
export class AllAdvertisementCardComponent implements OnInit {
  @Input() cardInfo: any;
  constructor() { }

  ngOnInit(): void {
  }

}
