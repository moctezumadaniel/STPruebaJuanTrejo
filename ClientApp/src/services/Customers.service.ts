import {  Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { CustomerModel } from "src/Models/Stores/Customer.model";
import { CookieService } from "ngx-cookie-service";
import { ItemModel } from "src/Models/Stores/Item.model";
@Injectable({
    providedIn: "root"
})
export class CustomersService{
    apiUrl = environment.apiUrl;
    constructor(
        private http: HttpClient,
        private cookieService: CookieService){

    }
    GetCustomers(limit:number){
        return this.http.get<CustomerModel[]>(`${this.apiUrl}Customers?limit=${limit}`, {
            headers: {
                "Authorization": `Bearer ${this.cookieService.get("token")}`
            }
        })
    }

    GetCustomerItems(){
        return this.http.get<ItemModel[]>(`${this.apiUrl}Customers/Items`, {
            headers: {
                "Authorization": `Bearer ${this.cookieService.get("token")}`
            }
        })
    }

    UpdateCustomer(customer: CustomerModel){
        return this.http.put<CustomerModel>(`${this.apiUrl}Customers`, customer, {
            headers: {
                "Authorization": `Bearer ${this.cookieService.get("token")}`
            }
        })
    }

    CreateCustomer(customer: CustomerModel){
        return this.http.post<CustomerModel>(`${this.apiUrl}Customers`, customer, {
            headers: {
                "Authorization": `Bearer ${this.cookieService.get("token")}`
            }
        })
    }

    DeleteCustomer(guid: string){
        return this.http.delete<CustomerModel>(`${this.apiUrl}Customers/${guid}`, {
            headers: {
                "Authorization": `Bearer ${this.cookieService.get("token")}`
            }
        })
    }

}