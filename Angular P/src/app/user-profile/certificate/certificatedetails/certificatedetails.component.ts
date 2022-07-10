import { Component, OnInit } from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Inject } from '@angular/core';
import { HomeService } from 'src/app/service/home.service';

@Component({
  selector: 'app-certificatedetails',
  templateUrl: './certificatedetails.component.html',
  styleUrls: ['./certificatedetails.component.css']
})
export class CertificatedetailsComponent implements OnInit {

  CertificateDetails:any = {};

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, public homeService:HomeService) { }

  ngOnInit(): void {
    this.CertificateDetails = {
      CertificateDate: this.data.dataKey.CertificateCreationDate,
      examName: this.data.dataKey.examName, 
      examLevel: this.data.dataKey.examLevel,
      examDate: this.data.dataKey.examDate
    }
  }

          
}
