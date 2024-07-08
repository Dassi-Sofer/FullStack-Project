import { Component, OnInit } from '@angular/core';
import { PurchasePresentComponent } from '../purchase-present/purchase-present.component';
import { CartService } from '../services/cart.service';
import { InputMaskModule } from 'primeng/inputmask';
import { Data, Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';



@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {
  cartForm : FormGroup=new FormGroup({});
  emailReg:RegExp=new RegExp('[]@[a-z].[a-z]')

  constructor(public  cartService:CartService,  private router:Router) {
  this.cartForm=new FormGroup({

    creditCard: new FormControl(null,[Validators.required, Validators.minLength(12),Validators.maxLength(12)]),
    cvc: new FormControl(null, [Validators.required,Validators.minLength(3),Validators.maxLength(3)]),
    id: new FormControl(null, [Validators.required, Validators.minLength(9),Validators.maxLength(9)]),
    validity: new FormControl(null, [Validators.required])                   
  });
}
showIcon:boolean=false;
readonlyInput:boolean=false;
   price:number=0;
   
 
  ngOnInit(): void {
    this.cartService.forPayment().subscribe(data=>{this.price = data 
    } )
  }

  ngOnChanges(){
    this.cartService.forPayment().subscribe(data=>{this.price = data 
    } )
    this.cartForm=new FormGroup({  
  

      // username: new FormControl(null,[Validators.required, Validators.minLength(3),Validators.maxLength(30)]),
      // password: new FormControl(null, [Validators.required, Validators.minLength(5),Validators.maxLength(5)]),
      creditCard: new FormControl(null,[Validators.required, Validators.minLength(16),Validators.maxLength(16)]),
      cvc: new FormControl(null, [Validators.required,Validators.min(3),Validators.maxLength(3)]),
      id: new FormControl(null, [Validators.required, Validators.minLength(9),Validators.maxLength(9)]),
      email: new FormControl(null, [Validators.required,Validators.pattern(this.emailReg)]),
      validity: new FormControl(null, [Validators.required])
    });
  }
  
  creditCard:number|undefined;
  validity:Data|undefined;
  cvc:number|undefined;
  id:string|undefined;

  save(): void{
    
    this.cartService.Pay().subscribe(data => {
      if(data == 0)
      alert("התשלום התקבל בהצלחה")
      this.router.navigate(['pay'])
    }
    )
  }

  back(){
    this.router.navigate(['cart'])
  }

  
  // send(){
  //   this.user.username = this.username
  //   this.user.password = this.password
  //   this.user.fullName = this.fullName
  //   this.user.email = this.email
  //   this.user.phone = this.phone
  //   this.userService.createUser(this.user).subscribe((data)=>{
  //     console.log(data)
  //     if(data)
  //     this.router.navigate([''])
  //     else
  //     window.alert("username or password duplicate")
  //   })
  // }
}
