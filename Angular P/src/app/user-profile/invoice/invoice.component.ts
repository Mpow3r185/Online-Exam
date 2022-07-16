import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { UserService } from 'src/app/service/user.service';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';
import { InvoiceDetailsComponent } from './invoice-details/invoice-details.component';

@Component({
  selector: 'app-invoice',
  templateUrl: './invoice.component.html',
  styleUrls: ['./invoice.component.css']
})
export class InvoiceComponent implements OnInit {

  //This For Details  Dialog
 //@ViewChild('callDetailsDialog') callDetailsDialog!: TemplateRef<any>;
  
 
  constructor(public userService:UserService,private dialog: MatDialog) { }

  async ngOnInit() {
    SpinnerComponent.show();
    
    await this.userService.GetInvoicesByUserId();

    setTimeout(() => {
      SpinnerComponent.hide();
    }, 2000);    
  }

  
  //-------------------------------------------------------
  //For See Details
  previous_data: any = {}; // empty obj
  openDetailsDialog(EName: any, ELevel: any, ECost: any, ICreation: any) {
    this.previous_data = { 
      examName: EName, 
      examLevel: ELevel, 
      examCost: ECost,
      InvoiceCreationDate: ICreation
    }
  
    const dialogRef = this.dialog.open(InvoiceDetailsComponent,{
      width: '100%',
      height: '90%',
      data: {
        dataKey: this.previous_data
      }
    });
   
  }


}
