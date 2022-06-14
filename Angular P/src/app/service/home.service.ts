import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { SpinnerComponent } from '../spinner/spinner.component';

@Injectable({
  providedIn: 'root',
})
export class HomeService {
  data: any;
  testimonialData: any = [];
  selectedTestimonial: any;

  testimonialForm: FormGroup = new FormGroup({
    title: new FormControl('', Validators.required),
    massege: new FormControl('', Validators.required),
    isActive: new FormControl(),
    userId: new FormControl(),
  });

  constructor(
    private http: HttpClient,
    private toastr: ToastrService,
    private dialog: MatDialog
  ) {}

  getFirstTestimonial() {
    for (const key in this.testimonialData) {
      if (this.testimonialData[key].isActive) {
        this.selectedTestimonial = this.testimonialData[key];
        break;
      }
    }
  }

  getTestimonial(value: any) {
    const identifier = value;

    for (const key in this.testimonialData) {
      if (this.testimonialData[key].id === identifier) {
        this.selectedTestimonial = this.testimonialData[key];
      }
    }
  }

  getAllTestimonials() {
    this.http.get('https://localhost:44359/api/Testimonial').subscribe(
      (result) => {
        this.testimonialData = result;
      },
      (error) => console.log(error)
    );
  }

  createTestimonial() {
    const headerDict = {
      'Content-Type': 'application/json',
      Accept: 'application/json',
    };
    const requestOptions = {
      headers: new HttpHeaders(headerDict),
    };
    let user: any = localStorage.getItem('user');
    user = JSON.parse(user);
    const id = parseInt(user.primarysid);

    this.testimonialForm.controls.isActive.setValue(0);
    this.testimonialForm.controls.userId.setValue(id);

    SpinnerComponent.show();
    this.dialog.closeAll();
    if (this.testimonialForm.valid) {
      this.http
        .post(
          'https://localhost:44359/api/Testimonial',
          this.testimonialForm.value,
          requestOptions
        )
        .subscribe(
          (result) => {
            if (result == 'Sucessfully') {
              setTimeout(() => {
                SpinnerComponent.hide();
              }, 2000);
              setTimeout(() => {
                this.toastr.success('Success Processing');
              }, 2000);
            }
          },
          (error) => {
            if (error.status != 200) {
              setTimeout(() => {
                SpinnerComponent.hide();
              }, 2000);
              setTimeout(() => {
                this.toastr.error('failed processing, Please try again');
              }, 2000);
            }
          }
        );
    } else {
      setTimeout(() => {
        SpinnerComponent.hide();
      }, 2000);
      setTimeout(() => {
        this.toastr.error('failed processing, Please try again');
      }, 2000);
    }
  }

  updateTestimonial(id: number) {
    this.http.put('https://localhost:44359/api/Testimonial', {Id: id}).subscribe(
      result => {}
    );
  }
}
