import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http : HttpClient) { }

  isAdmin:boolean = false
  isUser(user:User){
    let url = 'https://localhost:7024/api/Login'
    return this.http.post<string>(url, user)
  }

  createUser(user:User){
    let url = 'https://localhost:7024/api/User/Register'
    return this.http.post<boolean>(url, user)
  }
  getUsers(){
    let url='https://localhost:7024/api/User'
    return this.http.get<User[]>(url)
  }
  
}
