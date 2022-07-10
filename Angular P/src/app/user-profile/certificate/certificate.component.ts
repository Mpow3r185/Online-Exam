import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { UserService } from 'src/app/service/user.service';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';
import { CertificatedetailsComponent } from './certificatedetails/certificatedetails.component';

@Component({
  selector: 'app-certificate',
  templateUrl: './certificate.component.html',
  styleUrls: ['./certificate.component.css']
})
export class CertificateComponent implements OnInit {

 
 
  constructor(public userService:UserService,private dialog: MatDialog) { }

  async ngOnInit() {
    SpinnerComponent.show();
    
    await this.userService.GetCertificateByUserId();

    setTimeout(() => {
      SpinnerComponent.hide();
    }, 2000);
  }

    //-------------------------------------------------------
  //For See Details
  previous_data: any = {}; // empty obj
  openDetailsDialog(ICreation: any, EName: any, ELevel: any, examDate:any) {
    this.previous_data = { 
      CertificateCreationDate: ICreation,
      examName: EName, 
      examLevel: ELevel, 
      examDate: examDate
    }
  
    const dialogRef = this.dialog.open(CertificatedetailsComponent,{
      width: '100%',
      height: '90%',
      data: {
        dataKey: this.previous_data
      }
    });
   
  }


}
