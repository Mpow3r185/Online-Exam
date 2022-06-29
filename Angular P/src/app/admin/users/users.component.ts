import { AfterViewInit, Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { AdminService } from 'src/app/service/admin.service';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';
declare const $:any;

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
})
export class UsersComponent implements OnInit,AfterViewInit {
  
 
 //This For Details  Dialog
 @ViewChild('callDetailsDialog') callDetailsDialog!: TemplateRef<any>;
  
  constructor(public adminService: AdminService, private dialog: MatDialog, private toastr: ToastrService) {}
 
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
    this.adminService.getAllAccounts();
    setTimeout(() => {
      SpinnerComponent.hide();
    }, 3500);

  }

  

  //-------------------------------------------------------
  //For See Details
  previous_data: any = {}; // empty obj
  openDetailsDialog(userName: any, fullName: any, email: any, gender: any, bod:any, address:any, status:any, profileImage:any, rolName:any) {
    this.previous_data = { 
      fullName: fullName, 
      userName: userName, 
      email: email,
      gender: gender,
      bod: bod, 
      address: address, 
      status: status,
      roleName: rolName, 
      Image: profileImage
    }
    this.dialog.open(this.callDetailsDialog);
  }

  //-------------------------------------------------------
  //For Block Account
  Update_data: any = {}; // empty obj
  BlockAccount(id:any,userName:any,fullName:any,password:any,email:any,gender:any,
    bod:any,address:any,profilePicture:any,roleName:any){
      this.Update_data = { 
        id:id,
        fullname: fullName, 
        username: userName, 
        password:password,
        email: email,
        gender: gender,
        bod: bod, 
        address: address, 
        status: 'BLOCK',
        rolename: roleName, 
        profilePicture: profilePicture
      }
      this.adminService.updateAccount(this.Update_data); 
      setTimeout(() => {
        window.location.reload();
      }, 2000); 
  }

  ////For UnBlock Account
  UnBlockAccount(id:any,userName:any,fullName:any,password:any,email:any,gender:any,
    bod:any,address:any,profilePicture:any,roleName:any){
      this.Update_data = { 
        id:id,
        fullname: fullName, 
        username: userName, 
        password:password,
        email: email,
        gender: gender,
        bod: bod, 
        address: address, 
        status: 'OK',
        rolename: roleName, 
        profilePicture: profilePicture
      } 
      this.adminService.updateAccount(this.Update_data); 
      setTimeout(() => {
        window.location.reload();
      }, 2000); 
  }

  
}
