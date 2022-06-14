import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { SpinnerComponent } from '../spinner/spinner.component';

@Injectable({
  providedIn: 'root',
})
export class ContactService {
  contactForm: FormGroup = new FormGroup({
    Name: new FormControl('', Validators.required),
    Email: new FormControl('', [Validators.required, Validators.email]),
    Massege: new FormControl('', Validators.required),
  });
  contactInfo:any=[];
  constructor(private http: HttpClient, private toastr: ToastrService) {}

  createContact() {
    const headerDict = {
      'Content-Type': 'application/json charset=utf-8',
    };

    const requestOptions = {
      headers: new HttpHeaders(headerDict),
    };
    SpinnerComponent.show();
    // debugger
    if (this.contactForm.valid) {
      this.http
        .post(
          'https://localhost:44359/api/ContactUs',
          this.contactForm.value,
          requestOptions
        )
        .subscribe(
          (result) => {},
          (error) => {
            
            if (error.status != 200) {
              setTimeout(() => SpinnerComponent.hide(), 2000);
              setTimeout(
                () => this.toastr.error('Failed Processing, Please try again'),
                2000
              );
            } else {
              setTimeout(() => SpinnerComponent.hide(), 2000);
              setTimeout(() => this.toastr.success('Success Processing'), 2000);
            }
          }
        );
    } else {
      setTimeout(() => SpinnerComponent.hide(), 2000);
      setTimeout(
        () => this.toastr.error('Failed Processing, Please try again'),
        2000
      );
    }
  }

  getAllContact() {
    SpinnerComponent.show();

    this.http
      .get('https://localhost:44359/api/ContactUs')
      .subscribe((result: any) => {
        this.contactInfo = result;
        setTimeout(() => {
          SpinnerComponent.hide();
        }, 2000);
      });
  }
}
