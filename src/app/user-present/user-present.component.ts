import { Component, OnInit} from '@angular/core';
import { PresentService } from '../services/present.service';

@Component({
  selector: 'app-user-present',
  templateUrl: './user-present.component.html',
  styleUrls: ['./user-present.component.css']
})
export class UserPresentComponent implements OnInit{
  constructor(public presentService:PresentService) {  }
  ngOnInit(): void {
    this.presentService.callToGetPresent$.subscribe(x=>{
      this.presentService.getAllPresents().subscribe(lp=> this.presentService.myPresent=lp);
    })
  } 
}
