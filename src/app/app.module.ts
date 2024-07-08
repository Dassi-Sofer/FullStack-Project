import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { ModelComponent } from './modal/model.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { PresentsComponent } from './primeNg/presents/presents.component';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { ToolbarModule } from 'primeng/toolbar';
import { TableModule } from 'primeng/table';
import { DialogModule } from 'primeng/dialog';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PresentComponent } from './primeNg/present/present.component';
import { RouterModule } from '@angular/router';
import { PaymentComponent } from './payment/payment.component';
import { DonorListComponent } from './Donor/donor-list/donor-list.component';
import { PurchasePresentComponent } from './purchase-present/purchase-present.component';
import { HttpClientModule } from '@angular/common/http';
import { SecondDonorComponent } from './Donor/second-donor/second-donor.component';
import { CardModule } from 'primeng/card';
import { RippleModule } from 'primeng/ripple';
import { CartComponent } from './cart/cart.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { DataViewModule } from 'primeng/dataview';
import { UserPresentComponent } from './user-present/user-present.component';
import { PurchaseAdminComponent } from './purchase-admin/purchase-admin.component';
import { InputMaskModule } from 'primeng/inputmask';
import { MultiSelectModule } from 'primeng/multiselect';
import {CalendarModule} from 'primeng/calendar';
import {InputNumberModule} from 'primeng/inputnumber';
import {MessagesModule} from 'primeng/messages';
import {MessageModule} from 'primeng/message';
import { KeyFilterModule } from 'primeng/keyfilter';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from './TokenInterceptor'
import { LoginService } from './services/user.service';
import { PresentService } from './services/present.service';
import { DonorService } from './services/donor.service';
import { CartService } from './services/cart.service';
import { UserComponent } from './user/user.component';
import { WinnerComponent } from './winner/winner.component';
import { DetailsComponent } from './details/details.component';

///////////////////////////////////////////////////
// import { BrowserModule } from '@angular/platform-browser';
// import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
// import { NgModule } from '@angular/core';
// import { FormsModule, ReactiveFormsModule } from '@angular/forms';

// import { ImageUploadComponent } from './components/image-upload/image-upload.component';
// import { ImageDisplayComponent } from './components/image-display/image-display.component';
// import { AppComponent } from './app.component';
////////////////////////////////////////////////////

@NgModule({
  declarations: [
    AppComponent,
  
    ModelComponent,
    HomeComponent,
    PresentsComponent,
    PresentComponent,
    PaymentComponent,
    DonorListComponent,
    PurchasePresentComponent,
    SecondDonorComponent,
    CartComponent,
    LoginComponent,
    RegisterComponent,
    UserPresentComponent,
    PurchaseAdminComponent,
    UserComponent,
    WinnerComponent,
    DetailsComponent,
  
   
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule ,
    ToolbarModule,
    TableModule,
    InputTextModule,
    ButtonModule,
    DialogModule,
    HttpClientModule,
    CardModule,
    DataViewModule,
    RippleModule,
    InputMaskModule,
    MultiSelectModule,
    CalendarModule,
    InputNumberModule,
    MessageModule,
    MessagesModule,
    KeyFilterModule


    
  
   
  ],
  providers: [LoginService, PresentService, DonorService, CartService, { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true }],
  bootstrap: [AppComponent]

 
})
export class AppModule { }
