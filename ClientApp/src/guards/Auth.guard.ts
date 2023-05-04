import {  Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { CookieService } from "ngx-cookie-service";

@Injectable({
    providedIn: "root"
})
export class AuthGuard implements CanActivate{
    constructor(
        private cookieService: CookieService,
        private routerService: Router
        ){

    }
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot){
        if(!this.cookieService.check("token")){
            this.routerService.navigate(["/login"])
            return false
        }else{
            return true
        }

    }


}