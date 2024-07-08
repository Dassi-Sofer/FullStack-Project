import { Component, OnInit } from '@angular/core';
import { PresentList } from '../models/present.model';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { CartService } from '../services/cart.service';
import { Cart } from '../models/cart.model';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit{

  selectedPresent:Cart[] = []
  g:boolean = true
  constructor(public  cartService:CartService, private router:Router) {}
ngOnInit() {
  this.cartService.getAllPresents().subscribe(data=> this.selectedPresent = data);
}
DeleteItem(itemId:number){
  console.log(this.selectedPresent,"aaaa");
  this.cartService.deleteById(itemId).subscribe(data=> {console.log(data),  this.cartService.getAllPresents().subscribe(data=> this.selectedPresent = data)});
  

  console.log(this. cartService,"del1");
}

toPay(){
  this.cartService.forPayment().subscribe((data) =>console.log(data) );
 
  this.router.navigate(['pay'])
}
}
