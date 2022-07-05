import { Component, Input, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { AdminService } from 'src/app/service/admin.service';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';
declare const $:any
@Component({
  selector: 'app-admin-testimonial',
  templateUrl: './admin-testimonial.component.html',
  styleUrls: ['./admin-testimonial.component.css']
})
export class AdminTestimonialComponent implements OnInit {

  @ViewChild('callDeleteDialog') callDeleteDialog!: TemplateRef<any>;
  @ViewChild('callDeleteDialog2') callDeleteDialog2!: TemplateRef<any>;
  constructor(public adminService:AdminService,private dialog: MatDialog,private toastr:ToastrService ) { }
   ngAfterViewInit(): void {
    setTimeout(() => {
      $('#dtTable4').DataTable({
        pageLength: 5,
        processing: true
    });
    }, 3000);
  }
  
  handleAccepted(a:any){
    if(a.status=="PENDING" || a.status=="REJECTED")
    {
      let body:any={
       
       id:a.id,
       status:"ACCEPTED"
      }
      
    //  this.adminService.testimonials=this.adminService.testimonials.filter((data:any) => data.id!=a.id)
      this.adminService.updateTestimonial(body);
      this.toastr.success('Accepted');
    }
     
  }
  handleRejected(a:any){
    if(a.status=="PENDING" || a.status=="ACCEPTED")
    {
      let body:any={
       
       id:a.id,
       status:"REJECTED"
      }
      
    //  this.adminService.testimonials=this.adminService.testimonials.filter((data:any) => data.id!=a.id)
      this.adminService.updateTestimonial(body);
      this.toastr.success('Rejected');
    }
     
  }

  // deletetest(id:number)
  // {
  //   this.adminService.testimonials=this.adminService.testimonials.filter((data:any) => data.id!=id)
  //   this.adminService.DeleteTestimonial(id);
  // }

  //This For Delete Testimonial Dialog
  
   openDeleteDialog(id: number) {

    const dialogRef = this.dialog.open(this.callDeleteDialog);

    dialogRef.afterClosed().subscribe((result) => {
      if (result != undefined) {
          if (result == 'yes') {
            this.adminService.DeleteTestimonial(id);
            setTimeout(() => {
              window.location.reload();
            }, 2000); 
            
          }
      }
    })
  }


   //This For Delete Testimonial Dialog
  
   openAcceptRejectDialog(obj:any) {

    const dialogRef = this.dialog.open(this.callDeleteDialog2);

    dialogRef.afterClosed().subscribe((result) => {
      if (result != undefined) {
          if (result == 'yes') {
            this.handleAccepted(obj);
            setTimeout(() => {
              window.location.reload();
            }, 2000); 
            
          }
          else{
            this.handleRejected(obj)
            setTimeout(() => {
              window.location.reload();
            }, 2000);
          }
      }
    })
  }
  ngOnInit(): void {
    SpinnerComponent.show();
    this.adminService.getTestimonials();
    setTimeout(() => {
      SpinnerComponent.hide();
    }, 3500);
  }

}

