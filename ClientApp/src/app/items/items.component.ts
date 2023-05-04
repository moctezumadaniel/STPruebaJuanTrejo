import { Component } from '@angular/core';
import { ItemModel } from 'src/Models/Stores/Item.model';
import { StoreModel } from 'src/Models/Stores/Store.model';
import { ItemsService } from 'src/services/Items.service';
import { StoresService } from 'src/services/Stores.service';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css']
})
export class ItemsComponent {
  items: ItemModel[] = []
  stores: StoreModel[] = []

  itemToCreate: ItemModel = {
    code: "",
    description: "",
    id: "",
    image: "TEST",
    price: 0,
    stock: 0,
    storeId: ""
  }
  constructor(
    private itemsService: ItemsService,
    private storesService: StoresService){

  }

  deleteItem(guid:string){
    this.itemsService.DeleteItem(guid).subscribe(data=> {
      if(data !== null){
        this.items = this.items.filter(i=> i.id !== guid)
      }
    })
  }

  createItem(){
    this.itemsService.CreateItem(this.itemToCreate).subscribe(data=> {
      if(data !== null){
        this.itemToCreate={
          code: "",
          description: "",
          id: "",
          image: "TEST",
          price: 0,
          stock: 0,
          storeId: ""
        }
      }
      this.items.push(data!)
    })
  }
  addToCart(guid:string){
    this.itemsService.AddToCart(guid).subscribe(data=> {
      
    })
  }

  updateItem(guid:string){
    let itemToUpdate = this.items.filter(i=> i.id === guid)
    this.itemsService.UpdateItem(itemToUpdate[0]).subscribe(data=> {
      
    })
  }

  ngOnInit(){
    this.itemsService.GetItems(10000).subscribe(data => {
      this.items = data;
    })
    this.storesService.GetStores(10000).subscribe(data=> {
      this.stores = data;
      console.log(this.stores)
    })
  }
}
