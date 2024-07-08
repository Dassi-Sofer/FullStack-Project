import { Component, Output,Input, EventEmitter, SimpleChange, OnChanges, SimpleChanges } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Donor } from 'src/app/models/donor.model';
import { DonorService } from 'src/app/services/donor.service';

@Component({
  selector: 'app-second-donor',
  templateUrl: './second-donor.component.html',
  styleUrls: ['./second-donor.component.css']
})
export class SecondDonorComponent implements OnChanges {

  @Input() selectedDonor:Donor = new Donor();
  @Output() closeDaialog: EventEmitter<any> = new EventEmitter<any>();
  @Output() updateDetails: EventEmitter<Donor> = new EventEmitter<Donor>();
  @Output() donorFormChanged:EventEmitter <string[]> = new EventEmitter<string[]>();

  constructor(public donorService: DonorService) { }
  showDialog: boolean = false;
  emailReg:RegExp=new RegExp('[]@[a-z].[a-z]')
  donorForm : FormGroup=new FormGroup({
    id: new FormControl(null),
    name: new FormControl(null, [Validators.required, Validators.minLength(2),Validators.maxLength(20)]),
    address: new FormControl(null,[Validators.required,Validators.maxLength(30)]),
    phone: new FormControl(null, [Validators.required,Validators.min(9),Validators.maxLength(10)]),
    email: new FormControl(null, [Validators.required,Validators.email])
      // Validators.pattern(this.emailReg)
  });

  ngOnChanges(changes: SimpleChanges): void {
    this.donorForm.patchValue(changes['selectedDonor'].currentValue);
  }
  saveNew(){
    if(this.donorForm.valid){
      // this.presentService.addNew(this.presntForm.value).subscribe((res:number)=> this.presentService.setGetPresent());
      this.updateDetails.emit(this.donorForm.value);
      this.donorFormChanged.emit(this.donorForm.value)
       this.closeDaialog.emit();
       }
       
     
  }
  cancle(){
    this.closeDaialog.emit();
  }
}
