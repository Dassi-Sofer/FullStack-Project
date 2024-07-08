import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { PresentList } from 'src/app/models/present.model';
import { PresentService } from 'src/app/services/present.service';

@Component({
  selector: 'app-presents',
  templateUrl: './presents.component.html',
  styleUrls: ['./presents.component.css']
})
export class PresentsComponent implements OnInit {


  constructor(public presentService: PresentService) { }
  ngOnInit(): void {
    this.presentService.callToGetPresent$.subscribe(x => {
      this.presentService.getAllPresents().subscribe(lp => {
        this.presentService.myPresent = lp;
      });

    })
  }
  visible:boolean=false
  showDialog: boolean = false;
  submitted: boolean = false;
  presntForm: FormGroup = new FormGroup({})

  deletePresnt(presentId: number) {
    this.presentService.deletePresentByID(presentId).subscribe(() => this.presentService.setGetPresent());
  }

  editPresnt(present: PresentList) {
    var index = this.presentService.myPresent.findIndex(p => p.id == present.id)
    this.presentService.currentPresnt = this.presentService.myPresent[index];

    this.showDialog = true;

  }
  presntFormChanged = (event: any) => {
    this.presntForm = event
  }
  addNew() {
    this.presentService.currentPresnt = new PresentList()
    this.showDialog = true;
  }

  hideDialog() {
    this.showDialog = false;
  }

  saveProduct($event: PresentList) {
    console.log($event);
 
    parseInt($event.donorId)
    console.log($event);

    this.presentService.saveProduct($event)
    this.showDialog = false;
  }


  raffle(presentId: number) {
    this.presentService.raffle(presentId).subscribe((data) => {this.presentService.winner= data
       console.log(data);
       this.visible=!this.visible;
    // if( this.presentService.winner != null)
    // this.visible=!this.visible;
    // else
    //  if(this.presentService.winner==null )
    //  this.visible=!this.visible;
    });

  }
}




