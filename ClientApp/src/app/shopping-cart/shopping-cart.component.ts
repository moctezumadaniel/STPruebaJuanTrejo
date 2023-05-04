import { Component } from '@angular/core';
import { ItemModel } from 'src/Models/Stores/Item.model';
import { CustomersService } from 'src/services/Customers.service';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent {
  items: ItemModel[] = []
  constructor(
    private customersService: CustomersService
  ){}
  ngOnInit(){
    this.customersService.GetCustomerItems().subscribe(data=> {
      this.items = data;
      console.log(data)
    })
  }
}
