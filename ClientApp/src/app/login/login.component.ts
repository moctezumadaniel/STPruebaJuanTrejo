import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { LoginModel } from 'src/Models/Stores/Login.model';
import { AuthService } from 'src/services/Auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginInfo: LoginModel =  {
    email: "",
    password: ""
  }
  constructor(
    private authService: AuthService,
    private cookieService: CookieService,
    private router: Router
    ){
    
  }

  login(){
    this.authService.Login(this.loginInfo).subscribe(data=> {
      if(data !== null && data !== ""){
        this.cookieService.set("token", data)
        this.router.navigate(["/stores"])
      }
    })
  }
}
