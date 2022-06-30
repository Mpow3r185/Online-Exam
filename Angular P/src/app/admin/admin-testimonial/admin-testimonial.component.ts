import { Component, Input, OnInit } from '@angular/core';
import { AdminService } from 'src/app/service/admin.service';

@Component({
  selector: 'app-admin-testimonial',
  templateUrl: './admin-testimonial.component.html',
  styleUrls: ['./admin-testimonial.component.css']
})
export class AdminTestimonialComponent implements OnInit {

 
  constructor(public adminService:AdminService ) { }
  
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
      
      this.adminService.testimonials=this.adminService.testimonials.filter((data:any) => data.id!=a.id)
      this.adminService.updateTestimonial(body);
    }
    console.log(a);
     
  }
  deletetest(id:number)
  {
    this.adminService.testimonials=this.adminService.testimonials.filter((data:any) => data.id!=id)
    this.adminService.DeleteTestimonial(id);
  }
  ngOnInit(): void {
    this.adminService.getTestimonials();
  }

}
