import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastNoAnimationModule, ToastrModule } from 'ngx-toastr';
import { SpinnerComponent } from './spinner/spinner.component';
import { SharedModule } from './shared/shared/shared.module';

@NgModule({
  declarations: [AppComponent, SpinnerComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    ToastNoAnimationModule.forRoot(),
    SharedModule
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
