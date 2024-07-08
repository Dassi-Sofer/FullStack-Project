import { Component, EventEmitter, Output, Input, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { PresentList } from 'src/app/models/present.model';
import { PresentService } from 'src/app/services/present.service';
import { DonorService } from '../../services/donor.service';
import { Donor } from 'src/app/models/donor.model';
@Component({
  selector: 'app-present',
  templateUrl: './present.component.html',
  styleUrls: ['./present.component.css']
})
export class PresentComponent implements OnChanges {
  
  @Input() selectedPresent:PresentList = new PresentList();
  @Output() closeDaialog: EventEmitter<any> = new EventEmitter<any>();
  @Output() updateDetails: EventEmitter<PresentList>=new EventEmitter<PresentList>();
  @Output() presntFormChanged:EventEmitter <string[]> = new EventEmitter<string[]>();

  constructor(public presentService:PresentService, public donorService: DonorService) {  }
  showDialog: boolean = false;
  ngOnInit(): void {
    this.donorService.callToGetDonor$.subscribe(x => {
      this.donorService.getAllDonors().subscribe(lp => 
      //   { lp.forEach(i => {
      //   this.myDonor.push(i.name);
      // });
      // console.log(this.myDonor);
      // }
      {this.myDonor=lp});
    })
  }
  myDonor:Donor [] =[];
  presntForm : FormGroup=new FormGroup({
    id: new FormControl(null),
    name: new FormControl(null, [Validators.required, Validators.minLength(2),Validators.maxLength(20)]),
    donorId: new FormControl([Validators.required]),
    cost: new FormControl('10', [Validators.required,Validators.min(10)]),
    image:new FormControl('null', [Validators.min(10)]),
    categoryId: new FormControl('0',[Validators.required])

  });
   
  ngOnChanges(changes: SimpleChanges): void {
    this.presntForm.patchValue(changes['selectedPresent'].currentValue);
    console.log(this.myDonor);
    
  }

  savePresent(){
    if(this.presntForm.valid){
   // this.presentService.addNew(this.presntForm.value).subscribe((res:number)=> this.presentService.setGetPresent());
   this.updateDetails.emit(this.presntForm.value);
   this.presntFormChanged.emit(this.presntForm.value)
    this.closeDaialog.emit();
    }
    else{
      console.log('לא ואלידי')
    }
  }
  cancel(){
    this.closeDaialog.emit();
  }
}
