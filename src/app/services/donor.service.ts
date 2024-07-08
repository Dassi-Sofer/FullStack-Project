import { Injectable } from '@angular/core';
import { Donor } from '../models/donor.model';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { PresentList } from '../models/present.model';

@Injectable({
  providedIn: 'root'
})
export class DonorService {

  constructor(private http:HttpClient) { }
  id:number=10;
  currentDonor: Donor=new Donor();
  showDialog: boolean = false;
 private callToGetDonorSubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  callToGetDonor$: Observable<boolean> = this.callToGetDonorSubject.asObservable();

  myDonor:Donor[]=[];
 getAllDonors():Observable<Donor[]>{
  let url='https://localhost:7024/api/Donor'
    return this.http.get<Donor[]>(url).pipe(map(l => this.myDonor = l))
    ;
 }

 deleteDonortByID(donorId: number) {
  let url='https://localhost:7024/api/Donor/'+ donorId

  console.log(url);
  return this.http.delete<number>(url);
}
editDonorById(donor:Donor): Observable<boolean> {
  console.log(donor);
  
  let url = 'https://localhost:7024/api/Donor'

  // var index = this.myDonor.findIndex(p =>p.id == donorId)
  // this.currentDonor = this.myDonor[index]; 
  // debugger
  return this.http.put<boolean>(url, donor)
}


addNew(donor: Donor): Observable<number>{
  let url='https://localhost:7024/api/Donor'
  
  this.currentDonor = new Donor()
  this.currentDonor.id = this.id++;
  this.showDialog = true;
  
  return this.http.post<number>(url,donor)
}

getPresentsByDonor(donorId:number):Observable<PresentList[]>{
  let url = "https://localhost:7024/api/Donor/GetDonationList?id="+donorId
  return this.http.get<PresentList[]>(url);
}

setGetDonor(){
  let flag = this.callToGetDonorSubject.value;
  this.callToGetDonorSubject.next(!flag);
 }

 
 saveDonorBy(donor:Donor){
  var index= this.myDonor.findIndex(p=>p.id==donor.id);
  if(index>-1){

    this.editDonorById(donor).subscribe(()=>{
      this.getAllDonors().subscribe();
    });
    //update present
    // this.myDonor[index]=$event;
  
  }
  else{
    const result = this.myDonor.some((p) => p.name.trim() === donor.name.trim());
    if(result){
      window.alert("duplicate!!")
    }
    else{
      this.addNew(donor).subscribe(()=>{
      this.getAllDonors().subscribe();
      }) ;
    }
  }
}

}
