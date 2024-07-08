import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { NavigationEnd, Route, Router } from '@angular/router';
import { LoginService } from './services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent{
  title = 'ChineseSale';
  showNavigate: boolean = true;

  constructor(private router: Router,public userService: LoginService){
      this.router.events.subscribe((e)=>{
        if( e instanceof NavigationEnd){
          if(e.url == '/' || e.url == '/register'){
            this.showNavigate = false;
          }
          else{
            this.showNavigate = true;
          }
        }
      })
  }
}
