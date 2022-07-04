import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AdminService } from 'src/app/service/admin.service';

@Component({
  selector: 'app-create-service',
  templateUrl: './create-service.component.html',
  styleUrls: ['./create-service.component.css']
})
export class CreateServiceComponent implements OnInit {

  constructor(private adminService:AdminService,private toastr: ToastrService) { }

  ngOnInit(): void {
  }


  createForm: FormGroup = new FormGroup({
    title: new FormControl('', Validators.required),
    text: new FormControl('', Validators.required)
  });

  SaveService() {
    if(this.createForm.valid){
      this.adminService.CreateServices(this.createForm.value);
      setTimeout(() => {
        window.location.reload();
      }, 2000); 
    }
    else{
      this.toastr.error('You Must Fill The Fields First');
    }
  }
}
