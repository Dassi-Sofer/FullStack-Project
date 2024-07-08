import { Component } from '@angular/core';
import { PresentService } from '../services/present.service';
import { PresentList } from '../models/present.model';
import { Router } from '@angular/router';
import { CartService } from '../services/cart.service';
import { Cart } from '../models/cart.model';
import { User } from '../models/user.model';


@Component({
  selector: 'app-purchase-present',
  templateUrl: './purchase-present.component.html',
  styleUrls: ['./purchase-present.component.css']
})
export class PurchasePresentComponent {

  SelectCost: boolean=false;
  SelectCategory: boolean=false;
  myPresent:PresentList[]=[];

  constructor(public presentService:PresentService,public cartService:CartService, private router:Router) {  }
  ngOnInit(): void {
    this.presentService.callToGetPresent$.subscribe(x=>{
      this.presentService.getAllPresents().subscribe(lp=> {this.presentService.myPresent=lp
        this.presentService.myPresent.forEach(p => {
            if(p.isRuffled == true)           
              this.cartService.getWinnerByPresentId(p.id).subscribe(data=>p.winner=data)
        });
      });
       this.cartService.createCart().subscribe(data=> this.saveOrderId(data))
      //this.cartService.createCart().subscribe(d=>console.log(d,"uuuuuu"));
      
      
    })
    
}


Id:number = 210;
saveOrderId(data:number){
  console.log(data);
  
  sessionStorage.setItem("orderId", JSON.stringify(data));
}


addToCart(item:PresentList){
  console.log(item)
  let cart:Cart = new Cart();
  let index = this.cartService.selectedPresents.findIndex(sp => sp.id == item.id)
  if(index != -1)
    this.cartService.selectedPresents[index].quantity++;
  else{
    cart.quantity = 1;
    this.cartService.selectedPresents.push(cart);
  }
  // cart.id = this.Id++;
  cart.presentId = item.id;
  let id = sessionStorage.getItem("orderId");
  if(id)
  cart.bucketId= parseInt(id);

  console.log(cart)
  this.cartService.addToCart(cart).subscribe(data=>{
    // if(data==-1)
    // this.cartService.getWinnerByPresentId(cart.presentId).subscribe(d => this.winner = d)
    

     console.log(data)});


  console.log(this.cartService.selectedPresents); 
}

GoToCart(){
  console.log('go')
  this.router.navigate(['cart'])
}

sortByCost(){
  this.SelectCost==true;
  var a=1;
  var b=a.toString;
    this.presentService.sort(true,false).subscribe((data)=>{
      this.presentService.myPresent=data
    })
    this.presentService.sort(false,true).subscribe(lp=> {this.presentService.myPresent=lp
      this.presentService.myPresent.forEach(p => {
          if(p.isRuffled == true)           
            this.cartService.getWinnerByPresentId(p.id).subscribe(data=>p.winner=data)
      });
    })
  }
  sortByCategory(){
    this.SelectCategory==true;
    var a=1;
    var b=a.toString
    this.presentService.sort(true,false).subscribe((data)=>{
      this.presentService.myPresent=data
    })
      this.presentService.sort(false,true).subscribe(lp=> {this.presentService.myPresent=lp
        this.presentService.myPresent.forEach(p => {
            if(p.isRuffled == true)           
              this.cartService.getWinnerByPresentId(p.id).subscribe(data=>p.winner=data)
        });
      })
    }
}
