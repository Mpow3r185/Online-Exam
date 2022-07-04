import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SwiperModule } from 'swiper/angular';
import {MatInputModule} from '@angular/material/input';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { HttpClientModule} from '@angular/common/http';
import {MatDialogModule} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
import { NgxPaginationModule } from 'ngx-pagination';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import {MatTableModule} from '@angular/material/table';
//import {NgxPrintModule} from 'ngx-print';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    SwiperModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    //NgxPrintModule,
    HttpClientModule,
    MatDialogModule,
    MatButtonModule,
    NgxPaginationModule,
    Ng2SearchPipeModule,
    MatTableModule,
  ],
  exports: [
    CommonModule,
    SwiperModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    //NgxPrintModule,
    HttpClientModule,
    MatDialogModule,
    MatButtonModule,
    NgxPaginationModule,
    Ng2SearchPipeModule,
    MatTableModule,
  ]
})
export class SharedModule { }
