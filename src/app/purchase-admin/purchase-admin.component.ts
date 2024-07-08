import { Component, OnInit } from '@angular/core';
import { PresentService } from '../services/present.service';
import { CartService } from '../services/cart.service';
import { Router } from '@angular/router';
import { DataViewModule, DataViewLayoutOptions } from 'primeng/dataview';
import { PresentList } from '../models/present.model';
import { SelectItem } from 'primeng/api';


@Component({
  selector: 'app-purchase-admin',
  templateUrl: './purchase-admin.component.html',
  styleUrls: ['./purchase-admin.component.css']
})
export class PurchaseAdminComponent implements OnInit{
  constructor(public presentService:PresentService,public cartService:CartService, private router:Router) {  }
  ngOnInit(): void {
    this.presentService.callToGetPresent$.subscribe(x=>{
      this.presentService.getAllPresents().subscribe(lp=> this.myPresent=lp);
    })
    this.sortOptions = [
      {label: 'Price High to Low', value: '!price'},
      {label: 'Price Low to High', value: 'price'}
  ];
}

myPresent:PresentList[]=[];

layout:any;

  sortOptions: SelectItem[] | undefined;

  sortOrder: number | undefined;

  sortField: string | undefined;

  onSortChange(event: { value: any; }) {
    let value = event.value;

    if (value.indexOf('!') === 0) {
        this.sortOrder = -1;
        this.sortField = value.substring(1, value.length);
    }
    else {
        this.sortOrder = 1;
        this.sortField = value;
    }
}

}