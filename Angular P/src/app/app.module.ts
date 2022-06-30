import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastNoAnimationModule, ToastrModule } from 'ngx-toastr';
import { SpinnerComponent } from './spinner/spinner.component';
import { SharedModule } from './shared/shared/shared.module';
import { NgxScrollTopModule } from 'ngx-scrolltop';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from './interceptor/token.interseptor';


@NgModule({
  declarations: [AppComponent, SpinnerComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    ToastNoAnimationModule.forRoot(),
    SharedModule,
    NgxScrollTopModule
  ],
  providers: [{
     provide: HTTP_INTERCEPTORS,
     useClass: TokenInterceptor,
     multi: true
   }],
  bootstrap: [AppComponent],
})
export class AppModule {}
