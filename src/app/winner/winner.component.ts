import { Component, OnDestroy, OnInit } from '@angular/core';
import { PresentService } from '../services/present.service';
import { Winner } from '../models/winner.model';

@Component({
  selector: 'app-winner',
  templateUrl: './winner.component.html',
  styleUrls: ['./winner.component.css']
})
export class WinnerComponent implements OnInit{
  constructor(public presentService: PresentService) { }
 
  winners:Winner[]=[]
  empty = true
  ngOnInit(): void {
    this.presentService.callToGetPresent$.subscribe(x => {
      this.presentService.getAllPresents().subscribe(lp => {
        this.presentService.myPresent = lp;
        console.log(this.presentService.myPresent);
        this.presentService.getWinners().subscribe(w => {this.winners = w
          console.log(w)
          if(w.length!=0)
            this.empty=false
      })
      });

    })
  }
  getallIncomes(){
    this.presentService.getallIncomes().subscribe(data=>alert(data)
    
    )
  }
  
}
