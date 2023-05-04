import { Inject, Injectable, inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { StoreModel } from "src/Models/Stores/Store.model";
import { environment } from "src/environments/environment";
import { CookieService } from "ngx-cookie-service";
@Injectable({
    providedIn: "root"
})
export class StoresService{
    apiUrl = environment.apiUrl;
    constructor(
        private http: HttpClient,
        private cookieService: CookieService){

    }
    GetStores(limit:number){
        return this.http.get<StoreModel[]>(`${this.apiUrl}Stores?limit=${limit}`, {
            headers: {
                "Authorization": `Bearer ${this.cookieService.get("token")}`
            }
        })
    }

    UpdateStore(store: StoreModel){
        return this.http.put<StoreModel | null>(`${this.apiUrl}Stores`, store, {
            headers: {
                "Authorization": `Bearer ${this.cookieService.get("token")}`
            }
        })
    }

    CreateStore(store: StoreModel){
        return this.http.post<StoreModel | null>(`${this.apiUrl}Stores`, store, {
            headers: {
                "Authorization": `Bearer ${this.cookieService.get("token")}`
            }
        })
    }

    DeleteStore(guid: string){
        return this.http.delete<StoreModel | null>(`${this.apiUrl}Stores/${guid}`, {
            headers: {
                "Authorization": `Bearer ${this.cookieService.get("token")}`
            }
        })
    }

}