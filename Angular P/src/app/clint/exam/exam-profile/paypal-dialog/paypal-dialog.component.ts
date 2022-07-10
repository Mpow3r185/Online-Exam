import { ToastrService } from 'ngx-toastr';
import { HomeService } from './../../../../service/home.service';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { render } from 'creditcardpayments/creditCardPayments';


@Component({
  selector: 'app-paypal-dialog',
  templateUrl: './paypal-dialog.component.html',
  styleUrls: ['./paypal-dialog.component.css']
})
export class PaypalDialogComponent implements OnInit {

  constructor(
    public dialog: MatDialog,
    public homeService: HomeService,
    private toastr: ToastrService
    ) { 
    
  }

  ngOnInit(): void {
    render (
      {
        id: "#myPaypalButtons",
        currency: "USD",
        value: `${this.homeService.exams.cost}`,
        onApprove: (details) => {
          this.homeService.createInvoice(this.homeService.exams.id, Number(localStorage.getItem('AccountId')));  // Create Invoice
          this.toastr.success("Transaction Successfull");
        },
      }
    )
  }

  

}
