import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { HomeService } from './home.service';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  testimonials: any = [{}];

  constructor(
    private http: HttpClient,
    public homeSerivce: HomeService,
    private toastr: ToastrService) { }



  // Get Testimonial
  async getTestimonials() {
    this.http.get('https://localhost:44342/api/testimonial').subscribe((result) => {
      this.testimonials = result;
    }, error => {
      this.toastr.error('Unable to connect the server.')
    });
  }

  // update Testimonial
  updateTestimonial(body: any) {
    this.http.put('https://localhost:44342/api/testimonial', body).subscribe((result) => {
      this.toastr.success('ok')
    }, error => {
      this.toastr.error('error')
    });
  }

  // Delete Testimonial
  DeleteTestimonial(id: number) {
    this.http.delete('https://localhost:44342/api/testimonial/deleteTestimonial/' + id).subscribe((result) => {
      this.toastr.success('rejected')
    }, error => {
      this.toastr.error('error')
    });
  }
}
