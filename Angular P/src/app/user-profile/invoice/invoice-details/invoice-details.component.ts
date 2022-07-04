import { Component, OnInit } from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Inject } from '@angular/core';
import { HomeService } from 'src/app/service/home.service';

@Component({
  selector: 'app-invoice-details',
  templateUrl: './invoice-details.component.html',
  styleUrls: ['./invoice-details.component.css']
})
export class InvoiceDetailsComponent implements OnInit {
  InvoiceDetails:any = {};
  currentDate = new Date();

 InvoiceId:any =  Math.floor(Math.random() * (9798879 - 3345679 + 1)) + 3345679;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, public homeService:HomeService,) { }

  ngOnInit(): void {
    this.homeService.getUserByUserName();

    this.InvoiceDetails = {
      examName: this.data.dataKey.examName, 
      examLevel: this.data.dataKey.examLevel, 
      examCost: this.data.dataKey.examCost,
      InvoiceCreationDate: this.data.dataKey.InvoiceCreationDate
    }
    
  }

}
