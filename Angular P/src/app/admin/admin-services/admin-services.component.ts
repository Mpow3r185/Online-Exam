import { AfterViewInit, Component, Input, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { AdminService } from 'src/app/service/admin.service';
import { HomeService } from 'src/app/service/home.service';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';
import { CreateServiceComponent } from './create-service/create-service.component';
declare const $:any;

@Component({
  selector: 'app-admin-services',
  templateUrl: './admin-services.component.html',
  styleUrls: ['./admin-services.component.css']
})
export class AdminServicesComponent implements OnInit,AfterViewInit {

   //This For Update Course Dialog
   @ViewChild('callUpdateDialog') callUpdateDialog!: TemplateRef<any>;
  
   //This For Delete Course Dialog
   @ViewChild('callDeleteDialog') callDeleteDialog!: TemplateRef<any>;
   @Input() serviceTitle: string | undefined;
   

  constructor(public homeService:HomeService ,public adminService: AdminService,private dialog: MatDialog, private toastr: ToastrService) { }
  
  ngAfterViewInit(): void {
    setTimeout(() => {
      $('#dtTable1').DataTable( {
        pageLength: 5,
        processing: true
    } );
    }, 3000);
  }

  ngOnInit(): void {
    SpinnerComponent.show();
    this.homeService.getAllServices();
    setTimeout(() => {
      SpinnerComponent.hide();
    }, 3000);
  }

  
  //-------------------------------------------------------
  //For Create Service 
  CreateServiceDialog() {
    const dialogRef = this.dialog.open(CreateServiceComponent);
  }

  //-------------------------------------------------------
  //For Update Service Information
  updateForm: FormGroup = new FormGroup({
    id: new FormControl(),
    title: new FormControl('', Validators.required),
    text: new FormControl('', Validators.required)
  });

  previous_data: any = {}; // empty obj
  openUpdateDialog(id: any, title: any, Description: any) {
    this.previous_data = {
      id: id, 
      title: title, 
      text: Description
    }

    this.updateForm.controls['id'].setValue(this.previous_data.id);
    this.dialog.open(this.callUpdateDialog);
  }
  
  updateCourse() {
    if(this.updateForm.valid){
      this.adminService.UpdateServices(this.updateForm.value);
      setTimeout(() => {
        window.location.reload();
      }, 2000); 
    }
    else{
      this.toastr.error('You Must Fill The Fields First');
    }  
  }

  //-------------------------------------------------------
  //Delete Service Dialog
  openDeleteDialog(id: number, Name:string) {
    this.serviceTitle = Name;
    const dialogRef = this.dialog.open(this.callDeleteDialog);

    dialogRef.afterClosed().subscribe((result) => {
      if (result != undefined) {
          if (result == 'yes') {
            this.adminService.DeleteServices(id);
            setTimeout(() => {
              window.location.reload();
            }, 2000); 
            
          }
      }
    })
  }

}
