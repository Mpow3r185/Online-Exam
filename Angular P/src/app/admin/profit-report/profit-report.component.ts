import { Component, ElementRef, Input, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { AdminService } from 'src/app/service/admin.service';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';
declare const $:any;
import * as XLSX from 'xlsx';

@Component({
  selector: 'app-profit-report',
  templateUrl: './profit-report.component.html',
  styleUrls: ['./profit-report.component.css']
})
export class ProfitReportComponent implements OnInit {
  @ViewChild('callDetailsDialog') callDetailsDialog!: TemplateRef<any>;
  @ViewChild('content',{static:false}) el!:ElementRef;
 
 
  @Input() totalUsers!: number;
  constructor(public adminService: AdminService,
              private dialog: MatDialog,
              private toastr: ToastrService,
              private router: Router) {}
 
  ngAfterViewInit(): void {
    setTimeout(() => {
      $('#dtTable3').DataTable({
        pageLength: 5,
        processing: true
    });
    }, 3500);
  }
 
  ngOnInit(): void {
    SpinnerComponent.show();
    this.adminService.getProfitReport();
    this.adminService.getProfitReportDetails();
    setTimeout(() => {
      SpinnerComponent.hide();
    }, 3500);    
  }
 
 
 
  fileName= 'ExcelSheet.xlsx';
 
  exportexcel(): void
  {
    /* pass here the table id */
    let element = document.getElementById('excel-table');
    const ws: XLSX.WorkSheet =XLSX.utils.table_to_sheet(element);
 
    /* generate workbook and add the worksheet */
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
 
    /* save to file */
    XLSX.writeFile(wb, this.fileName);
 
  }

}
