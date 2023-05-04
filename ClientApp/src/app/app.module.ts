import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { StoresComponent } from './stores/stores.component';
import { ItemsComponent } from './items/items.component';
import { CustomersComponent } from './customers/customers.component';
import { StoresService } from 'src/services/Stores.service';
import { CustomersService } from 'src/services/Customers.service';
import { ItemsService } from 'src/services/Items.service';
import { LoginComponent } from './login/login.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { AuthService } from 'src/services/Auth.service';
import { CookieService } from 'ngx-cookie-service';
import { AuthGuard } from 'src/guards/Auth.guard';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    StoresComponent,
    ItemsComponent,
    CustomersComponent,
    LoginComponent,
    ShoppingCartComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: LoginComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent , canActivate: [AuthGuard]},
      { path: 'fetch-data', component: FetchDataComponent , canActivate: [AuthGuard]},
      { path: 'stores', component: StoresComponent , canActivate: [AuthGuard]},
      { path: 'items', component: ItemsComponent , canActivate: [AuthGuard]},
      { path: 'customers', component: CustomersComponent , canActivate: [AuthGuard]},
      { path: 'login', component: LoginComponent },
      { path: 'shopping-cart', component: ShoppingCartComponent, canActivate: [AuthGuard]},


    ])
  ],
  providers: [
    StoresService,
    CustomersService,
    ItemsService,
    AuthService,
    CookieService,
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
