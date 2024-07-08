import { Injectable, OnChanges, SimpleChanges } from '@angular/core';
import { PresentList } from '../models/present.model';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { Cart } from '../models/cart.model';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class CartService{

  constructor(private http:HttpClient) { }

  selectedPresents:Cart[] = [];
  private callToGetPresentSubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  callToGetPresent$: Observable<boolean> = this.callToGetPresentSubject.asObservable();
  setGetCart(){
    let flag = this.callToGetPresentSubject.value;
    this.callToGetPresentSubject.next(!flag);
   }
   getAllPresents() : Observable<Cart[]>{
    let url = 'https://localhost:7024/api/bItem/GetCartsByUserId'
    return this.http.get<Cart[]>(url)
    // .pipe(map(lh => this.selectedPresents = lh));
  }

  deleteById(id: number){
    let url = 'https://localhost:7024/api/bItem/DeletePresentFromCart?opId='+id
    return this.http.delete<number>(url)
  }

  createCart(){
    let url = 'https://localhost:7024/api/Bucket/AddCart'
    return this.http.post<number>(url,this.selectedPresents);
  }

  forPayment(){
    let url = 'https://localhost:7024/api/Bucket/GetTotalPrice'
    return this.http.get<number>(url);
  }
  

  Pay(){
    let url = 'https://localhost:7024/api/Bucket/Pay'
    return this.http.get<number>(url);
  }

  addToCart(present: Cart){
    let url = 'https://localhost:7024/api/bItem/AddPresentToCart'
    return this.http.post<number>(url, present);
  }

  getWinnerByPresentId(presentId:number){
    let url= 'https://localhost:7024/api/Ruffle/GetWinnerByPresentId?presentId='+presentId
    return this.http.get<User>(url)
  }
}
