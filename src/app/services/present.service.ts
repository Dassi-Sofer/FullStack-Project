import { Injectable } from '@angular/core';
import { PresentList } from '../models/present.model';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { User } from '../models/user.model';
import { Winner } from '../models/winner.model';

@Injectable({
  providedIn: 'root'
})
export class PresentService {

  constructor(private http : HttpClient) {}

  showDialog: boolean = false;
  currentPresnt: PresentList=new PresentList();
  id: number= 109;
  private callToGetPresentSubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  callToGetPresent$: Observable<boolean> = this.callToGetPresentSubject.asObservable();
  myPresent:PresentList[]=[];
  winner:User = new User();
  
  getAllPresents() : Observable<PresentList[]>{
    let url='https://localhost:7024/api/Present';
    
     var l=this.http.get<PresentList[]>(url).pipe(map(l => this.myPresent = l));
     console.log(l);
     return l
  }

  deletePresentByID(presentId: number) {
    let url='https://localhost:7024/api/Present/'+ presentId
  
    console.log(url);

    return this.http.delete<number>(url);
  }

  editPresntById(present: PresentList): Observable<boolean> {
    let url = 'https://localhost:7024/api/Present'
    // var index = this.myPresent.findIndex(p =>p.id == present.id)
    // this.currentPresnt = this.myPresent[index]; 
    // debugger
    return this.http.put<boolean>(url, present)
  }

  addNew(present: PresentList): Observable<number>{
    let url='https://localhost:7024/api/Present'
    var index= this.myPresent.findIndex(p=>p.id==present.id);
    // this.currentPresnt = new PresentList()
    this.currentPresnt.id = this.id++;
    // debugger
   // this.showDialog = true;
    
    return this.http.post<number>(url,present)
  }
    
raffle(presentId:number){
let url='https://localhost:7024/api/Ruffle/ruffledddddddddd?presentId='+presentId
return this.http.post<User>(url,presentId)
}

getWinners(){
  let url='https://localhost:7024/api/Ruffle/GetWinners'
  return this.http.get<Winner[]>(url)
}

  setGetPresent(){
    let flag = this.callToGetPresentSubject.value;
    this.callToGetPresentSubject.next(!flag);
   }


  saveProduct(present:PresentList){
    var index= this.myPresent.findIndex(p=>p.id==present.id);
    if(index>-1){
      console.log(index);
      //update present
      this.editPresntById(present).subscribe(()=>{
        this.getAllPresents().subscribe();
      });
     // this.myPresent[index]=$event;
    
    }
    else{
      const result = this.myPresent.some((p) => p.name.trim() === present.name.trim());
      if(result){
        window.alert("יש כזה שם כבר במכירה")
      }
      else{
        this.addNew(present).subscribe(()=>{
        this.getAllPresents().subscribe();

        }); 
      }
    }
  }

  getallIncomes(){
    let url='https://localhost:7024/api/Bucket/GetAllIncomes'
    return this.http.get<number>(url)
  }

  sort(cost:boolean,category:boolean){
    let url = `https://localhost:7024/api/Present/Sort?max=${cost}&category=${category}`
  return this.http.get<PresentList[]>(url)
  }
}
