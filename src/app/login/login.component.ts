import { Component, Input } from '@angular/core';
import { User } from '../models/user.model';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LoginService } from '../services/user.service';
import { Router } from '@angular/router';
import { startWith } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm: FormGroup = new FormGroup({});

  constructor(public userService: LoginService, private router: Router) {
    this.loginForm = new FormGroup({
      username: new FormControl(null, [Validators.required, Validators.minLength(3), Validators.maxLength(30)]),
      password: new FormControl(null, [Validators.required, Validators.minLength(5), Validators.maxLength(5)]),
    });
  }
  user: User = new User();
  username: string | undefined;
  password: string | undefined;

  send() {
    this.user.username = this.username
    this.user.password = this.password
    this.userService.isUser(this.user).subscribe((data) => {
      if(data == null)
      this.router.navigate(['register'])
        else{
           this.saveToken(data);
            if (this.username == 'dasi' && this.password == '44444')
              this.userService.isAdmin = true
            else
              this.userService.isAdmin = false
            this.router.navigate(['/home'])
        }
    });
  }
  saveToken(token:string) {
    sessionStorage.setItem("token", JSON.stringify(token));
  }
}
