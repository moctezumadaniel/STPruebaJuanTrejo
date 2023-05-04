import { Component } from '@angular/core';
import { StoreModel } from 'src/Models/Stores/Store.model';
import { StoresService } from 'src/services/Stores.service';

@Component({
  selector: 'app-stores',
  templateUrl: './stores.component.html',
  styleUrls: ['./stores.component.css']
})
export class StoresComponent {
  stores: StoreModel[] = []
  storeToCreate: StoreModel = {
    address: "",
    branch: "",
    id: ""
  }
  constructor(private storesService: StoresService){

  }

  createStore(){
    this.storesService.CreateStore(this.storeToCreate).subscribe(data=> {
      if(data != null){
        this.storeToCreate = {
          address: "",
          branch: "",
          id: ""
        }
        this.stores.push(data);
      }
    })
  }

  updateStore(guid:string){
    let storesWithGuid = this.stores.filter(i => i.id === guid)
    if(storesWithGuid?.length > 0){
      this.storesService.UpdateStore(storesWithGuid[0]).subscribe(data=> {
        
      })
    }
  }

  deleteStore(guid:string){
    this.storesService.DeleteStore(guid).subscribe(data=> {
      if(data !== null){
        this.stores = this.stores.filter(i=> i.id !== guid);
      }
    })
  }
  ngOnInit(){
    this.storesService.GetStores(10000).subscribe(data => {
      this.stores = data;
    })
  }
}
