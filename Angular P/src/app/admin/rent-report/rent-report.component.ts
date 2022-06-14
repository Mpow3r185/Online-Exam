import { Component, OnInit } from '@angular/core';
import { AdvertisementService } from 'src/app/service/advertisement.service';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';

declare const exportTableToCSV: any;
declare const exportTableToExcel: any;
declare const printTable: any;

@Component({
  selector: 'app-rent-report',
  templateUrl: './rent-report.component.html',
  styleUrls: ['./rent-report.component.css']
})
export class RentReportComponent implements OnInit {

  constructor(public adService: AdvertisementService) { }

  ngOnInit(): void {
    this.adService.getRentReport();
  }

  exportToCSV(fileName: string) {
    exportTableToCSV(fileName);
  }

  exportToExcel() {
    exportTableToExcel();
  }

  printBtn() {
    printTable();
  }

}
