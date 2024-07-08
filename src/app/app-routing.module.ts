import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
// import { PresentListComponent } from './present-list/present-list.component';
// import { HomeComponent } from './home/home.component';
import { PresentsComponent } from './primeNg/presents/presents.component';
import { HomeComponent } from './home/home.component';
import { PurchasePresentComponent } from './purchase-present/purchase-present.component';
import { PaymentComponent } from './payment/payment.component';
import { DonorListComponent } from './Donor/donor-list/donor-list.component';
import { CartComponent } from './cart/cart.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { WinnerComponent } from './winner/winner.component';
import { DetailsComponent } from './details/details.component';




const routes: Routes = [ 
  {path:"register",component:RegisterComponent},
  {path:"",component:LoginComponent},
  {path:"home",component:HomeComponent},
  {path:"present",component:PresentsComponent},
  {path:"donor",component:DonorListComponent},
  {path:"Purchase",component:PurchasePresentComponent},
  {path:'cart',component:CartComponent},
  {path:'pay',component:PaymentComponent},
  {path:'raffle',component:WinnerComponent},
  {path:'winners',component:WinnerComponent},
  {path:'users',component:DetailsComponent},
 
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
   ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
