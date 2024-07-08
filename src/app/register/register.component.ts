import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from '../services/user.service';
import { User } from '../models/user.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  registerForm : FormGroup=new FormGroup({});
  ivrit: RegExp = /^[a-z\s]*$/;
    emailReg:RegExp = new RegExp('[]@"".""')
  constructor(public userService :LoginService,  private router:Router){
    this.registerForm=new FormGroup({
      username: new FormControl(null,[Validators.required,Validators.minLength(3)]),
      password: new FormControl(null, [Validators.required, Validators.minLength(5),Validators.maxLength(5)]),
      email: new FormControl(null, [Validators.required,Validators.email]),
      phone:new FormControl(null, [Validators.minLength(10),Validators.maxLength(10)]),
      fullName: new FormControl(null,[Validators.required,Validators.minLength(5)])
    });
  }
  user:User =new User();
  username:string | undefined;
  password:string | undefined;
  email:string | undefined;
  phone:string | undefined;
  fullName:string | undefined;
  
  send(){
    this.user.username = this.username
    this.user.password = this.password
    this.user.fullName = this.fullName
    this.user.email = this.email
    this.user.phone = this.phone
    this.userService.createUser(this.user).subscribe((data)=>{
      console.log(data)
      if(data)
      this.router.navigate([''])
      else
      window.alert("username or password duplicate")
    })
  }
}
