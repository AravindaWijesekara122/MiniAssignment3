import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CustomerListComponent } from './components/customer-list/customer-list.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { RegisterCustomerComponent } from './components/register-customer/register-customer.component';
import { AddBillComponent } from './components/add-bill/add-bill.component';


@NgModule({
  declarations: [
    AppComponent,
    CustomerListComponent,
    DashboardComponent,
    RegisterCustomerComponent,
    AddBillComponent
    
  

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
