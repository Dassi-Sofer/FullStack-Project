import { Component, OnInit } from '@angular/core';
import { DonorService } from '../../services/donor.service';
import { Donor } from '../../models/donor.model';
import { PresentList } from 'src/app/models/present.model';

@Component({
  selector: 'app-donor-list',
  templateUrl: './donor-list.component.html',
  styleUrls: ['./donor-list.component.css']
})
export class DonorListComponent implements OnInit {
  constructor(public donorService: DonorService) { }

  ngOnInit(): void {
    this.donorService.callToGetDonor$.subscribe(x => {
      this.donorService.getAllDonors().subscribe(lp => {this.donorService.myDonor = lp
      console.log(lp);
      });
    })
  }
  visible: boolean = false;
presents:PresentList[] =[]


  showDialog: boolean = false;
  submitted: boolean = false;
  currentDonor: Donor = new Donor();

  addNew() {
    this.donorService.currentDonor = new Donor()
    this.showDialog = true;
  }
  editDonor(donorId: number) {
    var index = this.donorService.myDonor.findIndex(p => p.id == donorId)
    this.donorService.currentDonor = this.donorService.myDonor[index];
    this.showDialog = true;
  }
  deleteDonor(donorId: number) {
    this.donorService.deleteDonortByID(donorId).subscribe((data) => {this.donorService.setGetDonor()
      if(!data)
      alert("אין אפשרות למחוק תורם זה")
    });
  }
  hideDialog() {
    this.showDialog = false;
  }
  saveDonor($event: Donor) {
    this.donorService.saveDonorBy($event)
    this.showDialog = false;
  }
  seePresent(donorId:number){
   
    this.donorService.getPresentsByDonor(donorId).subscribe(data=>{this.presents = data})
    this.visible = true;
  }
}
