import {Component, Input, OnInit, TemplateRef, ViewChild} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Title } from '@angular/platform-browser';
import { ToastrService } from 'ngx-toastr';
import { HomeService } from 'src/app/service/home.service';

@Component({
  selector: 'app-site-info',
  templateUrl: './site-info.component.html',
  styleUrls: ['./site-info.component.css']
})
export class SiteInfoComponent implements OnInit {
  
  @ViewChild('callUpdateDailog') callUpdateDailog!: TemplateRef<any>
  previous_data: any = {};
  images: any = [{}];
  constructor(private toaster: ToastrService,public dialog: MatDialog,public homeService: HomeService,private _formBuilder: FormBuilder) {}

  ngOnInit(): void {
    this.homeService.getDynamicData();
    // console.log(this.homeService.dynamicData[0]);
    // console.log(this.homeService.dynamicData);
    
    setTimeout(()=>{console.log(this.homeService.dynamicData);},2000) 
    setTimeout(()=>{console.log(this.homeService.dynamicData[0]);},2000) 
    setTimeout(()=>{console.log(this.homeService.dynamicData[0].webSiteName);},2000)

  }
  



  firstFormGroup = this._formBuilder.group({
    firstCtrl: ['', Validators.required],
  });
  secondFormGroup = this._formBuilder.group({
    secondCtrl: ['', Validators.required],
  });
  isLinear = true;

  updateform: FormGroup = new FormGroup({

    webSiteName: new FormControl(),
    title1: new FormControl(),
    subTitle1: new FormControl(),
    title2: new FormControl(),
    subTitle2: new FormControl(),
    popularParagraph: new FormControl(),
    footerParagraph: new FormControl(),
    aboutParagraph: new FormControl(),
    contactParagraph: new FormControl(),
    phoneNumber: new FormControl(),
    email: new FormControl(),
    address: new FormControl(),
    logoDark: new FormControl(),
    logoLight: new FormControl(),
    imgSlider1: new FormControl(),
    imgSlider2: new FormControl(),
    imgSlider3: new FormControl(),
    footerBackground: new FormControl(),
    aboutBackground: new FormControl(),
    contactImage: new FormControl(),
    headerBackgroud: new FormControl(),
    faviconIcon: new FormControl()
    

  })

  update(webSiteName1: any, title: any, subTitle: any, titleTwo: any, subTitleTwo: any, popularPara: any, footerPara: any, aboutPara: any, contactPara: any, phoneNum: any, email1: any, location: any,
    darkLogo: any, lightLogo: any, silder1: any, silder2: any, silder3: any, footerImg: any, aboutImg: any, contactImg: any, headerImg: any, faviconImg: any) {
    this.previous_data = {

      webSiteName: webSiteName1,
      title1: title,
      subTitle1: subTitle,
      title2: titleTwo,
      subTitle2: subTitleTwo,
      popularParagraph: popularPara,
      footerParagraph: footerPara,
      aboutParagraph: aboutPara,
      contactParagraph: contactPara,
      phoneNumber: phoneNum,
      email: email1,
      address: location,
      logoDark: darkLogo,
      logoLight: lightLogo,
      imgSlider1: silder1,
      imgSlider2: silder2,
      imgSlider3: silder3,
      footerBackground: footerImg,
      aboutBackground: aboutImg,
      contactImage: contactImg,
      headerBackgroud: headerImg,
      faviconIcon: faviconImg

    }
     //this.updateform.controls['logoDark'].setValue(this.previous_data.logoDark);
    // this.updateform.controls['logoLight'].setValue(this.previous_data.logoLight);
    // this.updateform.controls['imgSlider1'].setValue(this.previous_data.imgSlider1);
    // this.updateform.controls['imgSlider2'].setValue(this.previous_data.imgSlider2);
    // this.updateform.controls['imgSlider3'].setValue(this.previous_data.imgSlider3);
    // this.updateform.controls['footerBackground'].setValue(this.previous_data.footerBackground);
  //  this.dialog.open(this.callUpdateDailog);
  }
  updateHome1(){
    this.homeService.updateDynamicData(this.updateform.value);
  }
  updateHome(img1:any,img2:any,img3:any,img4:any,img5:any,img6:any,img7:any,img8:any,img9:any,img10:any) {

    if(img1.length == 0 && img2.length == 0 && img3.length == 0 && img4.length == 0 && img5.length == 0 && img6.length == 0 && img7.length == 0 && img8.length == 0 && img9.length == 0 && img10.length == 0){
      if(this.updateform.valid){
        this.homeService.updateDynamicData(this.updateform.value);
        setTimeout(() => {
         // window.location.reload();
        }, 2000); 
      }
      else{
        this.toaster.error('You Must Fill The Fields First');
      }  
    }else{
      const formData = new FormData();
      
      if(img1.length!=0){
      let fileToUpload1 = <File>img1[0];
      let path1:any = fileToUpload1.name.split('\\').pop();
      formData.append('file1', fileToUpload1, fileToUpload1.name);
      this.updateform.value.logoDark = path1;
      }

      if(img2.length!=0){
      let fileToUpload2 = <File>img2[0];
      let path2:any = fileToUpload2.name.split('\\').pop();
      formData.append('file2', fileToUpload2, fileToUpload2.name);
      this.updateform.value.logoLight = path2;
      }

      if(img3.length!=0){
      let fileToUpload3 = <File>img3[0];
      let path3:any = fileToUpload3.name.split('\\').pop();
      formData.append('file3', fileToUpload3, fileToUpload3.name);
      this.updateform.value.imgSlider1 = path3;
      }

      if(img4.length!=0){
      let fileToUpload4 = <File>img4[0];
      let path4:any = fileToUpload4.name.split('\\').pop();
      formData.append('file4', fileToUpload4, fileToUpload4.name);
      this.updateform.value.imgSlider2 = path4;
      }

      if(img5.length!=0){
      let fileToUpload5 = <File>img5[0];
      let path5:any = fileToUpload5.name.split('\\').pop();
      formData.append('file5', fileToUpload5, fileToUpload5.name);
      this.updateform.value.imgSlider3 = path5;
      }

      if(img6.length!=0){
      let fileToUpload6 = <File>img6[0];
      let path6:any = fileToUpload6.name.split('\\').pop();
      formData.append('file6', fileToUpload6, fileToUpload6.name);
      this.updateform.value.footerBackground = path6;
      }

      if(img7.length!=0){
      let fileToUpload7 = <File>img7[0];
      let path7:any = fileToUpload7.name.split('\\').pop();
      formData.append('file7', fileToUpload7, fileToUpload7.name);
      this.updateform.value.headerBackgroud = path7;
      }

      if(img8.length!=0){
      let fileToUpload8 = <File>img8[0];
      let path8:any = fileToUpload8.name.split('\\').pop();
      formData.append('file8', fileToUpload8, fileToUpload8.name);
      this.updateform.value.faviconIcon = path8;
      }

      if(img9.length!=0){
      let fileToUpload9 = <File>img9[0];
      let path9:any = fileToUpload9.name.split('\\').pop();
      formData.append('file9', fileToUpload9, fileToUpload9.name);
      this.updateform.value.aboutBackground = path9;
      }

      if(img10.length!=0){
      let fileToUpload10 = <File>img10[0];
      let path10:any = fileToUpload10.name.split('\\').pop();
      formData.append('file10', fileToUpload10, fileToUpload10.name);
      this.updateform.value.contactImage = path10;
      }

      console.log(this.updateform.value);
      if(this.updateform.valid){
        this.homeService.updateDynamicDataWithImage(this.updateform.value, formData);
        setTimeout(() => {
         // window.location.reload();
        }, 2000); 
      }
      else{
        this.toaster.error('You Must Fill The Fields First');
      }  
    }
  }
}