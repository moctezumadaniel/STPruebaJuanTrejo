import { Component } from '@angular/core';
import { CustomerModel } from 'src/Models/Stores/Customer.model';
import { CustomersService } from 'src/services/Customers.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent {
  customers: CustomerModel[] = []
  customerToCreate: CustomerModel = {
    id: "",
    address: "",
    emailAddress: "",
    lastName: "",
    name: "",
    password: "",
  };
  constructor(private customersService: CustomersService){

  }

  createCustomer(){
    this.customersService.CreateCustomer(this.customerToCreate).subscribe(data=> {
      if(data != null){
        this.customerToCreate = {
          id: "",
          address: "",
          emailAddress: "",
          lastName: "",
          name: "",
          password: "",
        }
        this.customers.push(data);
      }
    })
  }

  updateCustomer(guid:string){
    let customersWithGuid = this.customers.filter(i => i.id === guid)
    if(customersWithGuid?.length > 0){
      this.customersService.UpdateCustomer(customersWithGuid[0]).subscribe(data=> {
        
      })
    }
  }

  deleteCustomer(guid:string){
    this.customersService.DeleteCustomer(guid).subscribe(data=> {
      if(data !== null){
        this.customers = this.customers.filter(i=> i.id !== guid);
      }
    })
  }
  ngOnInit(){
    this.customersService.GetCustomers(10000).subscribe(data => {
      this.customers = data;
    })
  }
}
