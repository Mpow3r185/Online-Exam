import { Component, Input, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { HomeService } from 'src/app/service/home.service';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-admin-profile',
  templateUrl: './admin-profile.component.html',
  styleUrls: ['./admin-profile.component.css']
})
export class AdminProfileComponent implements OnInit {

  previous_data: any = {};

  @ViewChild('callUpdateDailog') callUpdateDailog!: TemplateRef<any>

  constructor(private toaster: ToastrService,public dialog: MatDialog,public userService: UserService,public homeService: HomeService) { }

  async ngOnInit(): Promise<void> {
    
    await this.userService.getUserById();
   // setTimeout(()=>{console.log(this.homeService.selectedUser);},2000) 
     
  }
  updateform: FormGroup = new FormGroup({

    id: new FormControl(),
    fullName: new FormControl('', Validators.required),
    email: new FormControl('', Validators.required),
    phoneNumbers: new FormControl(),
    address: new FormControl('', Validators.required),
    gender: new FormControl('', Validators.required),
    bod: new FormControl('', Validators.required),
    profilePicture: new FormControl()

  })
  openUpdateDailog(id1: any, fullName1: any, email1: any, phoneNumber1: any, address1: any, gender1: any, birthOfDate1: any,profilePicture1: any) {

    this.previous_data = {

      id: id1,
      fullName: fullName1,
      email: email1,
      phoneNumbers: phoneNumber1,
      address: address1,
      gender: gender1,
      bod: birthOfDate1,
      profilePicture: profilePicture1
    }
   

    this.updateform.controls['id'].setValue(this.previous_data.id);
    this.updateform.controls['gender'].setValue(this.previous_data.gender);
    this.updateform.controls['profilePicture'].setValue(this.previous_data.profilePicture);

    this.dialog.open(this.callUpdateDailog);

  }

  editProfile(img:any) {
    console.log(this.updateform.value);
    if(img.length == 0){
      this.updateform.controls['gender'].setValue(this.previous_data.gender);
      if(this.updateform.valid){
        console.log(this.updateform.value);
        this.userService.editAccount(this.updateform.value);
        setTimeout(() => {
          window.location.reload();
        }, 2000); 
      }
      else{
        this.toaster.error('You Must Fill The Fields First');
      }  
    }else{
      let fileToUpload = <File>img[0];
      const formData = new FormData();
      formData.append('file', fileToUpload, fileToUpload.name);
      this.updateform.controls['gender'].setValue(this.previous_data.gender);
      if(this.updateform.valid){
        this.userService.editAccountWithImage(this.updateform.value,formData);
        setTimeout(() => {
          window.location.reload();
        }, 2000); 
      }
      else{
        this.toaster.error('You Must Fill The Fields First');
      }  
    }
  }

}
