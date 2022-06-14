import { HttpClient, HttpEventType } from '@angular/common/http';
import { Component, OnInit, Output , EventEmitter } from '@angular/core';
import { AuthenticationService } from '../service/authentication.service';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.scss']
})
export class UploadComponent implements OnInit {
  public message!: string;
  public progress!: number;
  @Output() public onUploadFinished = new EventEmitter();
  constructor(private http : HttpClient, public authService: AuthenticationService) { }

  ngOnInit(): void {
  }
  public uploadFile=(files: any)=>{
    if (files.length == 0)
      return ;

      let fileToUpload =<File>files[0];
      const formData = new FormData();
      formData.append('file' , fileToUpload,fileToUpload.name);
      this.http.post('https://localhost:44359/api/Advertisement/Image',formData,
      {reportProgress:true , observe:'events'})
      .subscribe((event: any) => {
        if (event.type === HttpEventType.UploadProgress) {
          this.progress = Math.round(100 * event.loaded / event.total);
        }
        else if (event.type === HttpEventType.Response) {
          this.message = "upload success";
          this.onUploadFinished.emit(event.body);
        }
      });

  }


}
