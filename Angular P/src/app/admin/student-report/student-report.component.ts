import { Component, OnInit, TemplateRef, ViewChild,ElementRef, Input } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { AdminService } from 'src/app/service/admin.service';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';
declare const $:any;
import * as XLSX from 'xlsx';
import { Router } from '@angular/router';
@Component({
  selector: 'app-student-report',
  templateUrl: './student-report.component.html',
  styleUrls: ['./student-report.component.css']
})
export class StudentReportComponent implements OnInit {

  //This For Details  Dialog
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
   this.adminService.getAllAccountWithoutAdmin();
   this.adminService.getNumOfUsers();
   this.adminService.getNumOfCertificates();
   this.adminService.getNumOfFailUsers();
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
 

 studentDetailsReport(accId:number){
   this.router.navigate([`/admin/stdDetailsReport/${accId}`]);
 }
  // Number Of Registered Users
  getNumberOfUsers(): number {
  return this.adminService.NumOfUsers;
}
}

