import { Component, Input, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { HomeService } from 'src/app/service/home.service';
import { UserService } from 'src/app/service/user.service';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';




@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  // @Input() id: number | undefined;
  // @Input() fullName: string | undefined;
  // @Input() email: string | undefined;
  // @Input() phoneNumber: number | undefined;
  // @Input() address!: string | undefined;
  // @Input() gender: string | undefined;
  // @Input() birthOfDate: string | undefined;
  // @Input() profilePicture: string | undefined;
  

  @ViewChild('callUpdateDailog') callUpdateDailog!: TemplateRef<any>
  previous_data: any = {};
  constructor(public dialog: MatDialog,public userService: UserService,public homeService: HomeService) { }

  async ngOnInit(): Promise<void> {
    
   SpinnerComponent.show();
    await this.userService.getUserById();
    setTimeout(()=>{
      SpinnerComponent.hide();
    },2000) ;
   
    // let user: any = localStorage.getItem('token');
    // user = JSON.parse(user);
    // console.log(localStorage.getItem('user'));
    // console.log(user.primarysid);
  
      // console.log(this.updateform.value);
    

    
  
     
  }
  updateform: FormGroup = new FormGroup({

    id: new FormControl('', Validators.required),

    fullName: new FormControl('', Validators.required),

    email: new FormControl('', Validators.required),

    phoneNumbers: new FormControl('', Validators.required),

    address: new FormControl('', Validators.required),
    gender: new FormControl('', Validators.required),
    bod: new FormControl('', Validators.required),
    

   // profilePicture: new FormControl()

  })
  openUpdateDailog(id1: any, fullName1: any, email1: any, phoneNumber1: any, address1: any, gender1: any, birthOfDate1: any) {

    this.previous_data = {

      id: id1,

      fullName: fullName1,

      email: email1,

      phoneNumbers: phoneNumber1,

      address: address1,

      gender: gender1,

      bod: birthOfDate1,
     // profilePicture: profilePicture1
    }
    // uploadImage(file: any){
    //   console.log(file);
    //   if(file.length == 0)
    //      return ;
    //   let imageUploaded=<File>file[0];
    //   const formData = new FormData();
    //   formData.append('file',imageUploaded, imageUploaded.name);    
    //   this.home.uploadImage(formData);
    // }
   

    this.updateform.controls['id'].setValue(this.previous_data.id);

    this.dialog.open(this.callUpdateDailog);

  }
  async editProfile(): Promise<void> {
    console.log(this.previous_data.value);
    setTimeout(() => {
      console.log(this.updateform.value);
     this.userService.editAccount(this.updateform.value);
    }, 2000);
    
    //this.userService.updateUser();
    

    // window.location.reload();

  }
  


}
