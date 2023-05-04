import {  Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { CustomerModel } from "src/Models/Stores/Customer.model";
import { ItemModel } from "src/Models/Stores/Item.model";
import { CookieService } from "ngx-cookie-service";
@Injectable({
    providedIn: "root"
})
export class ItemsService{
    apiUrl = environment.apiUrl;
    constructor(
        private http: HttpClient,
        private cookieService: CookieService){

    }
    GetItems(limit:number){
        return this.http.get<ItemModel[]>(`${this.apiUrl}Items?limit=${limit}`, {
            headers: {
                "Authorization": `Bearer ${this.cookieService.get("token")}`
            }
        })
    }

    UpdateItem(item: ItemModel){
        return this.http.put<ItemModel | null>(`${this.apiUrl}Items`, item, {
            headers: {
                "Authorization": `Bearer ${this.cookieService.get("token")}`
            }
        })
    }

    CreateItem(item: ItemModel){
        return this.http.post<ItemModel | null>(`${this.apiUrl}Items`, item, {
            headers: {
                "Authorization": `Bearer ${this.cookieService.get("token")}`
            }
        })
    }

    DeleteItem(guid: string){
        return this.http.delete<ItemModel | null>(`${this.apiUrl}Items/${guid}`, {
            headers: {
                "Authorization": `Bearer ${this.cookieService.get("token")}`
            }
        })
    }

    AddToCart(guid:string){
    return this.http.post<ItemModel | null>(`${this.apiUrl}Items/${guid}`,{}, {
        headers: {
            "Authorization": `Bearer ${this.cookieService.get("token")}`
        }
    })

    }

}