import {  Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { CustomerModel } from "src/Models/Stores/Customer.model";
import { LoginModel } from "src/Models/Stores/Login.model";
@Injectable({
    providedIn: "root"
})
export class AuthService{
    apiUrl = environment.apiUrl;
    constructor(
        private http: HttpClient){

    }
    Login(login:LoginModel){
        return this.http.post<string>(`${this.apiUrl}Auth/Login`,login)
    }

    

}