import { Component, OnInit } from '@angular/core';
import { LoginService } from '../services/user.service';
import { User } from '../models/user.model';

@Component({
  selector: 'app-user-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  constructor(public userService: LoginService) {}
  ngOnInit(): void {
   this.userService.getUsers().subscribe(data=>this.users=data
   )
  }
users:User[]=[]
}
