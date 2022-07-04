import { Component, OnInit, TemplateRef, ViewChild,ElementRef, Input } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { AdminService } from 'src/app/service/admin.service';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';
declare const $:any;
import * as XLSX from 'xlsx';
import  {jsPDF} from 'jspdf';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-std-report-details',
  templateUrl: './std-report-details.component.html',
  styleUrls: ['./std-report-details.component.css']
})
export class StdReportDetailsComponent implements OnInit {
  //This For Details  Dialog
  @ViewChild('callDetailsDialog') callDetailsDialog!: TemplateRef<any>;
  @ViewChild('content',{static:false}) el!:ElementRef;

  private routeSub!: Subscription;
  constructor(public adminService: AdminService, 
              private dialog: MatDialog,
              private toastr: ToastrService,
              private router: Router,
              private route: ActivatedRoute) {
                this.routeSub = this.route.params.subscribe(async params => {                  
                  await this.adminService.getFullUserDetailsById(Number(params['id']));
                  await this.adminService.getAccountById(Number(params['id']));
                });
              }
 
  ngAfterViewInit(): void {
    setTimeout(() => {
      $('#dtTable2').DataTable({
        pageLength: 5,
        processing: true
    });
    }, 3500);
  }
 
  ngOnInit(): void {
    SpinnerComponent.show();
    //this.adminService.getAllCertificates();

    setTimeout(() => {
      SpinnerComponent.hide();
    }, 3500);
//  let a:any=[];
  
//   for(let i of this.adminService.certificate)
//   {
//    if(i.accId==student.id)
//     a.push(i);
   
    
//   }
  
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
  makePDF()
  {
    let pdf=new jsPDF('p','pt','a1');
    pdf.html(this.el.nativeElement,{
     callback:(pdf)=>{
       pdf.save("demo.pdf");
     }
    });
  }
  back(){
    this.router.navigate(['/admin/studentReport'])
  }

  // Unsubscribe to prevent memory leaks
  ngOnDestroy() {
    this.routeSub.unsubscribe();
  }
  

}

